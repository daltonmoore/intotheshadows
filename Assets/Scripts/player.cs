using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Controller2D))]
public class player : MonoBehaviour
{
    public Transform respawnPoint;
    public bool inHealingLight, inDamageLight;
    [SerializeField]
    int totalHealth;
    int health;
    float lightDmgCoolDown = .01f;
    float lightHealCoolDown = .02f;
    Coroutine lightDmgCoolDownCoroutine, lightHealCoolDownCoroutine;
    Animator animator;
    SpriteRenderer spriteRenderer;

    public float maxJumpHeight = 4;
    public float minJumpHeight = 1;
    float timeToJumpApex = 0.4f;
    float accelerationTimeAirbourne = 0.2f;
    float accelerationTimeGrounded = 0.1f;
    float moveSpeed = 6;


    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;

    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    Vector3 velocity;
    float velocityNormal;
    float velocityXSmoothing;


    public float wallSlideSpeedMax = 3.0f;
    public float wallStickTime = .25f;
    public float timeToWallUnstick;

    Vector2 directionalInput;
   public bool wallSliding;
    int wallDirX;

    bool canDash = true;
    public float dashTime;

    public GameObject lemonsPrefab;

    public float chargeTimer = 0;
    private Vector3 move;
    private float xMove;
    private float yMove;

    [SerializeField] Controller2D controller;

    public float distance = 1f;
    public LayerMask boxMask;

    public GameObject pushableObj;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.position = respawnPoint.position;
        animator = GetComponent<Animator>();
        health = totalHealth;

