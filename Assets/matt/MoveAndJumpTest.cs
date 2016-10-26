using UnityEngine;
using System.Collections;

public class MoveAndJumpTest : MonoBehaviour {

	public float turnSpeed = 100f;
	public float accelerationRange = 1.5f;
	public float acceleration = 2f;
	public float maxSpeed = 10f;
	public float staticFriction = .08f;
	public float relativeFriction = .03f;
	public float brakePower = .5f;
	public float stunPower = 4;

	Rigidbody2D rb;
	StunController playerStun;

	float inputTheta;
	float inputMagnitude;

	bool stunned;
	bool brake;

	// Takes an angle in radians and converts it to be between 0 and 2pi
	float FixAngle (float theta) {
		float angle = theta;

		while (angle >= 2 * Mathf.PI) {
			angle -= 2 * Mathf.PI;
		}
		while (angle < 0) {
			angle += 2 * Mathf.PI;
		}

		return angle;
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		playerStun = GetComponent<StunController>();
		inputTheta = 0;
		inputMagnitude = 0;

		stunned = false;
		rb.velocity = new Vector2 (0, 0);
	}

	void FixedUpdate() {
		float velocityTheta = Mathf.Atan2 (rb.velocity.y, rb.velocity.x);
		float deltaTheta = FixAngle (velocityTheta - inputTheta); // The difference between the destination angle and the velocity angle

		// If the stick is held down, turn and speed up
		if (inputMagnitude > 0.05f) {
			float rotation = (deltaTheta > Mathf.PI / 2) ? (turnSpeed * Mathf.PI / 2) : (deltaTheta * turnSpeed);
			rotation *= Time.deltaTime;

			// Turn clockwise if the difference is greater than pi, otherwise rotate counter clockwise
			if (deltaTheta >= Mathf.PI && deltaTheta < 2 * Mathf.PI) {
				rb.velocity = Quaternion.Euler (0, 0, rotation) * rb.velocity;
			} else if (deltaTheta > 0 && deltaTheta < Mathf.PI) {
				rb.velocity = Quaternion.Euler (0, 0, -rotation) * rb.velocity;
			}

			// Accelerate when close enough to intended direction and when under max speed
			if (deltaTheta <= accelerationRange && rb.velocity.magnitude < maxSpeed) {
				rb.velocity += rb.velocity.normalized * acceleration * Time.deltaTime;
			}

			// If at a standstill, accelerate in the input direction
			if (rb.velocity.magnitude == 0) {
				
				rb.velocity = Quaternion.Euler (0, 0, Mathf.Rad2Deg * inputTheta) * Vector2.right * acceleration * Time.deltaTime;
			}
		}

		// Apply static friction, which is always the same value
		if (rb.velocity.magnitude > staticFriction * Time.deltaTime) {
			rb.velocity -= rb.velocity.normalized * staticFriction * Time.deltaTime;
		}
		// Apply relative friction, which scales with velocity
		rb.velocity -= rb.velocity.normalized * relativeFriction * rb.velocity.magnitude * Time.deltaTime;

		// If the brake key is down, brake!
		if (brake) {
			Debug.Log ("Break!");
			rb.velocity -= rb.velocity.normalized * brakePower * rb.velocity.magnitude * Time.deltaTime;
		}

		if (playerStun.isStunned() == true && stunned == false)
		{
			rb.velocity = playerStun.StunVector() * stunPower;
			stunned = true;
		}
		else if (playerStun.isStunned() == false && stunned == true)
		{
			stunned = false;
		}

		Debug.Log(" Velocity: " + rb.velocity);
	}

	// Update is called once per frame
	void Update () {
		inputTheta = Mathf.Atan2 (Input.GetAxis ("Vertical"), Input.GetAxis ("Horizontal"));

		inputMagnitude = Mathf.Sqrt (Mathf.Pow(Input.GetAxis ("Vertical"), 2) + Mathf.Pow(Input.GetAxis ("Horizontal"), 2));

		brake = Input.GetButton ("Fire1");
	}
}
