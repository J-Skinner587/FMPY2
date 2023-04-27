using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class CountdownTimer : MonoBehaviour
{
    public static float currentTime = 0f;
    float startingTime = 120f;

    public static int Total = 0;
    public int MoneyText;
    public int Take;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI MoneyCounter;
   

    void Start()
    {
        currentTime = startingTime;
        Total = 0;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timerText.text = currentTime.ToString("0");

        if(currentTime <= 0)
        {
            currentTime= 0;
            timerText.text = "Time's Up";
            Debug.Log("$$ Time Up $$");
        }

        MoneyText = Total;
        MoneyCounter.text = ("Take: $") + MoneyText.ToString();
    }
}
