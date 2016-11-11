using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateManager : MonoBehaviour {

    public List<string> stateNameList;
    const int DEFAULT_VALUE = 0;
    public string npcName;
    public StoryManager storyManager;
    public int initialState;

	// Use this for initialization
	void Start ()
    {
        storyManager.storyConditions.Add(npcName, initialState);

        for (int i = 0; i < stateNameList.Count; i++)
        {
            storyManager.storyConditions.Add(stateNameList[i], DEFAULT_VALUE);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public int getState (string stateName)
    {
        int state = storyManager.storyConditions[stateName];
        return state;
    }

    public void changeState (string stateName, int newValue)
    {
        storyManager.ChangeConditionState(stateName, newValue);
    }
}
