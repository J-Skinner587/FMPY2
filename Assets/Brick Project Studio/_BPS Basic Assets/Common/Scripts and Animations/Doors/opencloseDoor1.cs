﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class opencloseDoor1 : MonoBehaviour
	{

		public Animator openandclose1;
		public bool open;
		public GameObject Player;

		void Start()
		{
			Player = GameObject.FindGameObjectWithTag("Player");
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
								StartCoroutine(opening());
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
			openandclose1.Play("Opening 1");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the door");
			openandclose1.Play("Closing 1");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}