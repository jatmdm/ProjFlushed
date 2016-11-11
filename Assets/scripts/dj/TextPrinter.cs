using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextPrinter : MonoBehaviour {

	private float readTime;
	public float readTimeMax; //How long to wait to print a character
	public float readInterval;

	private string loadedText;
	public int textIndex;

	public bool read;
	public bool loaded;
	private bool finished;

	[SerializeField]
	public Text textComponent;

	void Awake() {
		textComponent = gameObject.GetComponent<Text> ();
		ResetText ();
	}
	
	// Update is called once per frame
	void Update () {
		if (textComponent.text.Equals (loadedText)) {
			finished = true;
			read = false;
		}

		if (!textComponent.text.Equals (loadedText) && readTime <= 0 && read && !finished) {
			textComponent.text += loadedText[textIndex];
			textIndex++;
		}

		if (read && !finished) {
			readTime -= Time.deltaTime;
		}

		if (readTime <= 0) {
			readTime = readTimeMax;
		}
			
	}

	public void ResetText(){
		textIndex = 0;
		textComponent.text = "";
		loadedText = "";
		readTime = readTimeMax;
		loaded = false;
		read = false;
		finished = false;
	}

	public void LoadText(string textToLoad) {
		loadedText = textToLoad;
	}

	public void StartRead(){
		read = true;
	}
		
}
