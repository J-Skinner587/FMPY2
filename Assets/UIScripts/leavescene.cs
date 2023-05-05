using JetBrains.Annotations;
using SojaExiles;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class leavescene : MonoBehaviour
{
    public TextMeshProUGUI titletext;
    public TextMeshProUGUI descriptiontext;
    public GameObject Confirm;
    public GameObject EndScreen;
    public GameObject GameUI;
    public GameObject Player; 

    int bronze = 1000;
    int silver = 2500;
    int gold = 5000;
    int platinum = 10000;

    private void Start()
    {
        Confirm.SetActive(false); 
        EndScreen.SetActive(false);
        GameUI.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Confirm.SetActive(true);
            GameUI.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            // pause
        } 
    }

    // what medal the player got
    public void Confirmed()
    {
        //bring up end screen

        GameUI.SetActive(false);
        Confirm.SetActive(false);

        if (bronze >= CountdownTimer.Total)
        {
            Debug.Log("Fail");
            titletext.text = "Failure";
            descriptiontext.text = "You failed to reach your goal of 1000";

        }
        if(silver >= CountdownTimer.Total && CountdownTimer.Total > bronze)
        {
            Debug.Log("Bronze Medal Awarded");
            titletext.text = "Bronze";
            descriptiontext.text = "You got $1000, but could use a bit more.";
        }
        if(gold >= CountdownTimer.Total && CountdownTimer.Total > silver)
        {
            Debug.Log("Silver");
            titletext.text = "Silver";
            descriptiontext.text = "You got $2500, but could use a bit more.";
        }
        if(platinum >= CountdownTimer.Total && CountdownTimer.Total > gold)
        {
            Debug.Log("Gold");
            titletext.text = "Gold";
            descriptiontext.text = "You got $5000, but could use a bit more.";

        }
        if(CountdownTimer.Total > platinum)
        {
            Debug.Log("Platinum");
            titletext.text = "Platinum";
            descriptiontext.text = "You got $10000. We good for now. . .";
        }
        EndScreen.SetActive(true);
    }
}
