using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSpawner : MonoBehaviour
{
    public bool isDrawer;

    [System.Serializable]

    public struct Spawnable
    {
        public GameObject gameObject;

        public float weight;
    }

    public float spawnTime = 1f;

    public List<Spawnable> items = new List<Spawnable>();
    float totalWeight;

    private void Awake()
    {
        totalWeight = 0;

        foreach (var Spawnable in items)
        {
            totalWeight += Spawnable.weight;
        }
    }


    private void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnTime);
    }

    void SpawnObject()
    {
        float pick = Random.value * totalWeight;
        int chosenIndex = 0;
        float Cumweight = items[0].weight;

        while (pick > Cumweight && chosenIndex < items.Count - 1)
        {
            chosenIndex++;
            Cumweight += items[chosenIndex].weight;
        }

        GameObject i = Instantiate(items[chosenIndex].gameObject, transform.position, Quaternion.identity);
        i.AddComponent<Rigidbody>();

        //add frenzy items falling when selected
    }
}

