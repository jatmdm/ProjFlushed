using UnityEngine;
using System.Collections;

public class NPCPathManager : MonoBehaviour {


    public Transform[] pathPoints;
    public bool repeatPath;
    public bool reversePath;
    public bool pausePath;
    public float minPointDist = 3f;

    MainNPCController controller;
    NavMeshAgent navmeshagent;

    bool moving;
    int curPathPoint;
    int numPoints;


	// Use this for initialization
	void Start () {
        moving = true;
        curPathPoint = 0;
        numPoints = pathPoints.Length;
    }
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(pathPoints[curPathPoint].position, navmeshagent.transform.position);
        //Debug.Log(dist);
        if(navmeshagent != null && dist <= minPointDist ) {
            //Debug.Log("BEFORE: " + curPathPoint);
            nextPoint(); 
        }
	}

    public void npcSetPath(GameObject npc) {
        MainNPCController cont = npc.GetComponent<MainNPCController>();
        NavMeshAgent nav = npc.GetComponent<NavMeshAgent>();
        navmeshagent = nav;
        controller = cont;

        controller.SetNPCDesitnation(pathPoints[curPathPoint].position);

        curPathPoint = 0;

    }

    void nextPoint() {
        

        curPathPoint = (curPathPoint + 1) % pathPoints.Length;
        controller.SetNPCDesitnation(pathPoints[curPathPoint].position);
        Debug.Log(curPathPoint);

    }
}
