using UnityEngine;
using System.Collections;

public class TestPlayerController : MonoBehaviour {

    public float moveSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(xMove, 0, yMove) * moveSpeed * Time.deltaTime;

        transform.position += move;
    }

    void OnCollisionEnter(Collision col) {


    }
}
