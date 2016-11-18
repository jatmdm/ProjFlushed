using UnityEngine;
using System.Collections;

public class TestQueueScript : MonoBehaviour {

    public bool enqueue;
    public bool dequeue;
    public GameObject queue;
    QueueManager queueManager;
    public GameObject[] npcs;
    public GameObject player;

    int i;
	// Use this for initialization
	void Start () {
        enqueue = false;
        queueManager = queue.GetComponent<QueueManager>();
        player = GameObject.Find("Player");
        i = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    if(enqueue) {
            queueManager.npcEnqueue(npcs[i]);
            enqueue = false;
            i++;
        }
        if(dequeue) {
            GameObject npcExiting = queueManager.npcDequeue();
            Debug.Log(npcExiting.name);
            npcExiting.GetComponent<MainNPCController>().followPoint = player.transform.position;
            npcExiting.GetComponent<NavMeshAgent>().stoppingDistance = 3f;

            dequeue = false;
        }
    }
}