        controller = GetComponent<Controller2D>();

        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
        //print("Gravity: " + gravity + "  Jump Velocity: " + maxJumpVelocity);
    }

    void Update()
    {
        move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f);
        animator.SetFloat("horizontal", move.x);

        if (move != Vector3.zero)
        {
            xMove = move.x;
            yMove = move.y;
        }

        CalculateVelocity();
        HandleWallSliding();
        //if (Input.GetButton(("Fire1")))
        //{
        //    chargeTimer += Time.deltaTime;
        //}

        controller.Move(velocity * Time.deltaTime, directionalInput);

        if (controller.collisions.above || controller.collisions.below)
        {
            if (controller.collisions.slidingDownMaxSlope)
            {
                velocity.y += controller.collisions.slopeNormal.y * -gravity * Time.deltaTime;
            }
            else
            {
                velocity.y = 0;
            }
        }

        if (inDamageLight && lightDmgCoolDownCoroutine == null)
        {
            HitByDmgLight();
            lightDmgCoolDownCoroutine = StartCoroutine(LightDmgCoolDown());
        }

        if (inHealingLight && lightHealCoolDownCoroutine == null)
        {
            HitByHealLight();
            lightHealCoolDownCoroutine = StartCoroutine(LightHealCoolDown());
        }

        if (transform.position.y < -15)
        {
            Respawn();
        }
    }

    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = input;
    }

    public void OnJumpInputDown()
    {
        if (wallSliding)
        {
            if (wallDirX == directionalInput.x)
            {
                velocity.x = -wallDirX * wallJumpClimb.x;
                velocity.y = wallJumpClimb.y;
            }
            else if (directionalInput.x == 0)
            {
                velocity.x = -wallDirX * wallJumpOff.x;
                velocity.y = wallJumpOff.y;
            }
            else
            {
                velocity.x = -wallDirX * wallLeap.x;
                velocity.y = wallLeap.y;
            }
            animator.SetTrigger("jump");
        }

        if (controller.collisions.below)
        {
            if (controller.collisions.slidingDownMaxSlope)
            {
                if (directionalInput.x != -Mathf.Sign(controller.collisions.slopeNormal.x))
                {   // not jumping against max slope
                    velocity.y = maxJumpVelocity * controller.collisions.slopeNormal.y;
                    velocity.x = maxJumpVelocity * controller.collisions.slopeNormal.x;
                }

                else
                {
                    velocity.y = maxJumpVelocity;
                }
            }

            else
            {
                velocity.y = maxJumpVelocity;
            }
            animator.SetTrigger("jump");
        }
    }

    public void OnJumpInputUp()
    {
        if (velocity.y > minJumpVelocity)
        {
            velocity.y = minJumpVelocity;
        }
    }


    void HandleWallSliding()
    {
        wallDirX = (controller.collisions.left) ? -1 : 1;
        wallSliding = false;
        if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
        {
            wallSliding = true;


            if (timeToWallUnstick > 0)
            {
                velocityXSmoothing = 0;
                velocity.x = 0;

                if (directionalInput.x != wallDirX /*&& directionalInput.x != 0*/)
                {
                    timeToWallUnstick -= Time.deltaTime;
                    //velocity.y += gravity * Time.deltaTime;
                }
                else
                {
                    timeToWallUnstick = wallStickTime;
                    //velocity.y = -wallSlideSpeedMax;
                }

            }

            if (velocity.y < -wallSlideSpeedMax && timeToWallUnstick > 0)
            {
                velocity.y = -wallSlideSpeedMax;
            }
            else
            {
                velocity.y += gravity * Time.deltaTime;

            }
        }
        else
        {
            timeToWallUnstick = wallStickTime;
        }

    }

    public void Dash()
    {
        if (canDash)
        {
            StartCoroutine(DashAbility());
        }
    }

    //public void Shoot()
    //{
    //    if (Input.GetButtonUp(("Fire1")))
    //    {
    //        Vector2 temp = new Vector2(xMove, yMove);
    //        Lemon projectile = Instantiate(lemonsPrefab, new Vector3(transform.position.x + (xMove / 2), transform.position.y + (yMove / 2), transform.position.z), Quaternion.identity).GetComponent<Lemon>();
    //        projectile.SetUp(temp, ShootDirection(), chargeTimer);
    //        chargeTimer = 0;
    //    }
    //}

    IEnumerator DashAbility()
    {

        if (controller.collisions.below)
        {
            canDash = false;
        }
        else
        {
            canDash = true;

        }
        //canDash = false;

        if (velocity != Vector3.zero)
        {
            if (velocity.normalized.x < 0)
            {
                velocityNormal = -1;
            }
            else if (velocity.normalized.x > 0)
            {
                velocityNormal = 1;
            }
        }

        float targetVelocityX = velocityNormal * maxJumpVelocity;
         velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirbourne);
       // velocity.x = maxJumpVelocity * velocityNormal;

        yield return new WaitForSeconds(dashTime);

        canDash = true;

    }

    void CalculateVelocity()
    {
        float targetVelocityX = directionalInput.x * moveSpeed;
        float targetJumpVelocityX = velocityNormal * maxJumpVelocity;
        if (canDash)
        {
            velocity.x = targetVelocityX;//Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirbourne);
        }
        else
        {
            velocity.x = targetJumpVelocityX;//Mathf.SmoothDamp(velocity.x, targetJumpVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirbourne);
        }
        velocity.y += gravity * Time.deltaTime;
    }

    Vector3 ShootDirection()
    {
        float temp = Mathf.Atan2(xMove, yMove) * Mathf.Rad2Deg;
        return new Vector3(0, 0, temp);
    }

    public void Interact()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * xMove, distance, boxMask);

        if (hit.collider != null && hit.collider.gameObject.tag == "pushable")
        {
            pushableObj = hit.collider.gameObject;
            pushableObj.transform.parent = gameObject.transform;
            //pushableObj.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            //pushableObj.GetComponent<FixedJoint2D>().enabled = true;
            pushableObj.GetComponent<PullPush>().beingPushed = true;
        }
        else if (hit.collider != null && hit.collider.gameObject.tag == "Dialogue")
        {
            hit.collider.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
        }

    }
    public void ContinueInteract()
    {

    }

    public void EndInteract()
    {
        //pushableObj.GetComponent<FixedJoint2D>().enabled = false;
        pushableObj.transform.parent = null;
        pushableObj.GetComponent<PullPush>().beingPushed = false;
        pushableObj = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * xMove * distance);
    }

    IEnumerator LightDmgCoolDown()
    {
        yield return new WaitForSeconds(lightDmgCoolDown);
        lightDmgCoolDownCoroutine = null;
    }

    IEnumerator LightHealCoolDown()
    {
        yield return new WaitForSeconds(lightHealCoolDown);
        lightHealCoolDownCoroutine = null;
    }

    public void HitByDmgLight()
    {
        if (health > 0)
        {
            health--;
            UpdateOpacity();
        }
        else
        {
            Respawn();
        }
    }

    public void HitByHealLight()
    {
        if (health < totalHealth)
        {
            health++;
            UpdateOpacity();
        }
    }
    void UpdateOpacity()
    {
        Color c = spriteRenderer.color;
        spriteRenderer.color = new Color(c.r, c.g, c.b, 1 * ((float)health / totalHealth));
    }

    void Respawn()
    {
        health = totalHealth;
        transform.position = respawnPoint.position;
        UpdateOpacity();
    }
}
