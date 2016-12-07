using UnityEngine;
using System.Collections;

public class doorScript : MonoBehaviour {
	public string destination;

	changeAreaScript areaManager;

	// Use this for initialization
	void Start () {
		areaManager = GameObject.FindGameObjectWithTag ("Area Manager").GetComponent<changeAreaScript>();
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			areaManager.SwitchArea (destination);
		}
	}
}
