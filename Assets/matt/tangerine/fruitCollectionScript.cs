using UnityEngine;
using System.Collections;

public class fruitCollectionScript : MonoBehaviour {
	public string fruit;
	// Use this for initialization
	void Start () {
		fruit = "";
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Fruit") {
			fruit = (coll.gameObject.GetComponent<fruitScript>().fruitType);
			Destroy (coll.gameObject);
		}
	}
}
