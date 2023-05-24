﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opencloseDoor : MonoBehaviour
{
    public Animator openandclose;
    public bool open;
    public GameObject player;
    public bool locked;
    public bool lockpick;
 
    [SerializeField]
    GameObject LockCam;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (lockpick == true)
        {
            LockCam = GameObject.FindWithTag("LockCam");
            LockCam.SetActive(false);
        }

        open = false;
    }
    void OnMouseOver()
    {
        if (player)
        {
            float dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist < 15)
            {
                if (open == false)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (locked == false)
                        {
                            StartCoroutine(Opening());
                        }
                        if (lockpick == true)
                        {
                            LockCam.SetActive(true);
                            Cursor.lockState = CursorLockMode.None;
                            Debug.Log("Minigame started");
                            StartCoroutine(Opening());
                            lockpick = false;
                            locked = false;
                        }
                        else
                        {
                            TypewriterUI.active = true;
                            Debug.Log("LockedDoor");
                        }
                    }
                }
                else
                {
                    if (open == true)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            StartCoroutine(Closing());
                        }
                    }

                }

            }
        }
    }
    public IEnumerator Opening()
    {
        print("you are opening the door");
        openandclose.Play("Opening");
        open = true;
        yield return new WaitForSeconds(.5f);
    }
    IEnumerator Closing()
    {
        print("you are closing the door");
        openandclose.Play("Closing");
        open = false;
        yield return new WaitForSeconds(.5f);
    }
}
