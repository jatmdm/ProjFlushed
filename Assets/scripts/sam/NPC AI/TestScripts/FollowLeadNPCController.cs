using UnityEngine;
using System.Collections;

public class FollowLeadNPCController : MonoBehaviour {

    public Transform followPoint;
    //public float minPlayerDistance;
    NavMeshAgent navComponent;
    GameObject player;

	// Use this for initialization
	void Start () {
        navComponent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        navComponent.SetDestination(followPoint.position);
	}
}
