using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public bool searchingPlayer;

    public Transform[] points;
    public int destPoint = 1;

    public float searchTime = -4f;
    public float timeLastHit = 0f;

    public int health = 2;
    int originalHealth;

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
        NextPoint();
        player = GameObject.Find("Character");
        originalHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastForPlayer();

        if (Time.time < searchTime + 3f)
        {
            SearchForPlayer();
        }

        if(health <= 0)
        {
            Destroy(this.gameObject);
            //this.gameObject.SetActive(false);

            if (originalHealth == 10)
            {
                UIController.instance.endPanel.SetActive(true);
                UIController.instance.endText.text = "YOU KILLED THE BOSS!!!!!";
            }
        }

        if (!agent.pathPending && agent.remainingDistance < .5f)
        {
            NextPoint();
        }
    }

    void RaycastForPlayer()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 3, Color.yellow);

            if (hit.collider.gameObject.name == "Character")
            {
                agent.stoppingDistance = 1.5f;
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

    private void OnTriggerEnter(Collider other)
    {
        if (Time.time > timeLastHit + 3f && other.tag == "Player")
        {
            UIController.instance.InfoUpdate(1);

            timeLastHit = Time.time;
        }
    }

    private void NextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }
}
