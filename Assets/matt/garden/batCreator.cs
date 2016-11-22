using UnityEngine;
using System.Collections;

public class batCreator : MonoBehaviour {

	public GameObject bat;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			batSwing[] bats = gameObject.GetComponentsInChildren<batSwing> ();
			if (bats.Length == 0) {
				Vector3 batPosition = transform.position;
				//batPosition.x += bat.GetComponent<SpriteRenderer> ().bounds.extents.x;
				Instantiate (bat, batPosition, transform.rotation, transform);
			}
		}
	}
}
