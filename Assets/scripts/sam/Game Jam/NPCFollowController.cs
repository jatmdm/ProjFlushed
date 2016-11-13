using UnityEngine;
using System.Collections;

public class NPCFollowController : MonoBehaviour {

    public float moveSpeed = 2f;
    public float sightRadius = 3f;

    bool followingPlayer = false;

    GameObject player;
    Rigidbody2D rigidBody;
    CircleCollider2D circle;
    PlayerStunOnCollide halt;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("testPlayer");

        circle = GetComponent<CircleCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        circle.radius = sightRadius;

        halt = GetComponent<PlayerStunOnCollide>();

    }

    // Update is called once per frame
    void Update()
    {
        //npc follows player if in range
        if (followingPlayer && !halt.isHalted())
        {
            float step = moveSpeed * Time.deltaTime;
            Vector2 moveToPlayer = Vector2.MoveTowards(transform.position, player.transform.position, step);
            transform.position = moveToPlayer;
            circle.transform.position = moveToPlayer;
        }
    }

    //checks if the player is within the npc's sight
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "testPlayer")
        {
            followingPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {

        if (coll.gameObject.name == "testPlayer")
        {
            followingPlayer = false;
            rigidBody.velocity = new Vector2(0, 0);
        }

    }
}
