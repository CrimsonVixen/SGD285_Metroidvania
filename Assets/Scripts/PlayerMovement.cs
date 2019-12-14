using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    public int directionFacing = 0;
    /*0 = North,
     *1 = South,
     *2 = East,
     *3 = West,*/

    public float speed;
    public float rotateTime;

    public GameObject target;

    public GameObject smallSword;
    public GameObject bigSword;
    public GameObject rotPoint;
    public float rotSpeed;
    public bool canMelee;

    public GameObject bow;
    public GameObject pistol;

    public GameObject arrow;
    public GameObject bullet;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        instance = this;
        canMelee = false;
    }

    private void Update()
    {
        FaceDirection();
        MoveToPoint();

        if (Input.GetMouseButtonDown(0) && canMelee)
        {
            Attack(UIController.instance.mainWeaponUsing, UIController.instance.rangedWeaponUsing, UIController.instance.recentlyEquipped);
            StartCoroutine("MeleeRotate");
            Invoke("StopMeleeRotate", rotateTime);

            canMelee = false;
        }

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

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Bow":
                UIController.instance.ranged01Unlocked = true;
                UIController.instance.InfoUpdate(5);
                Destroy(other.gameObject);
                break;
            case "Pistol":
                UIController.instance.ranged02Unlocked = true;
                UIController.instance.InfoUpdate(5);
                Destroy(other.gameObject);
                break;
            case "Better Sword":
                UIController.instance.main02Unlocked = true;
                UIController.instance.InfoUpdate(4);
                Destroy(other.gameObject);
                break;
            default:
                //print("Collided with a non-weapon");
                break;
        }
    }

    void Attack(int mainWeapon, int rangedWeapon, string recent)
    {
        //print("attacking");
        if (recent == "Main")
        {
            if(mainWeapon == 1)
            {
                smallSword.SetActive(true);
                bigSword.SetActive(false);
                pistol.SetActive(false);
                bow.SetActive(false);
            }
            else if(mainWeapon == -1)
            {
                smallSword.SetActive(false);
                bigSword.SetActive(true);
                pistol.SetActive(false);
                bow.SetActive(false);
            }
        }
        else if (recent == "Ranged")
        {
            if (rangedWeapon == 1)
            {
                pistol.SetActive(false);
                bow.SetActive(true);
                smallSword.SetActive(false);
                bigSword.SetActive(false);

                GameObject _arrow = Instantiate(arrow);

                _arrow.SetActive(true);
            }
            else if (rangedWeapon == -1)
            {
                pistol.SetActive(true);
                bow.SetActive(false);
                smallSword.SetActive(false);
                bigSword.SetActive(false);

                GameObject _bullet = Instantiate(bullet);

                _bullet.SetActive(true);
            }
        }
    }

    IEnumerator MeleeRotate()
    {
        while (true)
        {
            rotPoint.transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0), Space.Self);
            yield return new WaitForSeconds(0.01f);
        }
    }

    void StopMeleeRotate()
    {
        StopCoroutine("MeleeRotate");
        canMelee = true; switch (directionFacing)
        {
            case 0:
                rotPoint.transform.rotation = Quaternion.Euler(0, -30, 0);
                break;
            case 1:
                rotPoint.transform.rotation = Quaternion.Euler(0, 150, 0);
                break;
            case 2:
                rotPoint.transform.rotation = Quaternion.Euler(0, 60, 0);
                break;
            case 3:
                rotPoint.transform.rotation = Quaternion.Euler(0, 240, 0);
                break;
        }
        bigSword.SetActive(false);
        smallSword.SetActive(false);
    }
}
