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
    public GameObject EndScreen;
    public GameObject GameUI;
    public GameObject Player;
    public MainMenu menu;

    public bool frenzy;


    int bronze = 1000;
    int silver = 2500;
    int gold = 5000;
    int platinum = 10000;

    int fbronze = 2000;
    int fsilver = 5000;
    int fgold = 10000;
    int fplatinum = 20000;

    private void Start()
    {
        EndScreen.SetActive(false);
        GameUI.SetActive(true);
        frenzy = menu.Frenzy;
    }  

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameUI.SetActive(false);
            Confirmed();
            Debug.Log("Leave");
        }
    }

    // what medal the player got
    public void Confirmed()
    {
        GameUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None;

        if (frenzy == false)
        {
            if (fbronze >= CountdownStart.Total)
            {
                Debug.Log("Fail");
                titletext.text = "Failure";
                descriptiontext.text = "You failed to reach your goal of 1000";

            }
            if (fsilver >= CountdownStart.Total && CountdownStart.Total > fbronze)
            {
                Debug.Log("Bronze Medal Awarded");
                titletext.text = "Bronze";
                descriptiontext.text = "You got $1000, but could use a bit more.";
            }
            if (fgold >= CountdownStart.Total && CountdownStart.Total > fsilver)
            {
                Debug.Log("Silver");
                titletext.text = "Silver";
                descriptiontext.text = "You got $2500, but could use a bit more.";
            }
            if (fplatinum >= CountdownStart.Total && CountdownStart.Total > fgold)
            {
                Debug.Log("Gold");
                titletext.text = "Gold";
                descriptiontext.text = "You got $5000, but could use a bit more.";

            }
            if (CountdownStart.Total > fplatinum)
            {
                Debug.Log("Platinum");
                titletext.text = "Platinum";
                descriptiontext.text = "You got $10000. We good for now. . .";
            }
            EndScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            if (bronze >= CountdownStart.Total)
            {
                Debug.Log("Fail");
                titletext.text = "Failure";
                descriptiontext.text = "You failed to reach your goal of 2000. You can steal literally anything!";

            }
            if (silver >= CountdownStart.Total && CountdownStart.Total > bronze)
            {
                Debug.Log("Bronze Medal Awarded");
                titletext.text = "Bronze";
                descriptiontext.text = "You got" + CountdownStart.Total + ", but could use a bit more. Did you get the cabinets?";
            }
            if (gold >= CountdownStart.Total && CountdownStart.Total > silver)
            {
                Debug.Log("Silver");
                titletext.text = "Silver";
                descriptiontext.text = "You got" + CountdownStart.Total + ", but could use a bit more. ";
            }
            if (platinum >= CountdownStart.Total && CountdownStart.Total > gold)
            {
                Debug.Log("Gold");
                titletext.text = "Gold";
                descriptiontext.text = "You got" + CountdownStart.Total + ", but could use a bit more. Get the lights off the roof! We need any penny we can get!";

            }
            if (CountdownStart.Total > platinum)
            {
                Debug.Log("Platinum");
                titletext.text = "Platinum";
                descriptiontext.text = "You got" + CountdownStart.Total + ". We good for now. . .";
            }
            EndScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
