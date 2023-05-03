using JetBrains.Annotations;
using SojaExiles;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class leavescene : MonoBehaviour
{
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
        var camscript = Player.GetComponentInChildren<MouseLook>();

        if (other.tag == "Player")
        {
            Confirm.SetActive(true);
            GameUI.SetActive(false);
            camscript.enabled = false;
// pause
        } 
    }

    // what medal the player got
    void Confirmed()
    {
        //bring up end screen

        if (bronze <= CountdownTimer.Total)
        {
            Debug.Log("No Medal Awarded");
        }

        if(silver <= CountdownTimer.Total)
        {
            Debug.Log("Bronze Medal Awarded");
        }

        if(gold <= CountdownTimer.Total)
        {
            Debug.Log("Silver");
        }
        if(platinum <= CountdownTimer.Total)
        {
            Debug.Log("Gold");
        }
        if(CountdownTimer.Total > platinum)
        {
            Debug.Log("Platinum");
        }
    }
}
