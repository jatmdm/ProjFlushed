using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveAmount = 20f;
    public float maxSpeed = 5f;
    public float friction = 5f;
    public float movingFriction = 5f;

    Rigidbody2D rigidBody;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
    }
	
    void FixedUpdate() {
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");
        bool noMove = Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0;

        Vector2 acceleration = new Vector2(hMove, vMove).normalized * moveAmount;

        if (!noMove) {
            rigidBody.AddForce(acceleration);
            rigidBody.velocity = new Vector2(Mathf.Clamp(rigidBody.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(rigidBody.velocity.y, -maxSpeed, maxSpeed));
            rigidBody.AddForce(-rigidBody.velocity.normalized * movingFriction);
        }
        else {
            rigidBody.AddForce(-rigidBody.velocity.normalized * friction);
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
