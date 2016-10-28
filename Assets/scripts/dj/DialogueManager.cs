using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour {
	[SerializeField]
	private TextAsset inkFile;
	private Story story;

	[SerializeField]
	private Canvas canvas;

	//UI
	[SerializeField]
	private Text textBoxPrefab;
	[SerializeField]
	private Button choiceButtonPrefab;


	//Debug Bools
	public bool start;
	public bool load;

	void LoadStory(TextAsset targetFile){
		story = new Story (targetFile.text);
	}

	void StartDialogue(){
		RefreshView ();
	}

	void EndDialogue(){
		story = null;
		DestroyChildren ();
	}

	void RefreshView () {
		DestroyChildren ();
		Text content = null;
		while (story.canContinue) {
			string text = story.Continue ().Trim ();
			content = CreateContentView (text);
		}

		if (story.currentChoices.Count > 0) {
			for (int i = 0; i < story.currentChoices.Count; i++) {
				Choice choice = story.currentChoices [i];
				Button button = CreateChoiceButton (choice.text.Trim (), content.transform);
				button.onClick.AddListener (
					delegate {
						OnClickChoiceButton (choice);
					}
				);
			}
		} else {
			Button choice = CreateChoiceButton ("....[continue]", content.transform);
			choice.onClick.AddListener (
				delegate {
					EndDialogue();
				}
			);
		}
	}

	void OnClickChoiceButton (Choice choice){
		story.ChooseChoiceIndex (choice.index);
		RefreshView ();
	}

	Text CreateContentView(string text) {
		Text storyText = Instantiate (textBoxPrefab) as Text;
		storyText.text = text;
		storyText.transform.SetParent (canvas.transform, false);

		return storyText;
	}

	Button CreateChoiceButton (string text, Transform parent) {
		Button choice = Instantiate (choiceButtonPrefab) as Button;
		choice.transform.SetParent (parent, false);

		Text choiceText = choice.GetComponentInChildren<Text> ();
		choiceText.text = text;

		HorizontalLayoutGroup layoutGroup = choice.GetComponent <HorizontalLayoutGroup> ();
		layoutGroup.childForceExpandHeight = false;

		return choice;
	}

	void DestroyChildren(){
		for(int i = canvas.transform.childCount - 1; i >= 0; --i){
			GameObject.Destroy (canvas.transform.GetChild(i).gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (start) {
			start = false;
			StartDialogue ();
		}

		if (load) {
			load = false;
			LoadStory (inkFile);
		}
	}
}
