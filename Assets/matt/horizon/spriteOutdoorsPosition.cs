using UnityEngine;
using System.Collections;

public class spriteOutdoorsPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (transform.parent.position);
	}
}
