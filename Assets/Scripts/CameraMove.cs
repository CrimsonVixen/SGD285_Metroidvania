using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float cameraMoveSpeed;

    public bool moveCam;

    private void Awake()
    {
        moveCam = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (moveCam/* && other.tag != "Untagged" && other.tag != "Arrow" && other.tag != "Bullet"*/)
        {
            switch (other.tag)
            {
                case "NorthDoor":
                    Vector3 NorthTarget = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z + 32);
                    Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, NorthTarget, cameraMoveSpeed/* * Time.deltaTime*/);
                    moveCam = false;
                    UIController.instance.displayText.text = "";
                    Invoke("EnableMoveCam", 2f);
                    break;
                case "EastDoor":
                    Vector3 EastTarget = new Vector3(Camera.main.transform.position.x + 32, Camera.main.transform.position.y, Camera.main.transform.position.z);
                    Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, EastTarget, cameraMoveSpeed/* * Time.deltaTime*/);
                    moveCam = false;
                    UIController.instance.displayText.text = "";
                    Invoke("EnableMoveCam", 2f);
                    break;
                case "SouthDoor":
                    Vector3 SouthTarget = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z - 32);
                    Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, SouthTarget, cameraMoveSpeed/* * Time.deltaTime*/);
                    moveCam = false;
                    UIController.instance.displayText.text = "";
                    Invoke("EnableMoveCam", 2f);
                    break;
                case "WestDoor":
                    Vector3 WestTarget = new Vector3(Camera.main.transform.position.x - 32, Camera.main.transform.position.y, Camera.main.transform.position.z);
                    Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, WestTarget, cameraMoveSpeed/* * Time.deltaTime*/);
                    moveCam = false;
                    UIController.instance.displayText.text = "";
                    Invoke("EnableMoveCam", 2f);
                    break;
                default:
                    break;
            }
        }
    }

    void EnableMoveCam()
    {
        print("ready to move cam");
        moveCam = true;
    }
}
