using UnityEngine;
using System.Collections;

public class ChangeState : MonoBehaviour {

    public GameObject npc;
    public int state1;
    public int state2;
    private StateManager stateManager;
    public string stateName;

    // Use this for initialization
    void Start () {
        stateManager = npc.GetComponentInChildren<StateManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (stateManager.getState(stateName) == state1)
                stateManager.changeState(stateName, state2);
            else if (stateManager.getState(stateName) == state2)
                stateManager.changeState(stateName, state1);
        }
    }
}
