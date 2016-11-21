using UnityEngine;
using System.Collections;

public class moveBackground : MonoBehaviour {

	public float velocity = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.position;
		newPosition.x -= velocity * Time.deltaTime;
		transform.position = newPosition;
	}
}
