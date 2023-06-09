﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableFlipL: MonoBehaviour {

	public Animator FlipL;
	public bool open;
	public GameObject Player;

	void Start (){
		open = false;
		Player = GameObject.FindGameObjectWithTag("Player");
	}

	void OnMouseOver (){
		{
			if (Player) {
				float dist = Vector3.Distance (Player.transform.position, transform.position);
				if (dist < 15) {
					if (open == false) {
						if (Input.GetMouseButtonDown (0)) {
							StartCoroutine (opening ());
						}
					} else {
						if (open == true) {
							if (Input.GetMouseButtonDown (0)) {
								StartCoroutine (closing ());
							}
						}

					}

				}
			}

		}

	}

	IEnumerator opening(){
		print ("you are opening the door");
        FlipL.Play ("Lup");
		open = true;
		yield return new WaitForSeconds (.5f);
	}

	IEnumerator closing(){
		print ("you are closing the door");
        FlipL.Play ("Ldown");
		open = false;
		yield return new WaitForSeconds (.5f);
	}


}

