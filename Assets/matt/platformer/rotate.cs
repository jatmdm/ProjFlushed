using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

	public float amplitude;
	public float omega;

	float timer;

	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		Vector3 rotation = new Vector3 (0, 0, amplitude * omega * Mathf.Cos (omega * timer));

		transform.Rotate(rotation);
	}
}
