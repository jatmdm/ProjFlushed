using UnityEngine;
using System.Collections;

public class fruitScript : MonoBehaviour {

	public float fallHeight;
	public float speed;
	public string fruitType;

	bool fallen;
	float finalY;

	// Use this for initialization
	void Start () {
		fallen = false;

		finalY = transform.position.y - fallHeight;
	}
	
	// Update is called once per frame
	void Update () {
		if (fallen == true && transform.position.y > finalY) {
			Vector2 newPosition = new Vector2 (transform.position.x, transform.position.y - speed * Time.deltaTime);
			transform.position = newPosition;
		}
	}

	public void fall() {
		fallen = true;


	}

	public bool isFallen() {
		return fallen;
	}
}
