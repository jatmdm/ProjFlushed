using UnityEngine;
using System.Collections;

public class batSwing : MonoBehaviour {

	float swingSpeed;
	float swingPower;
	float maxAngle;
	float inheritAngle;
	float startingAngle;

	bool doIt;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		swingSpeed = 300;
		maxAngle = 80;
		startingAngle = -120;
		inheritAngle = rb.rotation;

		doIt = false;

		//rb.rotation = startingAngle;

		float width = GetComponent<SpriteRenderer> ().sprite.bounds.extents.x;
		rb.centerOfMass = new Vector2 (-2 * width, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButton ("Fire1") && !doIt) {
			rb.rotation -= Mathf.Abs (rb.rotation - startingAngle) * Time.deltaTime;
		}
		if (Input.GetButtonUp ("Fire1") && !doIt) {
			doIt = true;
			swingSpeed = Mathf.Abs (maxAngle - rb.rotation) * 15;
		}

		if (doIt) {
			rb.angularVelocity += swingSpeed * Time.deltaTime;

			if (rb.rotation > inheritAngle + maxAngle) {
				Destroy (gameObject);
			}
		}

		rb.position = transform.parent.gameObject.GetComponent<Rigidbody2D> ().position;
	}
}
