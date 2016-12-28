using UnityEngine;
using System.Collections;

public class baseballBatActivator : MonoBehaviour {

	public float batRecoverySpeed = 1;
	public float batChargeSpeed = 1;
	public float maxCharge = 1;

	float charge;
	float recovery;


	// Use this for initialization
	void Start () {
		charge = 0;
		recovery = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1") && recovery >= 1 && charge < 1) {
			if (charge < 1) {
				charge += batChargeSpeed * Time.deltaTime;
			}
			if (charge > 1) {
				charge = 1;
			}
		}
		if (Input.GetButtonUp ("Fire1")) {
			if (charge > .1) {     // Require the bat to be held for a minimum amount of time
				ActivateBat (charge * maxCharge);
				charge = 0;
				recovery = 0;
			} else {
				charge = 0;
			}
		}

		if (recovery < 1) {
			recovery += batRecoverySpeed * Time.deltaTime;
		}
		if (recovery > 1) {
			recovery = 1;
		}
	}

	void ActivateBat (float power) {
		Debug.Log (power);
	}
}
