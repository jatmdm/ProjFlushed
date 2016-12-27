using UnityEngine;
using System.Collections;

public class CameraSwitchStatesScript : MonoBehaviour {

	GameStateScript gameState;


	// Use this for initialization
	void Start () {
		gameState = GameObject.Find ("GameState").GetComponent<GameStateScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameState.CurrentState() == "Overworld") {
			transform.rotation = Quaternion.Euler (0, 0, 0);
		} else if (gameState.CurrentState() == "Dialogue") {
			transform.rotation = Quaternion.Euler (180, 0, 0);
		}
	}
}
