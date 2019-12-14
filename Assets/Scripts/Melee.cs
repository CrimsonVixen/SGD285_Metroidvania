using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyMovement>().health -= damage;
            UIController.instance.InfoUpdate(3);
        }
        else if (other.tag == "Tree" && this.damage > 2)
        {
            Destroy(other.gameObject);
            print("melee collided with a tree");
        }
    }
}
