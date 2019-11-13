using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int directionFacing = 0;
    /*0 = North,
     *1 = South,
     *2 = East,
     *3 = West,*/

    public float speed;

    public GameObject target;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        FaceDirection();
        MoveToPoint();

        if (!Input.anyKey)
        {
            rb.velocity = Vector3.zero;
        }
    }

    void FaceDirection()
    {

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            directionFacing = 0;
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            directionFacing = 1;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            directionFacing = 2;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            directionFacing = 3;
        }

        switch (directionFacing)
        {
            case 0:
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 1:
                transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            case 2:
                transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
            case 3:
                transform.rotation = Quaternion.Euler(0, -90, 0);
                break;
        }
    }

    void MoveToPoint()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }
}
