using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour {
	public bool isClose = false;
	public bool shopOpen = false;
	public GameObject TestShop;
	public float npcHp = 100;
	public GameObject deadNpc;
    public AudioClip[] welcome;
    AudioSource src;

    private void Awake()
    {
        src = GetComponent<AudioSource>();
    }

    public void TakeDamage(float damage)
	{
		npcHp -= damage;
		if (npcHp <= 0)
		{
			Instantiate(deadNpc, transform.position, Quaternion.identity);
            Destroy(gameObject);
		}
	}

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
            PlayerController.player.isInShop = false;
        }
	}
	
	private void Update () 
	{	//Opens Shop Menu When Pressing E
		if (isClose)
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
                PlayerController.player.isInShop = true;

                if (!shopOpen)
                    src.PlayOneShot(welcome[Random.Range(0, welcome.Length)]);

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
