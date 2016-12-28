using UnityEngine;
using System.Collections;

public class baseballBatScript : MonoBehaviour {

	float power;
	float maxPower;

	float maxAngle;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		power = 20f;
		maxPower = 10f;

		rb = GetComponent<Rigidbody2D> ();
		float maxAngle = (power / maxPower) * 90 + 30;
		rb.angularVelocity = power;
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.rotation >= maxAngle) {
			//rb.angularVelocity = 0;

			//Destroy (gameObject);
		}
		Debug.Log (rb.rotation);
	}
}
