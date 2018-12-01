using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour {

	public float blood = PlayerController.Player.blood;
	public float currTime = PlayerController.Player.time;

	public void BuyTimeS(int cost)
	{
		if (blood <= cost)
		{
			time += 15;
		}
	}

	public void BuyTimeM(int cost)
	{
		if (blood <= cost)
		{
			time += 30;
		}
	}

	public void BuyTimeL(int cost)
	{
		if (blood <= cost)
		{
			time += 45;
		}
	}

}
