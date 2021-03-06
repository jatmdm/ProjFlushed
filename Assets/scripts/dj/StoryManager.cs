﻿using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;


public enum ConditionState { NotSeen = 0, NotChosen = 1, Chosen = 2};

public class StoryManager : MonoBehaviour {
	public Dictionary<string, int> storyConditions;
	public bool load;
    public bool save;
    public bool change;
    public string changeString;

    public bool debug;

	// Use this for initialization
	void Start () {
        debug = true; //Rememebr to change before release.
		load = false;
        save = false;
        change = false;
		storyConditions = new Dictionary<string, int> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (load) {
			load = false;
			LoadStory ();
		}
        if (save)
        {
            save = false;
            SaveStory();
        }
        if (change)
        {
            change = false;
            storyConditions[changeString] = 0;
        }
	}

    public void ChangeConditionState(string key, int value)
    {
        if (!storyConditions.ContainsKey(key))
        {
            Debug.LogError("Error when trying to change condition state. Key: " + key + " does not exist.");
        }
        else
        {
            storyConditions[key] = value;
            
        }
    }

    public List<KeyValuePair<string, int>> ConditionCollection(string list)
    {
        List<KeyValuePair<string, int>> collection = new List<KeyValuePair<string, int>>();
        
        return collection;
    }

	void printStory(){
		foreach (KeyValuePair<string, int> kv in storyConditions) {
			Debug.Log (kv.Key + ":" + kv.Value);
		}
	}
	void LoadStory(){
        float startTime, endTime;
		StreamReader reader = new StreamReader ("story.dat");
		string line, key;
		int value;
        startTime = Time.timeSinceLevelLoad;
        storyConditions = new Dictionary<string, int>();
		line = reader.ReadLine ();
		int count = int.Parse(line);
        
		for (int i = 0; i < count; i++) {
			line = reader.ReadLine ();
			key = line.Split (new char[] {':'})[0];
			value = int.Parse(line.Split (new char[] {':'})[1]);
			storyConditions.Add (key, value);
		}
        reader.Close();
        endTime = Time.timeSinceLevelLoad;
        if(debug) Debug.Log("STORY LOADED IN " + (startTime - endTime) + "ms");
		printStory ();
	}
	void SaveStory(){
		StreamWriter writer = new StreamWriter ("story.dat");

		//Top of the file is "metadata"
		writer.WriteLine(storyConditions.Count);
		foreach (KeyValuePair<string, int> kv in storyConditions){
			//Put each condition as CONDITION:STATE
			string line = "";
			line = kv.Key + ":" + kv.Value;
            if (debug) Debug.Log(line);
			writer.WriteLine (line);
		}
        writer.Close();
        Debug.Log("Successfully saved story.");
	}
}
