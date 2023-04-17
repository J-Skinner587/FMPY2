using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObject : MonoBehaviour
{
    public bool collected;
    private GameObject Player;
    public GameObject Object;
    int CollectedObjects;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        collected = false;
        Object.SetActive(true);
        CollectedObjects = 0;
    }
    void OnMouseOver()
    {
        {
            if (Player)
            {
                float dist = Vector3.Distance(Player.transform.position, transform.position);
                if (dist < 10)
                {
                    print(this.name);
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
        print("you are opening the door");
        collected = true;
        CollectedObjects++;
        yield return new WaitForSeconds(.5f);
        Object.SetActive(false);

    }
}
