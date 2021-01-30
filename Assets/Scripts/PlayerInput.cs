using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(player))]
public class PlayerInput : MonoBehaviour
{

	player _player;
	public DialogueManager dialogueManager;

	void Start()
	{
		_player = GetComponent<player>();
	}

	void Update()
	{
		Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		if (!dialogueManager.GetComponent<DialogueManager>().talk)
		{
			_player.SetDirectionalInput(directionalInput);

			if (Input.GetButtonDown(("Jump")))
			{
				_player.OnJumpInputDown();
			}

			if (Input.GetButtonUp("Jump"))
			{
				_player.OnJumpInputUp();
			}

			if (Input.GetButtonDown(("Dash")))
			{
				_player.Dash();
			}

			if (Input.GetKeyDown(KeyCode.E))
			{
				if (_player.pushableObj != null)
				{
					_player.EndInteract();
				}
				else
				{
					Debug.Log("Try interact");
					_player.Interact();
				}

			}

			/*if (Input.GetButtonUp(("Fire1")))
			{
				player.Shoot();
			}*/
		}
		else
        {
			_player.SetDirectionalInput(new Vector2(0, 0));
		}
	}
}
