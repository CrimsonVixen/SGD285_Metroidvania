using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public GameObject startPanel;
    public GameObject creditsPanel;
    public GameObject healthPanel;
    public GameObject endPanel;
    public GameObject infoPanel;
    public GameObject mainWeapon1Panel, isUsingMain1Panel;
    public GameObject mainWeapon2Panel, isUsingMain2Panel;
    public GameObject rangedWeapon1Panel, isUsingRanged1Panel;
    public GameObject rangedWeapon2Panel, isUsingRanged2Panel;
    public Text hpText;
    public Text endText;
    public Text displayText;
    public int health = 250;
    public float startHP = 154.15f;
    public int mainWeaponUsing = 1;
    public int rangedWeaponUsing = 1;
    public string recentlyEquipped = "Main";
    public bool main02Unlocked = false;
    public bool ranged01Unlocked = false;
    public bool ranged02Unlocked = false;

    void Start()
    {
        instance = this;

        startPanel.SetActive(true);
        creditsPanel.SetActive(false);
        endPanel.SetActive(false);
        infoPanel.SetActive(false);

        isUsingMain1Panel.SetActive(false);
        isUsingRanged1Panel.SetActive(true);

        // healthPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(health, healthPanel.GetComponent<RectTransform>().sizeDelta.y);
        // healthPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(startHP, healthPanel.GetComponent<RectTransform>().anchoredPosition.y);

        //mainWeapon1Panel.GetComponent<Image>().color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (mainWeaponUsing == 1)
            {
                if(main02Unlocked)
                {
                    mainWeaponUsing = -1;
                    isUsingMain1Panel.SetActive(true);
                    isUsingMain2Panel.SetActive(false);
                }
            }
            else if (mainWeaponUsing == -1)
            {
                isUsingMain1Panel.SetActive(false);
                isUsingMain2Panel.SetActive(true);
                mainWeaponUsing = 1;
            }
            recentlyEquipped = "Main";
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (rangedWeaponUsing == 1 && ranged01Unlocked)
            {
                isUsingRanged1Panel.SetActive(true);
                isUsingRanged2Panel.SetActive(false);
                if (ranged02Unlocked)
                {
                    rangedWeaponUsing = -1;
                }
                recentlyEquipped = "Ranged";
            }
            else if (rangedWeaponUsing == -1 && ranged02Unlocked)
            {
                isUsingRanged2Panel.SetActive(true);
                isUsingRanged1Panel.SetActive(false);
                if (ranged01Unlocked) 
                { 
                rangedWeaponUsing = 1;
                }
                recentlyEquipped = "Ranged";
            }
            else if (!ranged01Unlocked && ranged02Unlocked)
            {
                isUsingRanged2Panel.SetActive(false);
                isUsingRanged1Panel.SetActive(true);
                rangedWeaponUsing = -1;
                recentlyEquipped = "Ranged";
            }
            else if (ranged01Unlocked && !ranged02Unlocked)
            {
                isUsingRanged2Panel.SetActive(true);
                isUsingRanged1Panel.SetActive(false);
                rangedWeaponUsing = 1;
                recentlyEquipped = "Ranged";
            }
        }
    }

    public void OnPlayButtonClick()
    {
        startPanel.SetActive(false);
        creditsPanel.SetActive(false);

        PlayerMovement.instance.canMelee = true;
    }

    public void OnCreditsButtonClick()
    {
        creditsPanel.SetActive(true);
    }

    public void OnCreditsBackButtonClick()
    {
        creditsPanel.SetActive(false);
    }

    public void onQuitButtonClick()
    {
        Application.Quit();
        print("I quit cause i suck");
    }

    public void OnMainMenuClick()
    {
        endPanel.SetActive(false);
        startPanel.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void InfoUpdate(int num)
    {
        CancelInvoke();

        infoPanel.SetActive(true);
        if (num == 1)
        {
            health -= 50;
            startHP -= 25;
            displayText.text += "You took 50 Damage" + '\n';
            healthPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(health, healthPanel.GetComponent<RectTransform>().sizeDelta.y);
            healthPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(startHP, healthPanel.GetComponent<RectTransform>().anchoredPosition.y);
            print(healthPanel.GetComponent<RectTransform>().sizeDelta.x);
            if (health <= 0)
            {
                health = 0;
                endPanel.SetActive(true);
                endText.text = "You lose ... get good";

            }
            hpText.text = health.ToString();
        }
        else if (num == 2)
        {
            displayText.text += "You picked up a weapon" + '\n';
        }
        else if (num == 3)
        {
            displayText.text += "You hit an ememy" + '\n';
        }
        else if (num == 4)
        {
            displayText.text += "You collected a melee weapon.\n Press Q to switch." + '\n';
        }
        else if (num == 5)
        {
            displayText.text += "You collected a ranged weapon.\n Press E to switch" + '\n';
        }
        else if (num == 6)
        {
            displayText.text += "This weapon can break trees.\n";
        }
        Invoke("InfoText", 5);
    }

    public void InfoText()
    {
        infoPanel.SetActive(false);
    }
}
