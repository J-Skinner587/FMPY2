using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leavescene : MonoBehaviour
{
    public GameObject Confirm;
    public GameObject EndScreen;
    public GameObject GameUI;
    private void Start()
    {
        Confirm.SetActive(false); 
        EndScreen.SetActive(false);
        GameUI.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Confirm.SetActive(true);
            GameUI.SetActive(false);

            if (/* yes button is pressed*/)
            {
                EndScreen.SetActive(true);
                GameUI.SetActive(false);
            }
            else
            {
                Confirm.SetActive(false);
                GameUI.SetActive(true);
            }
        }
    }
}
