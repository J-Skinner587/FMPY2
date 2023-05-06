using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opencloseDoor : MonoBehaviour
{
    [SerializeField]
    public Animator openandclose;
    public bool open;
    public GameObject Player;
    public bool locked;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        open = false;
    }
    void OnMouseOver()
    {
        {
            if (Player)
            {
                float dist = Vector3.Distance(Player.transform.position, transform.position);
                if (dist < 15)
                {
                    if (open == false)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            if (locked == false)
                            {
                                StartCoroutine(opening());
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
                                StartCoroutine(closing());
                            }
                        }

                    }

                }
            }

        }

    }
    IEnumerator opening()
    {
        print("you are opening the door");
        openandclose.Play("Opening");
        open = true;
        yield return new WaitForSeconds(.5f);
    }
    IEnumerator closing()
    {
        print("you are closing the door");
        openandclose.Play("Closing");
        open = false;
        yield return new WaitForSeconds(.5f);
    }
}
