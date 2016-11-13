using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {

    DialogueManager dialogue;

	// Use this for initialization
	void Start () {
        dialogue = GameObject.Find("Game Manager").GetComponent<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.name == "testPlayer") {
            Debug.Log("dnlinf");
            dialogue.testDialogue = true;
            dialogue.showDialogue = true;
        }

    }
}
