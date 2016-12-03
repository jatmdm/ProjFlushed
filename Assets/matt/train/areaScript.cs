using UnityEngine;
using System.Collections;

public class areaScript : MonoBehaviour {

	bool active;

	// Use this for initialization
	void Start () {
		active = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "Player") {
			active = true;
		}
	}
}
