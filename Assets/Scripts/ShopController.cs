using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
			PlayerController.player.time += 10;
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
	//End Of Time Shop

	//Weapons Shop
	//Function for buying Pistol
	public void BuyPistol(int cost)
    {
        float currBlood = PlayerController.player.blood;
        if (currBlood >= cost)
        {
            PlayerController.player.pistolUnlocked = true;
            PlayerController.player.blood -= cost;
        }
	}
	//Function for buying Shotgun
	public void BuyShotgun(int cost)
    {
        float currBlood = PlayerController.player.blood;
        if (currBlood >= cost)
        {
            PlayerController.player.shotgunUnlocked = true;
            PlayerController.player.blood -= cost;
        }
	}
	//Function for buying Machine Gun
	public void BuyMachine(int cost)
    {
        float currBlood = PlayerController.player.blood;
        if (currBlood >= cost)
        {
            PlayerController.player.machinegunUnlocked = true;
            PlayerController.player.blood -= cost;
        }
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
