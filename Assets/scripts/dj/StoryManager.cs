﻿using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;


enum ConditionState { NotSeen = 0, NotChosen = 1, Chosen = 2};

public class StoryManager : MonoBehaviour {
	public Dictionary<string, int> storyConditions;
	public bool load;

	// Use this for initialization
	void Start () {
		load = false;
		storyConditions = new Dictionary<string, int> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (load) {
			load = false;
			LoadStory ();
		}
	}

	void printStory(){
		foreach (KeyValuePair<string, int> kv in storyConditions) {
			Debug.Log (kv.Key + ":" + kv.Value);
		}
	}

	void LoadStory(){
		StreamReader reader = new StreamReader ("story.dat");
		string line, key;
		int value;
		line = reader.ReadLine ();
		int count = int.Parse(line);

		for (int i = 0; i < count; i++) {
			line = reader.ReadLine ();
			key = line.Split (new char[] {':'})[0];
			value = int.Parse(line.Split (new char[] {':'})[1]);
			storyConditions.Add (key, value);
		}
		printStory ();
	}
		
	void SaveStory(){
		StreamWriter writer = new StreamWriter ("story.dat");

		//Top of the file is "metadata"
		writer.WriteLine(storyConditions.Count);
		foreach (KeyValuePair<string, int> pair in storyConditions){
			//Put each condition as CONDITION:STATE
			string line = "";
			line = pair.Key + ":" + pair.Value;
			writer.WriteLine (line);
		}
	}
}
