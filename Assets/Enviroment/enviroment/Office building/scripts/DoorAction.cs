using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAction : MonoBehaviour
{


   

   

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
          
            RaycastHit hit;

            Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out hit);
            
                
                if (hit.transform.tag == "door")
                {

                hit.transform.gameObject.GetComponent<Door>().ActionDoor();


                }
        }

		
	}
}
