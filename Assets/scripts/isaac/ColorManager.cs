using UnityEngine;
using System.Collections;

public class ColorManager : MonoBehaviour {

    public StateManager stateManager;
    public SpriteRenderer spriteRenderer;
    public int lastState;

	// Use this for initialization
	void Start () {
        stateManager = GetComponentInChildren<StateManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastState = stateManager.getState();
	}
	
	// Update is called once per frame
	void Update () {
        int newState = stateManager.getState();
        if (newState != lastState)
        {
            changeColor(newState);
            lastState = newState;
        }
	}

    private void changeColor (int state)
    {
        if (state == 0)
        {
            spriteRenderer.color = Color.green;
        }
        else if (state == 1)
        {
            spriteRenderer.color = Color.red;
        }
    }
}
