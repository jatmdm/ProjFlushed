using UnityEngine;
using System.Collections;

public class playerKillScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -12) {
			Destroy (gameObject);
		}
	}
}
