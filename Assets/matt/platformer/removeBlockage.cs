using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class removeBlockage : MonoBehaviour {
	public GUIStyle textStyle;
	float speed = 5f;
	public float counter = 5;

	bool unblocked;
	Vector2 pos;
	Vector2 size;


	// Use this for initialization
	void Start () {
		unblocked = false;
		pos = new Vector2 (Screen.width, 3 * Screen.height / 4);
		size = new Vector2 (Screen.width, Screen.height / 10);

		speed = Screen.width / 4;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			unblocked = true;
		}
	}

	// Update is called once per frame
	void Update () {
		if (unblocked) {
			pos.x -= speed * Time.deltaTime;
			counter -= Time.deltaTime;
		}
		Debug.Log (counter);
		if (counter <= 0) {
			SceneManager.LoadScene ("town");
		}
	}

	void OnGUI() {
		if (unblocked) {
			GUI.Label (new Rect (pos, size), "Mental Blockage Removed"); 
		}
	}
}
