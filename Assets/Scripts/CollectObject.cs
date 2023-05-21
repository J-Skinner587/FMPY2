using SojaExiles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.SceneManagement;

public class CollectObject : MonoBehaviour
{
    [SerializeField]
    public bool collected;
    GameObject Player;
    GameObject Object;
    public int Value;
    public bool furniture;

    public GameObject UI;

    void Start()
    {
        leavescene.TotCollected = 0;
        if (!furniture)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            collected = false;
            Object = this.gameObject;
            Object.SetActive(true);
        }
        else
        {
            enabled = false;
        }
    }
    void OnMouseOver()
    {
        if (Player)
        {
            float dist = Vector3.Distance(Player.transform.position, transform.position);
            if (dist < 10)
            {
                if (collected == false)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        StartCoroutine(Collect());
                    }
                }
                else
                    return;
            }
        }
    }
    IEnumerator Collect()
    {
        Debug.Log("You Collected" + this.name);
        collected = true;
        yield return new WaitForSeconds(.5f);
        if(Object.CompareTag("Appliances"))
        {
            leavescene.TotalAppliances++;
            CountdownStart.Total += Value;
            Debug.Log("CollectAppli");
            Object.SetActive(false);
        }
        if (Object.CompareTag("Artwork"))
        {
            leavescene.TotalArtwork++;
            CountdownStart.Total += Value;
            Debug.Log("CollectArt");
            Object.SetActive(false);
        }
        if (Object.CompareTag("Electronics"))
        {
            leavescene.TotalElectronics++;
            CountdownStart.Total += Value;
            Debug.Log("CollectElectron");
            Object.SetActive(false);
        }
        if (Object.CompareTag("Wine"))
        {
            leavescene.TotalWine++;
            CountdownStart.Total += Value;
            Debug.Log("Collectwine");
            Object.SetActive(false);
        }
        else
        {
            CountdownStart.Total += Value;
            Object.SetActive(false);
        }
    }
}

