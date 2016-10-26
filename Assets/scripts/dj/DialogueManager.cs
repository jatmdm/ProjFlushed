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
	Dictionary<string, int> tags;
	public int prevQueuePosition;
	public int queuePosition;

	/// <summary>
	/// Parses the dialogue.
	/// </summary>
	/// <param name="dialogue">Dialogue.</param>
	void parseDialogue(string dialogue){
		//Comment code
		if(dialogue.StartsWith("--")) AdvanceDialogue();

		string[] fullCommand;
		fullCommand = dialogue.Split (new char[] { ':' });
		string command = fullCommand[0];
		string parameter = fullCommand [1];

		if (command.Equals ("Write") || command.Equals ("write")) {
			//Eventually we will add a reader that will read in over a specified time so it will look nicer.
			textbox.text = parameter;
		} else if (command.Equals ("Mood") || command.Equals ("mood")) {
			//Change Character mood to parameter

		} else if (command.Equals ("Animate") || command.Equals ("animate")) {
			//Do the animation in the parameter
		} else if (command.Equals ("Goto") || command.Equals ("goto")) {
			//Goto line at parameter (the tag is the parameter)
			AdvanceDialogue(parameter);
		} else if (command.Equals ("Choice") || command.Equals ("choice")) {
			//Need to think about this infrastructure.

		} else if (command.Equals ("Tag") || command.Equals ("tag")) {
			//Skip
			AdvanceDialogue();
		}
	}

	// Use this for initialization
	void Start () {
		Reset (); //initializes everything
	}

	/// <summary>
	/// Reset this instance.
	/// </summary>
	void Reset() {
		dialogueQueue = new List<string> ();
		tags = new Dictionary<string, int> ();
		prevQueuePosition = -1;
		queuePosition = 0;
	}

	void Update(){
		//Test Button that starts dialogue.
		if (testDialogue) {
			testDialogue = false;
			StartDialogue("memes.txt");
			parseDialogue (dialogueQueue [queuePosition]);
		}
	}

	/// <summary>
	/// Starts the dialogue.
	/// </summary>
	/// <param name="path">Path.</param>
	public void StartDialogue(string path){
		LoadDialogue (path);
		textboxContainer.enabled = true;
	}

	/// <summary>
	/// Advances the dialogue.
	/// </summary>
	public void AdvanceDialogue (){
		if (queuePosition >= dialogueQueue.Count - 1) {
			QuitDialogue ();
			return;
		}
		prevQueuePosition = queuePosition;
		queuePosition += 1;
		parseDialogue (dialogueQueue[queuePosition]);
	}

	/// <summary>
	/// Advances the dialogue.
	/// </summary>
	/// <param name="tag">Tag.</param>
	public void AdvanceDialogue(string tag){
		prevQueuePosition = queuePosition;
		queuePosition = tags [tag];
		parseDialogue (dialogueQueue [queuePosition]);
	}
	/// <summary>
	/// Quits the dialogue.
	/// </summary>
	public void QuitDialogue(){
		textboxContainer.enabled = false;
		textbox.enabled = false;
		Start ();
	}

	/// <summary>
	/// Loads the dialogue.
	/// </summary>
	/// <param name="path">Path.</param>
	void LoadDialogue(string path){
		queuePosition = 0;
		prevQueuePosition = -1;
		StreamReader reader = new StreamReader (path);
//		int lineCount = int.Parse(reader.ReadLine ());
//		for (int i = 0; i < lineCount; i++) {
//			string line = reader.ReadLine ();
//			dialogueQueue.Add (line);
//			if (debug)
//				Debug.Log ("Line " + i + ": " + line);
//		}
//
		int lineNum = 0;
		while (reader.Peek () > -1) {
			string line = reader.ReadLine ();
			string[] fullCommand;
			fullCommand = line.Split (new char[] { ':' });
			string command = fullCommand[0];
			string parameter = fullCommand [1];
			if (command == "Tag" || command == "tag") {
				tags.Add (parameter, lineNum);
			}
			dialogueQueue.Add (line);
			lineNum++;
		}
		reader.Close ();
	}
}
