using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour {

    public string npcName;
    public StoryManager storyManager;
    public int initialState;

	// Use this for initialization
	void Start ()
    {
        storyManager.storyConditions.Add(npcName, initialState);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public int getState ()
    {
        int state = (int)storyManager.storyConditions[npcName];
        return state;
    }

    public void changeState (int newState)
    {
        storyManager.ChangeConditionState(npcName, newState);
    }
}
