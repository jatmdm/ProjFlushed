using UnityEngine;
using System.Collections;

public class StunController : MonoBehaviour {

    private float timer;
    public float stunLength = 1f;

    private Vector2 stunVector;

    // Use this for initialization
    void Start()
    {
        timer = 0;
        stunVector = Vector2.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

    }

    public void Stun(Vector2 stunDirection)
    {
        timer = stunLength;
        stunVector = stunDirection.normalized;
    }

    public bool isStunned()
    {
        return timer > 0;
    }
    public Vector2 StunVector()
    {
        return stunVector;
    }
}
