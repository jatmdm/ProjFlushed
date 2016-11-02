using UnityEngine;
using System.Collections;

public class linearMotion : MonoBehaviour {

	public float speed = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 velocity = new Vector2(Input.GetAxis ("Horizontal"), Input.GetAxis("Vertical"));

		GetComponent<Rigidbody2D> ().velocity = velocity * speed;
	}
}
