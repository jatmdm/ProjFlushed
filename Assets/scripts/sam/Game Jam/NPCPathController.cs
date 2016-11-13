using UnityEngine;
using System.Collections;

public class NPCPathController : MonoBehaviour {

    public float travelDist = 2f; //distance the npc travels
    public float moveSpeed = 2f; //npc speed

    public float pathDirection = 0; // angle of npc path

    Vector2 startPos;
    Vector2 endPos;

    float startTime;

    // Use this for initialization
    void Start () {
        float rad = pathDirection * Mathf.Deg2Rad;
        float rotationX = Mathf.Cos(rad) * travelDist;
        float rotationY = Mathf.Sin(rad) * travelDist;
        startPos = new Vector2(transform.position.x + rotationX, transform.position.y + rotationY);
        endPos = new Vector2(transform.position.x - rotationX, transform.position.y - rotationY);
        transform.position = startPos;
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        float distCovered = Mathf.PingPong((Time.time - startTime) * moveSpeed, 1);
        float fracJourney = (distCovered / travelDist * 2);
        transform.position = Vector2.Lerp(startPos, endPos, fracJourney);
    }
}
