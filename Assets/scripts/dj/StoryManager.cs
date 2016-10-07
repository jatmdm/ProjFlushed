using UnityEngine;
using System.Collections;
using System.Collections.Generic;


enum ConditionState { NotSeen = 0, NotChosen = 1, Chosen = 2};

public class StoryManager : MonoBehaviour {
	public Dictionary<string, int> storyConditions;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LoadStory(){
		
	}
	void SaveStory(){
		//Top of the file is "metadata"
		for (int i = 0; i < storyConditions.Count; i++) {
			//Put each condition as CONDITION:STATE
		}
	}
}
