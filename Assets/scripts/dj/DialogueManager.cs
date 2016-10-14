using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour {
	public bool debug;
	public bool testDialogue;

	public Image textboxContainer;
	public Text textbox;

	List<string> dialogueQueue;
	public int prevQueuePosition;
	public int queuePosition;

	void parseDialogue(string dialogue){
		string[] fullCommand;
		fullCommand = dialogue.Split (new char[] { ':' });
		string command = fullCommand[0];
		string parameter = fullCommand [1];

		if(command.Equals("{W}")){
			//Eventually we will add a reader that will read in over a specified time so it will look nicer.
			textbox.text = parameter;
		}
		if (command.Equals ("{M}")) {
			//Change Character mood to parameter

		}
	}

	// Use this for initialization
	void Start () {
		dialogueQueue = new List<string> ();
		prevQueuePosition = -1;
	}

	void Update(){
		if (testDialogue) {
			testDialogue = false;
			StartDialogue("memes.txt");
			parseDialogue (dialogueQueue [queuePosition]);
		}
	}

	public void StartDialogue(string path){
		LoadDialogue (path);
		textboxContainer.enabled = true;
	}

	public void AdvanceDialogue (){
		if (queuePosition >= dialogueQueue.Count - 1) {
			QuitDialogue ();
			return;
		}
		prevQueuePosition = queuePosition;
		queuePosition += 1;
		parseDialogue (dialogueQueue[queuePosition]);
	}

	public void QuitDialogue(){
		textboxContainer.enabled = false;
		textbox.enabled = false;
	}

	void LoadDialogue(string path){
		queuePosition = 0;
		prevQueuePosition = -1;
		StreamReader reader = new StreamReader (path);
		int lineCount = int.Parse(reader.ReadLine ());
		for (int i = 0; i < lineCount; i++) {
			string line = reader.ReadLine ();
			dialogueQueue.Add (line);
			if (debug)
				Debug.Log ("Line " + i + ": " + line);
		}
		reader.Close ();
	}
}
