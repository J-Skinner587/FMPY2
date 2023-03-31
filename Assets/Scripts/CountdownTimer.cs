using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 120f;

    public TextMeshProUGUI timerText;

    void Start()
    {
        currentTime = startingTime; 
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timerText.text = currentTime.ToString();

        if(currentTime <= 0)
        {
            currentTime= 0;

        }
    }
}
