using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShopController : MonoBehaviour {
	public List<GameObject> gameShop;
	GameObject[] NPC;
	void OnEnable()
	{
		NPC = GameObject.FindGameObjectsWithTag("NPC");
		for (int i = 0; i < NPC.Length; i++) 
		{
    		int x = Random.Range(0, gameShop.Count);
    		NPC[i].GetComponent<NPCController>().TestShop = gameShop[x];
    		gameShop.Remove(gameShop[x]);
		}
	}

	//Time Shop
	//Function for buying a small amount of time
	public void BuyTimeS(int cost)
	{
		float currBlood = PlayerController.player.blood;
		float currTime = PlayerController.player.time;		

		if (currBlood >= cost)
		{
			PlayerController.player.blood -= cost;
			PlayerController.player.time += 5;
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
			PlayerController.player.time += 10;
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
			PlayerController.player.time += 20;
		}
	}
	//End Of Time Shop

	//Weapons Shop
	//Function for buying Pistol
	public void BuyPistol(int cost)
	{
		PlayerController.player.pistolUnlocked = true;
	}
	//Function for buying Shotgun
	public void BuyShotgun(int cost)
	{
		PlayerController.player.shotgunUnlocked = true;
	}
	//Function for buying Machine Gun
	public void BuyMachine(int cost)
	{
		PlayerController.player.machinegunUnlocked = true;
	}
	//End Of Weapons Shop

	//Potion Shop
	//Function for buying a potion
	public void BuyPotion(int cost)
	{
		float currBlood = PlayerController.player.blood;
		if (currBlood >= cost)
		{
			PlayerController.player.blood -= cost;
			PlayerController.player.hp = PlayerController.player.maxHp;
		}
	}
	//End Of Potion Shop

	

	

}
