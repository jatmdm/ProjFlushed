using UnityEngine;
using System.Collections;

public class GameStateScript : MonoBehaviour {
	public float lengthOfSafety; // How long to wait after an interaction until another interaction can happen
	private float timer;

	public int arcState = 0;
	public bool finished = false;

	private string gameState;
	private string interlocutor;
	private string musicState;

	public string startingMusic;

	fruitCollectionScript fruitScript;


	// Use this for initialization
	void Start () {
		if (GameObject.FindGameObjectsWithTag ("GameController").Length > 1) {
			Destroy (gameObject);
		}
		gameState = "Overworld";
		musicState = startingMusic;

		DontDestroyOnLoad(transform.gameObject);
		fruitScript = GameObject.FindWithTag ("Player").GetComponent<fruitCollectionScript> ();
	}

	// Update is called once per frame
	void Update () {
		if (timer > 0) {
			timer -= Time.deltaTime;
		}
	}

	public void Overworld() {
		gameState = "Overworld";
		musicState = "Overworld";
		timer = lengthOfSafety;
		interlocutor = "No one";
	}

	public void Dialogue() {
		if (timer <= 0) {
			gameState = "Dialogue";
			//world.SetActive (false);
		}
	}

	public string CurrentState() {
		return gameState;
	}

	public bool Safe() {
		return timer > 0;
	}

	public void SetInterlocutor(string name) {
		interlocutor = name;
	}

	public string GetInterlocutor() {
		return interlocutor;
	}

	public int GetArcState() {
		return arcState;
	}

	public void IncrementArc() {
		arcState++;
	}
	public void SetMusicState(string name) {
		musicState = name;
	}
	public string GetMusicState() {
		return musicState;
	}

	public string GetFruit() {
		return fruitScript.fruit;
	}
}
