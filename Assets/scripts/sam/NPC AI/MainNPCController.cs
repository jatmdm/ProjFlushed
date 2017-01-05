using UnityEngine;
using System.Collections;

/* MainNPCController
 * 
 *
 * 
 */

public class MainNPCController : MonoBehaviour {

    NavMeshAgent navmesh;

    public bool aiEnabled; // toggle NPC movement

    public Transform followObject;
    public Vector3 followPoint;
    public NavMeshPath path;
    public bool isFollowingPath;
    public bool isFollowingPoint;



	// Use this for initialization
	void Start () {
        aiEnabled = true;

        navmesh = GetComponent<NavMeshAgent>();
        isFollowingPath = false;

        isFollowingPoint = false;
	}

    // Update is called once per frame
    void FixedUpdate () {

        if (aiEnabled) {
            if(isFollowingPoint) {
                navmesh.SetDestination(followPoint);
            }
            else {
                navmesh.SetDestination(followObject.position);
            }
        }
	}

    // SetNPCDestination
    // Set the point for the NPC to follow
    // changes the NPC path mode between point and object
    public void SetNPCDestination(Transform pos) {
        isFollowingPoint = false;
        followPoint = pos.position;
    }

    public void SetNPCDesitnation(Vector3 pos) {
        isFollowingPoint = true;
        followPoint = pos;
    }
}
