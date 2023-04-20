using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 120f;

    public int Total = 0;
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
        timerText.text = currentTime.ToString();

        if(currentTime <= 0)
        {
            currentTime= 0;
        }

        MoneyText = Total;
        MoneyCounter.text = ("Take: $") + MoneyText.ToString();
    }
}
