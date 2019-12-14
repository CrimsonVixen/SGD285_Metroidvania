using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ForceAggro : MonoBehaviour
{
    public NavMeshAgent agent;

    GameObject player;

    bool chasePlayer = false;

    private void Start()
    {
        player = GameObject.Find("Character");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ForceAnger();
        }
    }

    public void ForceAnger()
    {
        chasePlayer = true;
    }

    private void Update()
    {
        if (chasePlayer && GameObject.Find("Enemy (7)") != null)
            agent.destination = player.transform.position;
    }
}
