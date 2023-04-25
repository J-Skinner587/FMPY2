using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class opencloseDoor : MonoBehaviour
	{
		[SerializeField]
		public Animator openandclose;
		public bool open;
		public GameObject Player;
		public bool locked;

		public GameObject FloatingTextPrefab;

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
								if(locked = !true)
								{
									StartCoroutine(opening());
                                }
								else
                                {
									DoorLocked("There are people inside. . .");
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
		void DoorLocked(string text)
        {
			if(FloatingTextPrefab)
            {
				GameObject prefab = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity);
				prefab.GetComponentInChildren<TextMesh>().text = text;
            }
        }
	}
}