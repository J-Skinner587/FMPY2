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
    public TextMeshProUGUI nextmedaltext;
    public TextMeshProUGUI appliances;
    public TextMeshProUGUI artwork;
    public TextMeshProUGUI electronics;
    public TextMeshProUGUI wine;
    public TextMeshProUGUI totobjCollect;
    public TextMeshProUGUI Totmoney;

    public static int TotCollected;
    public static int TotalAppliances;
    public static int TotalArtwork;
    public static int TotalElectronics;
    public static int TotalWine;

    public GameObject EndScreen;
    public GameObject GameUI;
    public GameObject Player;
    public GameObject EndBackgroundroom;
    public GameObject dot;

    int bronze = 1000;
    int silver = 2500;
    int gold = 5000;
    int platinum = 10000;

    private void Start()
    {
        EndBackgroundroom.SetActive(false);
        EndScreen.SetActive(false);
        GameUI.SetActive(true);
        dot.SetActive(true);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameUI.SetActive(false);
            Confirmed();
            Debug.Log("Leave");
        }
    }

    // what medal the player got
    public void Confirmed()
    {
        TotCollected = TotalAppliances + TotalArtwork + TotalElectronics + TotalWine;

        EndBackgroundroom.SetActive(true);
        Player.SetActive(false);
        GameUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Player.SetActive(false);
        dot.SetActive(false);
        
        appliances.text = "Appliances: " + TotalAppliances;
        artwork.text = "Artwork: " + TotalArtwork;
        electronics.text = "Electronics: " + TotalElectronics;
        wine.text = "Wine: " + TotalWine;
        totobjCollect.text = "Total Items Collected: " + TotCollected.ToString();
        Totmoney.text = "Total Take: $" + CountdownStart.Total.ToString();
        

        if (bronze >= CountdownStart.Total)
        {
            Debug.Log("Fail");
            titletext.text = "Failure";
            descriptiontext.text = "You only got $" + CountdownStart.Total + "? We need at least $1000.";
            nextmedaltext.text = "Bronze is at $1000";
        }
        if (silver >= CountdownStart.Total && CountdownStart.Total > bronze)
        {
            Debug.Log("Bronze Medal Awarded");
            titletext.text = "Bronze";
            descriptiontext.text = "You got $" + CountdownStart.Total + ", but could use a lot more. Did you check the cabinets?";
            nextmedaltext.text = "Silver is at $2500";
        }
        if (gold >= CountdownStart.Total && CountdownStart.Total > silver)
        {
            Debug.Log("Silver");
            titletext.text = "Silver";
            descriptiontext.text = "You got $" + CountdownStart.Total + ", but could use a more. ";
            nextmedaltext.text = "Gold is at $5000";
        }
        if (platinum >= CountdownStart.Total && CountdownStart.Total > gold)
        {
            Debug.Log("Gold");
            titletext.text = "Gold";
            descriptiontext.text = "You got $" + CountdownStart.Total + ", but could use a bit more. Get the lights off the roof! We need any penny we can get!";
            nextmedaltext.text = "Platinum is at $10000";
        }
        if (CountdownStart.Total > platinum)
        {
            Debug.Log("Platinum");
            titletext.text = "Platinum";
            descriptiontext.text = "You got $" + CountdownStart.Total + ". We good for now. . .";
            nextmedaltext.text = "Unbeatable";
        }
        EndScreen.SetActive(true);
    }
}
