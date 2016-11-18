using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QueueManager : MonoBehaviour {

    LinkedList<GameObject> npcQueue;
    public float npcSpacing;
    public float queueDirection;



	// Use this for initialization
	void Start () {
        npcQueue = new LinkedList<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        queueDirection = queueDirection % 360;
	}

    public void npcEnqueue(GameObject npc) {
        int npcCount = npcQueue.Count;
        MainNPCController npcController = npc.GetComponent<MainNPCController>();
        NavMeshAgent npcAgent = npc.GetComponent<NavMeshAgent>();

        npcAgent.stoppingDistance = 0f;

        if(npcCount == 0) {
            npcController.IsFollowingPoint = true;
            npcController.followPoint = transform.position;
            npcQueue.AddLast(npc);
        }
        else {
            Vector3 npcQueuePoint;
            float npcBetweenDistance = npcSpacing * npcCount;
            npcQueuePoint = transform.position + (new Vector3(npcBetweenDistance * Mathf.Cos(queueDirection * Mathf.Deg2Rad), 0, npcBetweenDistance * Mathf.Sin(queueDirection * Mathf.Deg2Rad)));
            npcController.IsFollowingPoint = true;

            npcController.followPoint = npcQueuePoint;
            npcQueue.AddLast(npc);
        }
    }

    public GameObject npcDequeue() {
        LinkedListNode<GameObject> npcExiting = npcQueue.First;
        LinkedListNode<GameObject> npcUpNext = npcQueue.First.Next;
       

        Vector3 prevPoint = transform.position, nextPoint;
        for(int i = 0; i < npcQueue.Count - 1 ; i++) {

            MainNPCController npcController = npcUpNext.Value.GetComponent<MainNPCController>();
            NavMeshAgent npcAgent = npcUpNext.Value.GetComponent<NavMeshAgent>();

            nextPoint = npcController.followPoint;
            npcController.followPoint = prevPoint;
            prevPoint = nextPoint;

            npcUpNext = npcUpNext.Next;
        }

        npcQueue.RemoveFirst();

        return npcExiting.Value;

    }


}
