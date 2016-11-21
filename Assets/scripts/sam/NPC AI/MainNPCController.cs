using UnityEngine;
using System.Collections;

/* 
 * 
 *
 * 
 */

public class MainNPCController : MonoBehaviour {

    NavMeshAgent navmesh;

    public bool aiEnabled;

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
	
    public bool IsFollowingPath{
        get { return isFollowingPath; }
        set { this.isFollowingPath = value; }
    }

    public bool IsFollowingPoint {
        get { return isFollowingPoint; }
        set { this.isFollowingPoint = value; }
    }

    // Update is called once per frame
    void FixedUpdate () {

        

        if (aiEnabled) {
            if (isFollowingPath) {
                isFollowingPoint = false;
            }
            else if(isFollowingPoint) {
                isFollowingPath = false;
                navmesh.SetDestination(followPoint);
            }
            else {
                navmesh.SetDestination(followObject.position);
            }
        }
	}

    public void SetNPCDestination(Transform pos) {
        navmesh.SetDestination(pos.position);
    }

    public void SetNPCDesitnation(Vector3 pos) {
        navmesh.SetDestination(pos);
    }
}
