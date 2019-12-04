using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIController : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject creditsPanel;
    public GameObject healthPanel;
    public GameObject endPanel;
    public GameObject infoPanel;
    public GameObject mainWeapon1Panel, isUsingMain1Panel;
    public GameObject mainWeapon2Panel, isUsingMain2Panel;
    public GameObject rangedWeapon1Panel, isUsingRanged1panel;
    public GameObject rangedWeapon2Panel, isUsingRanged2panel;
    public Text hpText;
    public Text endText;
    public Text displayText;
    public int health = 250;
    public float startHP = 154.15f;
    public int mainWeaponUsing = 1;
    public int rangedWeaponUsing = 1;

    void Start()
    {
        startPanel.SetActive(true);
        creditsPanel.SetActive(false);
        endPanel.SetActive(false);
        infoPanel.SetActive(false);

        // healthPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(health, healthPanel.GetComponent<RectTransform>().sizeDelta.y);
        // healthPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(startHP, healthPanel.GetComponent<RectTransform>().anchoredPosition.y);

        //mainWeapon1Panel.GetComponent<Image>().color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            mainWeaponUsing *= -1;
            if (mainWeaponUsing == 1)
            {
                isUsingMain1Panel.SetActive(true);
                isUsingMain2Panel.SetActive(false);
            }
            //else if (mainWeaponUsing )
            if (mainWeaponUsing == -1)
            {
                isUsingMain2Panel.SetActive(true);
                isUsingMain1Panel.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            rangedWeaponUsing *= -1;
            if (rangedWeaponUsing == 1)
            {
                isUsingRanged1panel.SetActive(true);
                isUsingRanged2panel.SetActive(false);
            }
            //else if (mainWeaponUsing )
            if (rangedWeaponUsing == -1)
            {
                isUsingRanged2panel.SetActive(true);
                isUsingRanged1panel.SetActive(false);
            }
        }
    }

    public void OnPlayButtonClick()
    {
        startPanel.SetActive(false);
        creditsPanel.SetActive(false);
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
    }

    public void ButtonClick()
    {
        health -= 50;
        startHP -= 25;
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

        infoPanel.SetActive(true);
        int num = Random.Range(1, 3);
        if (num == 1)
        {
            displayText.text += "You took 50 Damage" + '\n';
        }
        else if(num == 2)
        {
            displayText.text += "You picked up a key" + '\n';
        }
        else
        {
            displayText.text += "Andrew did not know what else to put here" + '\n';
        }

        Invoke("InfoText", 5);
    }

    public void InfoText()
    {
        infoPanel.SetActive(false);
    }
}
