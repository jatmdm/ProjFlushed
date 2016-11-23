using UnityEngine;
using System.Collections;

public class throwBaseball : MonoBehaviour {

	public float period = 5;
	public GameObject baseball;

	float timer;

	// Use this for initialization
	void Start () {
		timer = period;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;

		if (timer <= 0) {
			timer = period;
			Instantiate (baseball, transform.position, transform.rotation, transform);
		}
	}
}
