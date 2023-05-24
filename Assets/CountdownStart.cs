using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownStart : MonoBehaviour
{
    public float timeLeft = 3.0f;
    public TextMeshProUGUI startText;
    public GameObject counterui;

    public static float currentTime = 0f;
    readonly float startingTime = 120f;
    public TextMeshProUGUI timerText;

    public static int Total = 0;
    public int MoneyText;
    public int Take;
    public TextMeshProUGUI MoneyCounter;

    public GameObject mainUI;

    public GameObject holder;

    public GameObject Guard;

    private void Start()
    {
        Guard.SetActive(false);
        currentTime = startingTime;
        counterui.SetActive(true);
        mainUI.SetActive(false);

    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        startText.text = (timeLeft).ToString("0");
        if(timeLeft < 0.5)
        {
            startText.text = "GO!!!";
            if(timeLeft  <= 0.1)
            {
                if(timeLeft >= -1)
                mainUI.SetActive(true);
                counterui.SetActive(false);
                startText.text = "";

                currentTime -= 1 * Time.deltaTime;
                timerText.text = currentTime.ToString("0");
                if (currentTime <= 0)
                {
                    currentTime = 0;
                    timerText.text = "Time's Up";
                    Debug.Log("$$ Time Up $$");
                    Guard.SetActive(true);
                }

                MoneyText = Total;
                MoneyCounter.text = ("Take: $") + MoneyText.ToString();
            }
        }
    }
}
