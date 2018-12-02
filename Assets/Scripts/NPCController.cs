using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour {
	public bool isClose = false;
	public bool shopOpen = false;
	public GameObject TestShop;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			isClose = true;
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			isClose = false;
			shopOpen = false;
		}
	}
	
	private void Update () 
	{	//Opens Shop Menu When Pressing E
		if (isClose)
		{
			Debug.Log("Player is in range");

			if (Input.GetKeyDown(KeyCode.E))
			{
				shopOpen = true;

				if (shopOpen == true)
				{
					TestShop.SetActive(true);
				}
			}
			
		}
		//Closes Shop Menu
		if (isClose == false) 
		{
			TestShop.SetActive(false);
		}
	}
}
