using UnityEngine;
using System.Collections;

public class CheckState : MonoBehaviour {

    public GameObject npc;
    private StateManager stateManager;

	// Use this for initialization
	void Start ()
    {
        stateManager = npc.GetComponentInChildren<StateManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "Player")
        {
            string msg = stateManager.name + " has state " + stateManager.getState();
            Debug.Log(msg);
        }
    }
}
