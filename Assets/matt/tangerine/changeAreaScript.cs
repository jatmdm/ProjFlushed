using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class changeAreaScript : MonoBehaviour {
	public GameObject[] areaObjects;
	public string[] areaNames;

	Dictionary<string, GameObject> areas = new Dictionary<string, GameObject>();

	GameObject currentArea;

	// Use this for initialization
	void Start () {
		if (areaObjects.Length != areaNames.Length) {
			Debug.Log ("WARNING: A different number of areaObjects and areaNames");
		}

		int i;
		for (i = 0; i < areaObjects.Length; i++) {
			areas.Add (areaNames [i], areaObjects [i]);
			areas [areaNames [i]].SetActive (false);
		}

		currentArea = areas [areaNames [0]];
		currentArea.SetActive (true);

	}

	public void SwitchArea(string areaName) {
		currentArea.SetActive (false);
		currentArea = areas [areaName];
		currentArea.SetActive (true);
	}
}
