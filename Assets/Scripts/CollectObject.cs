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
    public int TotCollected;

    public GameObject Manager;

    public GameObject Spawner;

    public bool frenzy;
    void Start()
    {

        if (Player != null)
        {
            frenzy = GameObject.FindGameObjectWithTag("Frenzy").GetComponent<FrenzyManage>().frenzy;

        }

        TotCollected = 0;

        if (!furniture)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            collected = false;
            Object = this.gameObject;
            Object.SetActive(true);
        }
        if (frenzy)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            collected = false;
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

    private void Update()
    {
        if (Spawner.activeSelf == false)
        {
            this.gameObject.AddComponent<Rigidbody>();
        }

    }

    IEnumerator Collect()
    {
        Debug.Log("You Collected" + this.name);
        collected = true;
        yield return new WaitForSeconds(.5f);
        Object.SetActive(false);
        CountdownStart.Total += Value;
        TotCollected++;
    }
}

