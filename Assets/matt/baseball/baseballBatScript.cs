using UnityEngine;
using System.Collections;

public class baseballBatScript : MonoBehaviour {

	public float batSpeed = 4;
	public float powerMax = 3;
	public float powerStart = 1;
	public float powerGrowthSpeed = 1;
	float power;
	float batTimer;
	bool startBatting;

	// Use this for initialization
	void Start () {
		power = powerStart;
		batTimer = 0f;
		startBatting = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire2")) {
			if (power < powerMax) {
				power += powerGrowthSpeed * Time.deltaTime;
			}
		}
		if (Input.GetButtonUp ("Fire2")) {
			if (batTimer <= 0) {
				batTimer = 1;
				startBatting = true;
			}
		}

		if (batTimer > 0) {
			batTimer -= batSpeed * Time.deltaTime;
		} 
		if (batTimer <= 0) {
			if (startBatting == true) {
				power = powerStart;
				startBatting = false;
			}
		}
	}

	public float Batting () {
		if (batTimer > 0) {
			return power;
		} else {
			return 0;
		}
	}
}
