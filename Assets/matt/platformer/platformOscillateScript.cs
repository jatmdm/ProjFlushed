using UnityEngine;
using System.Collections;

public class platformOscillateScript : MonoBehaviour {

	public float switchSpeed;
	public float velocity;

	float timer;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0) {
			rb.velocity = Vector2.up * velocity;
		} else {
			rb.velocity = Vector2.down * velocity;
		}

		if (timer <= -1) {
			timer = 1;
		}

		timer -= switchSpeed * Time.deltaTime;
	}
}
