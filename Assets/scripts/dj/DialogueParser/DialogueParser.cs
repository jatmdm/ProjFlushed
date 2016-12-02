using UnityEngine;
using UnityEngine.UI;

public struct DialogueData {
	private string characterName;
	private Color characterColor;
	private string text;
	private Font font;

	public string CharacterName {
		get {
			return characterName;
		}
		set {
			characterName = value;
		}
	}

	public string Text {
		get {
			return text;
		}
		set {
			text = value;
		}
	}

	public Color CharacterColor {
		get {
			return characterColor;
		}
		set {
			characterColor = value;
		}
	}

	public Font TextFont{
		get{
			return font;
		}
		set {
			font = value;
		}
	}

}

public class DialogueParser {

	private static DialogueParser instance;


	private DialogueParser () {}

	public static DialogueParser Instance {
		get {
			if (instance == null) {
				instance = new DialogueParser ();
			}
			return instance;
		}
	}

	public DialogueData Parse(string data) {
		DialogueData ret = new DialogueData();
		string[] splitData = data.Split(':');

		ret.CharacterName = splitData [0];

		string[] colorTemp;
		int r, g, b;
		colorTemp = splitData [1].Split (',');
//		r = int .Parse(colorTemp [0]);
//		g = int.Parse(colorTemp [1]);
//		b = int.Parse(colorTemp [2]);

		ret.Text = splitData [2];

		return ret;
	}

}
