using UnityEngine;
using System.Collections;

public class GatheringNPCController : MonoBehaviour {

    public Transform followPoint;
    public float minPlayerDistance;
    NavMeshAgent navComponent;
    GameObject player;
    bool dispersing, pointFound;
    Vector3 point;
    Vector3 startingPoint;

    // Use this for initialization
    void Start () {
        navComponent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        dispersing = false;
        pointFound = false;
        startingPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //Simple Follow
        //navComponent.SetDestination(followPoint.position);

        //Conversation

        float dist = Vector3.Distance(player.transform.position, followPoint.transform.position);
        //Debug.Log(dist);
        //Debug.Log(navComponent.remainingDistance);
        if (navComponent.remainingDistance <= navComponent.stoppingDistance) {
            Debug.Log("End of Path");
            if (dist < minPlayerDistance) {
                Debug.Log("Player is getting to close");
                dispersing = true;
            }
            else {
                dispersing = false;
            }
        }

        if(dispersing) {
            
            bool lookForPoint = false;
            if(!pointFound) {
                //lookForPoint = RandomPoint(transform.position, 10f, out point);
                point = startingPoint;
                lookForPoint = true;
                if (lookForPoint) {
                    pointFound = true;
                }
            }
            else {
                navComponent.SetDestination(point);
            }
            

        }
        else {
            navComponent.SetDestination(followPoint.position);
            pointFound = false;
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
}
