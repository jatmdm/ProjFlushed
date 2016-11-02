using UnityEngine;
using System.Collections;

public class baseballScript : MonoBehaviour {

	Rigidbody2D rb;
	public Vector2 velocity;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = velocity;
	}

	void OnCollisionEnter2D (Collision2D other) {
		Debug.Log ("hello");
		if (other.gameObject.tag == "Player") {
			float power = other.gameObject.GetComponent<baseballBatScript> ().Batting ();
			Vector2 velocity = other.gameObject.GetComponent<Rigidbody2D> ().velocity;
			if (power > 0) {
				if (velocity.magnitude > 1) {
					rb.velocity = power * other.gameObject.GetComponent<Rigidbody2D> ().velocity;
				} else {
					rb.velocity = -rb.velocity;
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
