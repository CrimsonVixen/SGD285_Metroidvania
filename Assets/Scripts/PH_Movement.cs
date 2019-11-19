using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PH_Movement : MonoBehaviour
{
    private Vector3 playerPosition;

    void Start()
    {
        playerPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            playerPosition.z -= 0.1f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            playerPosition.z += 0.1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerPosition.x -= 0.1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerPosition.x += 0.1f;
        }

        this.transform.position = playerPosition;
    }
}
