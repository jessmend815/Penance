using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour {
	//Function for buying a small amount of time
	public void BuyTimeS(int cost)
	{
		float currBlood = PlayerController.player.blood;
		float currTime = PlayerController.player.time;		

		if (currBlood >= cost)
		{
			PlayerController.player.blood -= cost;
			PlayerController.player.time += 15;
		}
	}
	//Function for buying a medium amount of time
	public void BuyTimeM(int cost)
	{
		float currBlood = PlayerController.player.blood;
		float currTime = PlayerController.player.time;
		if (currBlood >= cost)
		{
			PlayerController.player.blood -= cost;
			PlayerController.player.time += 30;
		}
	}
	//Function for buying a large amount of time
	public void BuyTimeL(int cost)
	{	
		float currBlood = PlayerController.player.blood;
		float currTime = PlayerController.player.time;
		if (currBlood >= cost)
		{
			PlayerController.player.blood -= cost;
			PlayerController.player.time += 45;
		}
	}

}
