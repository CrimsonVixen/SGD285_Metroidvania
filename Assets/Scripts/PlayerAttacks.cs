using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    float meleeAttackTime;
    float rangedAttackTime;

    public GameObject meleeWeapon;
    public GameObject rangedWeapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForAttack();
    }

    void CheckForAttack()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > meleeAttackTime + 2f) 
        {
            print("melee attack");
            meleeAttackTime = Time.time;

            MeleeAttack();
        }

        if (Input.GetMouseButtonDown(1) && Time.time > meleeAttackTime + 3f)
        {
            print("ranged attack");
            rangedAttackTime = Time.time;

            RangedAttack();
        }
    }

    #region melee

    void MeleeAttack()
    {
        meleeWeapon.SetActive(true);

        Invoke("HideMelee", 1f);
    }

    void HideMelee()
    {
        meleeWeapon.SetActive(false);
    }

    #endregion melee

    #region ranged

    void RangedAttack()
    {

    }
}
