using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public string moveDir = "North";
    public float speed;
    public int damage;
    public float spawnTime = 1f;

    Vector3 north;
    Vector3 south;
    Vector3 east;
    Vector3 west;

    private void Awake()
    {
        transform.position = GameObject.Find("Character").transform.position;

        switch (PlayerMovement.instance.directionFacing)
        {
            case 0:
                moveDir = "North";
                break;
            case 1:
                moveDir = "South";
                break;
            case 2:
                moveDir = "East";
                break;
            case 3:
                moveDir = "West";
                break;
            default:
                moveDir = "North";
                break;
        }

        north = new Vector3(0,0,1);
        south = new Vector3(0, 0, -1);
        east = new Vector3(1, 0, 0);
        west = new Vector3(-1, 0, 0);

        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if ((spawnTime + 3) <= Time.time)
        {
            Destroy(this.gameObject);
        }
    }

    void Move()
    {
        switch (moveDir)
        {
            case "North":
                transform.rotation = Quaternion.identity;
                transform.Translate(north * Time.deltaTime * speed, Space.World);
                break;
            case "South":
                transform.rotation = Quaternion.Euler(0, 180, 0);
                transform.Translate(south * Time.deltaTime * speed, Space.World);
                break;
            case "East":
                transform.rotation = Quaternion.Euler(0, 90, 0);
                transform.Translate(east * Time.deltaTime * speed, Space.World);
                break;
            case "West":
                transform.rotation = Quaternion.Euler(0, 270, 0);
                transform.Translate(west * Time.deltaTime * speed, Space.World);
                break;
            default:
                transform.rotation = Quaternion.identity;
                transform.Translate(north * Time.deltaTime * speed, Space.World);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Enemy":
                UIController.instance.InfoUpdate(3);
                other.GetComponent<EnemyMovement>().health -= damage;
                Destroy(this.gameObject);
                break;
            case "DestructibleTree":
                print("projectile with " + this.damage + " damage collided with a tree");
                if(this.damage > 1)
                {
                    Destroy(other.gameObject);
                }
                Destroy(this.gameObject);
                break;
        }
    }
}
