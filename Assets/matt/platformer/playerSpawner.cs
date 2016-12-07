using UnityEngine;
using System.Collections;

public class playerSpawner : MonoBehaviour {

	public GameObject player;
	public Transform parent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameObject.FindWithTag ("Player")) {
			Instantiate (player,transform.position, transform.rotation, parent);
		}
	}
}
