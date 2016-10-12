using UnityEngine;
using System.Collections;

public class newMoveController : MonoBehaviour {

	public float moveAmount = 20f;
	public float maxSpeed = 5f;
	public float friction = .4f;
	public float movingFriction = .2f;
	public float stunPower = 4;
	public float turnAcceleration = 40f;
	public float blastPower = 5;

	private bool blast;

	bool stunned;

	Rigidbody2D rigidBody;

	StunController playerStun;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
		playerStun = GetComponent<StunController>();
		blast = false;

		stunned = false;
	}

	void FixedUpdate() {
		Vector2 inputDirection = new Vector2 (Input.GetAxis ("Horizontal"),
			                         Input.GetAxis ("Vertical"));
		inputDirection = inputDirection.normalized;
		
		bool noMove = Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0;

		Vector2 acceleration = Vector2.zero;

		if (rigidBody.velocity.magnitude != 0 && inputDirection.x != 0 && !blast) {
			float theta = Mathf.Atan2 (rigidBody.velocity.y, rigidBody.velocity.x);
			theta += -.04f * inputDirection.x;
			Vector2 destVec = new Vector2 (Mathf.Cos (theta), Mathf.Sin (theta));
			acceleration = -Vector3.Cross (rigidBody.velocity,
				Vector3.Cross (rigidBody.velocity, destVec));
			
			acceleration = acceleration.normalized * turnAcceleration;
		}

		if (inputDirection.y != 0  && !blast) {
			Debug.Log ("hello");
			if (rigidBody.velocity.magnitude == 0) {
				float angle = transform.eulerAngles.z;
				Vector2 addition = new Vector2 (Mathf.Cos (angle), Mathf.Sin (angle));
				addition *= moveAmount;
				acceleration += addition;
			} else {
				acceleration += rigidBody.velocity.normalized * moveAmount;
			}
		}

		if (blast) {
			if (rigidBody.velocity.magnitude == 0) {
				float angle = transform.eulerAngles.z;
				Vector2 addition = new Vector2 (Mathf.Cos (angle), Mathf.Sin (angle));
				addition *= blastPower;
				acceleration += addition;
			} else {
				acceleration += rigidBody.velocity.normalized * blastPower;
			}
		}

		rigidBody.AddForce (acceleration);
		if (!noMove) {
			rigidBody.AddForce (-1 * rigidBody.velocity * movingFriction);
		}
		else {
			rigidBody.AddForce(-1 * rigidBody.velocity * friction);
		}

		if (playerStun.isStunned() == true && stunned == false)
		{
			rigidBody.velocity = playerStun.StunVector() * stunPower;
			stunned = true;
		}
		else if (playerStun.isStunned() == false && stunned == true)
		{
			stunned = false;
		}

		Debug.Log ("acceleration: " + acceleration);
		Debug.Log ("velocity: " + rigidBody.velocity);
		Debug.Log ("input direction: " + inputDirection);
	}

	// Update is called once per frame
	void Update () {
		blast = Input.GetButton ("Fire1");
	}
}
