using UnityEngine;
using System.Collections;

public class DisplayDialogueScript : MonoBehaviour {
	public GUIStyle textStyle;

	public GameStateScript gameState;

	bool newDialogue;
	bool finished;
	int dialogueIndex;
	float dialogueTimer;
	string displayText;

	public float dialogueSpeed = .9f;



	private class DialogueClass {
		public string text;
		public Rect rect;


		public DialogueClass (string dialogue) {
			// Based on the size of the dialogue, determine how big the rect should be,
			// where to place it, and where to put line breaks in the text

			//int height = textStyle.CalcHeight();

			this.text = dialogue;
			this.rect = new Rect(Screen.width / 2 - 200, Screen.height * 0.60f - 50 / 2, 500, 100);
		}
	}

	private class ChoiceClass {
		public string text;
		public Rect rect;

		public ChoiceClass (string choice, int choiceIndex) {
			if (choiceIndex > 3 || choiceIndex < 1) {
				Debug.LogError ("The maximum choice index is 3. The minimum is 1. Your choice's index is " + choiceIndex);
			}
			else {
				// Format choice text and position by length and choice index
				this.text = choice;

				this.rect = new Rect(0, 0, Screen.width/5, 20);



				if (choiceIndex == 1) {
					this.rect.x = Screen.width / 3 - this.rect.width/2;
					this.rect.y = Screen.height * 0.75f;
				}
				else if (choiceIndex == 2) {
					this.rect.x = Screen.width * 0.66f - this.rect.width/2;
					this.rect.y = Screen.height * 0.75f;
				}
				else if (choiceIndex == 3) {
					this.rect.x = Screen.width / 2 - this.rect.width/2;
					this.rect.y = Screen.height * 0.825f;
				}


			}
		}
	}

	private DialogueClass dialogue;
	private ChoiceClass choice1;
	private ChoiceClass choice2;
	private ChoiceClass choice3;

	private Texture portrait;
	private Rect portraitRect;

	private bool monologue;

	// Use this for initialization
	void Start () {
		newDialogue = false;
		finished = false;
		dialogueIndex = 0;
		dialogueTimer = 0;

		dialogue = new DialogueClass ("");
	}
	
	// Update is called once per frame
	void Update () {
		if (finished == false && newDialogue == true) {
			if (dialogueTimer <= 0) {
				dialogueTimer = 1;
				if (dialogueIndex < dialogue.text.Length) {
					displayText += dialogue.text[dialogueIndex];
					/* Play boop sound effect */
					AudioSource audio = GetComponent<AudioSource>();
					if (dialogue.text[dialogueIndex] != ' ' && dialogue.text[dialogueIndex] != '\n') {
						audio.Play();
					}
					dialogueIndex++;
				} else {
					finished = true;
					newDialogue = false;
					dialogueIndex = 0;
				}
			} else {
				// Decrement timer
				dialogueTimer -= Time.deltaTime * dialogueSpeed;
			}
		}
		else {
			displayText = dialogue.text;
		}
	}


	public void NewChoice (string words, string option1, string option2, string option3) {
		dialogue = new DialogueClass (words);
		monologue = false;
		newDialogue = true;
		finished = false;
		displayText = "";

		// Choice 1 and choice 2 are required. Choice 3 is optional. Max of 3 choices
		choice1 = new ChoiceClass (option1, 1);
		choice2 = new ChoiceClass (option2, 2);
		choice3 = new ChoiceClass (option3, 3);
	}

	public void NewMonologue(string words) {
		dialogue = new DialogueClass (words);

		newDialogue = true;
		finished = false;
		displayText = "";

		monologue = true;
	}


	public void SetPortrait (Texture pic) {
		portrait = pic;

		float height = Screen.height * .75f;
		float width = height;
		float x = (Screen.width  - width) / 2; 
		float y = (Screen.height  - height) / 2 - Screen.height / 4f;
		portraitRect = new Rect (x, y, width, height);
	}

	void OnGUI() {
		if (gameState.CurrentState () == "Dialogue") {
			GUI.Label (portraitRect, portrait, textStyle);
			GUI.Label (dialogue.rect, displayText, textStyle);
			if (!monologue) {
				if (finished) {
					GUI.Label (choice1.rect, choice1.text, textStyle);
					GUI.Label (choice2.rect, choice2.text, textStyle);
					GUI.Label (choice3.rect, choice3.text, textStyle);
				}
			} else {
				// Center "..." where the choices would be
				if (finished) {
					GUI.Label (new Rect(Screen.width / 2 - 25, Screen.height * 0.75f, 50, 20), "...", textStyle);
				}
			}
		}
	}

	public bool isFinished() {
		return finished;
	}

	public void FinishNow() {
		finished = true;
		newDialogue = false;
		dialogueIndex = 0;
	}
}