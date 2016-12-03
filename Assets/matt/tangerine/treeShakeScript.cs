using UnityEngine;
using System.Collections;

public class treeShakeScript : MonoBehaviour {

	public fruitScript fruit;

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			fruit.fall ();
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
