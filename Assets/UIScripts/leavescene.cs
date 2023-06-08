using JetBrains.Annotations;
using SojaExiles;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public int bronze = 1000;
    public int silver = 2500;
    public int gold = 5000;
    public int platinum = 10000;

    private void Start()
    {
        TotalArtwork= 0;
        TotalAppliances= 0;
        TotalElectronics = 0;
        TotalWine = 0;
        TotCollected = 0;

        EndBackgroundroom.SetActive(false);
        EndScreen.SetActive(false);
        GameUI.SetActive(true);
        dot.SetActive(true);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
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
            descriptiontext.text = "You only got $" + CountdownStart.Total + "? We need at least $" + bronze + ".";
            nextmedaltext.text = "Bronze is at $" + bronze;
        }
        if (silver >= CountdownStart.Total && CountdownStart.Total > bronze)
        {
            Debug.Log("Bronze Medal Awarded");
            titletext.text = "Bronze";
            descriptiontext.text = "You got $" + CountdownStart.Total + ", but could use a lot more. Did you check the cabinets?";
            nextmedaltext.text = "Silver is at $" + silver;
        }
        if (gold >= CountdownStart.Total && CountdownStart.Total > silver)
        {
            Debug.Log("Silver");
            titletext.text = "Silver";
            descriptiontext.text = "You got $" + CountdownStart.Total + ", but could use a more. ";
            nextmedaltext.text = "Gold is at $" + gold;
        }
        if (platinum >= CountdownStart.Total && CountdownStart.Total > gold)
        {
            Debug.Log("Gold");
            titletext.text = "Gold";
            descriptiontext.text = "You got $" + CountdownStart.Total + ", but could use a bit more. Get the lights off the roof! We need any penny we can get!";
            nextmedaltext.text = "Platinum is at $" + platinum;
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
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
