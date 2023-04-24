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

namespace Collect
{
    public class CollectObject : MonoBehaviour
    {
        [SerializeField]
        public bool collected;
        GameObject Player;
        public GameObject Object;
        public int Value;

        private bool showInteractMsg;
        private GUIStyle guiStyle;
        private string msg;


        void Start()
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            collected = false;
            Object.SetActive(true);
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
            CountdownTimer.Total += Value;
        }
        //configure the style of the GUI
        private void setupGui()
        {
            guiStyle = new GUIStyle();
            guiStyle.fontSize = 16;
            guiStyle.fontStyle = FontStyle.Bold;
            guiStyle.normal.textColor = Color.white;
            msg = "Press E/Fire1 to Open";

        }

        private string getGuiMsg(bool isOpen)
        {
            string rtnVal;
            if (isOpen)
            {
                rtnVal = "Press E/Fire1 to Close";
            }
            else
            {
                rtnVal = "Press E/Fire1 to Open";
            }

            return rtnVal;
        }

        void OnGUI()
        {
            if (showInteractMsg)  //show on-screen prompts to user for guide.
            {
                GUI.Label(new Rect(50, Screen.height - 50, 200, 50), msg, guiStyle);
            }
        }
        //End of GUI Config --------------

    }
}
