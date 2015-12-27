using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float movementSpeed = 6.0f;
	public float mouseLeftrightSensitivity = 10.0f;
	public float mouseUpdownSensitivity = 6.0f;
	public float updownRange = 45.0f;

	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;
	float verticalRotation = 0.0f;

	void Awake() {
		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Update() {
		if (Cursor.lockState != CursorLockMode.Locked) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}

	void FixedUpdate() {
		float horizontalMove = Input.GetAxisRaw("Horizontal");
		float verticalMove = Input.GetAxisRaw("Vertical");
		Move(horizontalMove, verticalMove);

		float rotLeftRight = Input.GetAxis("Mouse X") * mouseLeftrightSensitivity;
		float rotUpDown= Input.GetAxis("Mouse Y") * mouseUpdownSensitivity;
		Turning(rotLeftRight, rotUpDown);

		Animating(horizontalMove, verticalMove);
	} 

	void Move(float h, float v) {
		movement.Set(h, 0.0f, v);
		movement = transform.rotation * movement;
		movement = movement.normalized * movementSpeed * Time.deltaTime;
		playerRigidbody.MovePosition(transform.position + movement);
	}

	void Turning(float rl, float ud) {
		transform.Rotate(0, rl, 0);
		verticalRotation += -ud;
		verticalRotation = Mathf.Clamp(verticalRotation, -updownRange, updownRange);
		Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
	}

	void Animating(float h, float v) {
		bool walking = h!=0f || v !=0f;
		anim.SetBool("IsWalking", walking);
	}
}
