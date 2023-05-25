using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Objectives : MonoBehaviour
{
    public int numofapp;
    public int numofart;
    public int numofele;
    public int numofwin;

    bool objectiveactive;

    public TextMeshProUGUI ObjectiveName;
    public TextMeshProUGUI numbercollected;
    public TextMeshProUGUI completed;
    public TextMeshProUGUI loading;

    int totalcollected;
    int random;
    int objective;
    int currenttotal;

    void Start()
    {
        ObjectiveName.text = "";
        numbercollected.text = "";
        completed.text = "";
    }

    private void Update()
    {
        numofapp = GameObject.FindGameObjectsWithTag("Appliances").Length;
        numofart = GameObject.FindGameObjectsWithTag("Artwork").Length;
        numofele = GameObject.FindGameObjectsWithTag("Electronics").Length;
        numofwin = GameObject.FindGameObjectsWithTag("Wine").Length;

        if (!objectiveactive)
        {
            objectiveactive = true;
            Objective();
        }
    }

    private void Objective()
    {
        objectiveactive = true;
        totalcollected = 0;
        currenttotal = 0;

        random = Random.Range(1, 5);
        print(random);

        if (random == 1)
        {
            loading.text = "";
            ObjectiveName.text = "Collect Appliances";
            objective = Random.Range(1, numofapp / 2);

            while (random == 1)
            {
                if (leavescene.TotalAppliances != currenttotal)
                {
                    totalcollected++;
                    currenttotal = leavescene.TotalAppliances;
                }

                numbercollected.text = totalcollected.ToString() + objective;
                if (totalcollected == objective)
                {
                    completed.text = "Objective Complete!";
                    numbercollected.text = "";
                    ObjectiveName.text = "";
                    completed.text = ("");
                    loading.text = "Objective Loading";
                    random = 0;
                }
            }
        }

        if (random == 2)
        {
            loading.text = "";
            ObjectiveName.text = "Collect Artwork";
            objective = Random.Range(1, numofart / 2);

            while (random == 2)
            {
                if (leavescene.TotalArtwork != currenttotal)
                {
                    totalcollected++;
                    currenttotal = leavescene.TotalArtwork;
                }

                numbercollected.text = totalcollected.ToString() + objective;
                if (totalcollected == objective)
                {
                    completed.text = "Objective Complete!";
                    numbercollected.text = "";
                    ObjectiveName.text = "";
                    completed.text = ("");
                    loading.text = "Objective Loading";
                    random = 0;
                }
            }
        }

        if (random == 3)
        {
            loading.text = "";
            ObjectiveName.text = "Collect Electronics";
            objective = Random.Range(1, numofele / 2);

            while (random == 3)
            {
                if (leavescene.TotalElectronics != currenttotal)
                {
                    totalcollected++;
                    currenttotal = leavescene.TotalElectronics;
                }

                numbercollected.text = totalcollected.ToString() + objective;
                if (totalcollected == objective)
                {
                    completed.text = "Objective Complete!";
                    numbercollected.text = "";
                    ObjectiveName.text = "";
                    completed.text = ("");
                    loading.text = "Objective Loading";
                    random = 0;
                }
            }
        }

        if (random == 4)
        {
            loading.text = "";
            ObjectiveName.text = "Collect Wine";
            objective = Random.Range(1, numofwin / 2);

            while (random == 3)
            {
                if (leavescene.TotalWine != currenttotal)
                {
                    totalcollected++;
                    currenttotal = leavescene.TotalWine;
                }

                numbercollected.text = totalcollected.ToString() + objective;
                if (totalcollected == objective)
                {
                    completed.text = "Objective Complete!";
                    numbercollected.text = "";
                    ObjectiveName.text = "";
                    completed.text = ("");
                    loading.text = "Objective Loading";
                    random = 0;
                }
            }
        }
    }
}