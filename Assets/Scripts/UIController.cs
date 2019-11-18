using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject creditsPanel;
    public GameObject healthPanel;
    public Text hpText;
    public int health = 250;
    public float startHP = 154.15f;

    void Start()
    {
        startPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        }
        hpText.text = health.ToString();
    }
}
