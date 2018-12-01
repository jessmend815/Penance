using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour {

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
