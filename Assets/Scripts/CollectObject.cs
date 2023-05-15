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

namespace Collect
{
    public class CollectObject : MonoBehaviour
    {
        [SerializeField]
        public bool collected;
        GameObject Player;
        public GameObject Object;
        public int Value;
        public bool furniture;
        public bool Frenzy;
        void Start()
        {
            if(furniture == !true)
            {
                Player = GameObject.FindGameObjectWithTag("Player");
                collected = false;
                Object.SetActive(true);
            }
            if(Frenzy == true)
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
                                StartCoroutine(collect());
                            }
                        }
                        else
                            return;
                    }
                }

            }

        }

        IEnumerator collect()
        {
            Debug.Log("You Collected" + this.name);
            collected = true;
            yield return new WaitForSeconds(.5f);
            Object.SetActive(false);
            CountdownStart.Total += Value;
        }
    }
}
