using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public bool searchingPlayer;
    public float searchTime = -4f;

    NavMeshAgent agent;

    GameObject player;

    private void Awake()
    {
        searchTime = -3f;
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastForPlayer();

        if (Time.time < searchTime + 3f)
        {
            print("searching");
            print("time = " + Time.time);
            print("searchTime = " + searchTime);
            SearchForPlayer();
        }
        else agent.destination = transform.position;
    }

    void RaycastForPlayer()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 3, Color.yellow);

            if (hit.collider.gameObject.name == "Character")
            {
                agent.destination = player.transform.position;
                searchingPlayer = true;
                searchTime = Time.time;
            }
        }
    }

    void SearchForPlayer()
    {
        agent.destination = player.transform.position;
    }
}
