using UnityEngine;
using System.Collections;

/* MainNPCController
 * 
 *
 * 
 */

public class MainNPCController : MonoBehaviour {

    UnityEngine.AI.NavMeshAgent navmesh;

    public bool aiEnabled; // toggle NPC movement

<<<<<<< HEAD
    public Transform followObject;
    public Vector3 followPoint;
    public UnityEngine.AI.NavMeshPath path;
    public bool isFollowingPath;
    public bool isFollowingPoint;
=======
    public Transform followObject; // object the NPC will follow
    public Vector3 followPoint; // point the NPC will follow
    public bool isFollowingPoint; 
>>>>>>> Sam


	// Use this for initialization
	void Start () {
        aiEnabled = true;
<<<<<<< HEAD
        navmesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        isFollowingPath = false;
=======
        navmesh = GetComponent<NavMeshAgent>();
>>>>>>> Sam
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
