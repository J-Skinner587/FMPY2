using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class EndScreen : MonoBehaviour
{
    public TextMeshProUGUI titletext;
    public TextMeshProUGUI descriptiontext;

    private void Start()
    {
        if(leavescene.fail == true)
        {
            titletext.text = "Failure";
            descriptiontext.text = "You failed to reach your goal of 1000";
        }
    }
    public void Mainmenu()
    {

    }
}
