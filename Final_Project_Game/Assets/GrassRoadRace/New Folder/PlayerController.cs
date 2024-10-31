using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private CharacterController charController;
	public float speed;
	float forword_speed;
	Vector3 moving = new Vector3();
	// Use this for initialization
	void Start()
	{
		charController = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update()
	{
		float h = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		forword_speed = Time.deltaTime * speed;
		moving.z = forword_speed;
		moving.x = h;
		charController.Move(moving);
		if (charController.isGrounded)
		{
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				JumP();
				//Debug.Log("ssss");
			}
		}
		else moving.y += -10 * Time.deltaTime;
	}

	void JumP()
	{
		moving.y = 20 * Time.deltaTime;
	}
}
