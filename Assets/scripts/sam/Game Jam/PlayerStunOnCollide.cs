using UnityEngine;
using System.Collections;

public class PlayerStunOnCollide : MonoBehaviour {

    BoxCollider2D player;

    BoxCollider2D thisCollider;

    public float haltLength = 2.5f;
    private float timer;

    Vector2 prevPosition;

    StunController playerStun;

    // Use this for initialization
    void Start()
    {
        thisCollider = GetComponent<BoxCollider2D>();

        playerStun = GameObject.Find("player").GetComponent<StunController>();

        player = GameObject.Find("player").GetComponent<BoxCollider2D>();

        timer = 0;

        prevPosition = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = new Vector2(transform.position.x - prevPosition.x,
                                         transform.position.y - prevPosition.y);


        if (thisCollider.IsTouching(player))
        {
            timer = haltLength;
            playerStun.Stun(direction);
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public bool isHalted()
    {
        return timer > 0;
    }
}
