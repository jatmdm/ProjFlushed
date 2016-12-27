using UnityEngine;
using System.Collections;

public class playerPlatformerMovementScript : MonoBehaviour {

	public float groundAcceleration;
	public float airAcceleration;
	public float maxSpeed;
	public float jumpForce;
	public float jumpCountdownSpeed;

	float jumpTimer;

	playerPlatformerScript playerState;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		playerState = GetComponent<playerPlatformerScript> ();
		rb = GetComponent<Rigidbody2D> ();

		jumpTimer = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (playerState.isGrounded ()) {
			rb.AddForce (Vector2.right * Input.GetAxis ("Horizontal") * groundAcceleration);
		} else if (!playerState.isGrounded ()) {
			rb.AddForce (Vector2.right * Input.GetAxis ("Horizontal") * airAcceleration);
		}

		rb.velocity = new Vector2 (Mathf.Clamp (rb.velocity.x, -maxSpeed, maxSpeed), rb.velocity.y);

		if (jumpTimer > 0) {
			rb.AddForce (Vector2.up * jumpForce);

			jumpTimer -= jumpCountdownSpeed * Time.deltaTime;

		}

		if (playerState.isGrounded() && Input.GetButtonDown ("Fire1")) {
			if (jumpTimer <= 0) {
				jumpTimer = 1;
			}
		}
		if (playerState.isGrounded() && jumpTimer > 0 && Input.GetButtonUp ("Fire1")) {
			jumpTimer = 0;
		}
	}
}
