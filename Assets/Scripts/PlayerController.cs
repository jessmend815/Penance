using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    //Singleton behavior for player
    public static PlayerController player;
    public Vector3 startPos;
    //Variables for movement
	public float speed;
	private Rigidbody2D rb;
	private Vector2 moveVelocity;
    Vector2 dodgeVector;
    public float dodgeSpeed;
    public float regSpd;
    float dodgeCools = 0f;
    //Variables for shooting
    public enum Weapons { knife, pistol, machinegun, shotgun };
    public bool pistolUnlocked = false;
    public bool machinegunUnlocked = false;
    public bool shotgunUnlocked = false;
    public Weapons curWeapon = Weapons.knife;
    public float cools = 0f;
    public GameObject bullet;
    //Variables for animation
    //Sprite order: right, up, left, down
    public Sprite[] facingSprites;
    public SpriteRenderer rend;
    public GameObject weaponPos;
    public float[] weaponPositions;
    public Animator weaponAnim;
    public SpriteRenderer weaponRend;
    public Sprite[] weaponSprites;
    //Variable Blood
    public float blood;
    //Shop Variables
    public float time;
    public Text timeUI;
    //Health variables
    public int hp;
    public int maxHp = 100;
    //Game Object for information text
    public GameObject Information;
	void Awake ()
    {
        if (player == null)
            player = this;
        else if (player != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = facingSprites[3];

        startPos = transform.position;
	}

    private void OnEnable()
    {
        hp = maxHp;
        pistolUnlocked = false;
        machinegunUnlocked = false;
        shotgunUnlocked = false;
}

    // Update is called once per frame
    void Update () 
	{
        //Move inputs
		Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		moveVelocity = moveInput.normalized * regSpd;

        //Move dude
        rb.velocity = moveVelocity;
        
        //Attack button
        if (Input.GetMouseButton(0) && cools <= 0f)
        {
            Attack();
        }
        
        //Switch weapons with q
        if (Input.GetButtonDown("TabLeft"))
        {
            switch (curWeapon)
            {
                case Weapons.knife:
                    if (pistolUnlocked)
                    {
                        curWeapon = Weapons.pistol;
                    }
                    else if (machinegunUnlocked)
                    {
                        curWeapon = Weapons.machinegun;
                    }
                    else if (shotgunUnlocked)
                    {
                        curWeapon = Weapons.shotgun;
                    }
                    break;
                case Weapons.pistol:
                    if (machinegunUnlocked)
                    {
                        curWeapon = Weapons.machinegun;
                    }
                    else if (shotgunUnlocked)
                    {
                        curWeapon = Weapons.shotgun;
                    }
                    else
                    {
                        curWeapon = Weapons.knife;
                    }
                    break;
                case Weapons.machinegun:
                    if (shotgunUnlocked)
                    {
                        curWeapon = Weapons.shotgun;
                    }
                    else
                    {
                        curWeapon = Weapons.knife;
                    }
                    break;
                case Weapons.shotgun:
                    curWeapon = Weapons.knife;
                    break;
            }
        }

        //Decrement the cooldowns
        if (cools > 0) cools -= Time.deltaTime;
        if (dodgeCools > 0) dodgeCools -= 1;

        //Stuff to make the player face the right direction
        // Converts to a 0 to 1 scale
        var worldPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Facing right
        if (worldPos.x > 0.5f && worldPos.y > 0.5f)
        {
            rend.flipX = false;
            rend.sprite = facingSprites[0];
        }
        //Facing up
        else if (worldPos.x < 0.5f && worldPos.y > 0.5f)
        {
            rend.flipX = true;
            rend.sprite = facingSprites[1];
        }

        //Facing left
        else if (worldPos.x <= 0.5f && worldPos.y <= 0.5f)
        {
            rend.flipX = true;
            rend.sprite = facingSprites[0];
        }
        //Facing down
        else
        {
            rend.flipX = true;
            rend.sprite = facingSprites[3];
        }
        //Set the weapon sprite
        weaponAnim.SetInteger("curWeapon", (int)curWeapon);

        //Decrement the timer
        if (time > 0) time -= Time.deltaTime;
        //Update time UI
        if (timeUI != null)
        {
            timeUI.text = "Time remaining: " + Mathf.Round(time).ToString();
        }

        //Press I for help
        if (Input.GetKeyDown(KeyCode.I))
        {
            Information.SetActive(true);
        }
        else Information.GetComponent<FadeText>().fade = true;

        //Game Over Check
        if (hp <= 0)
        {
            SceneManager.LoadScene("GameOver");
            gameObject.SetActive(false);
        }
        else if (time <= 0)
        {
            SceneManager.LoadScene("TimeOut");
            gameObject.SetActive(false);
        }
        //End of update event
    }

	void FixedUpdate()
    {
        //Dodge dude
        if (Input.GetButtonDown("Fire3") && dodgeCools <= 0)
        {
            dodgeVector = moveVelocity;
            dodgeCools = 2.5f;
        }
        //Dodge
        if (dodgeCools > 0)
        {
            dodgeCools -= Time.deltaTime;
            rb.velocity = dodgeVector * dodgeSpeed;
        }
        
        //Change the scale of the weapons based on what you're holding
        if (curWeapon != Weapons.knife)
        {
            if (curWeapon != Weapons.shotgun)
            {
                weaponRend.transform.localScale = new Vector3(0.35f, 0.35f, 1);
            }
            else weaponRend.transform.localScale = new Vector3(0.275f, 0.275f, 1);
        }
        else
        {
            weaponRend.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        }
    }

    //Switch statement for the shooting enums
    //Carry out whichever weapon case you currently have equipped
    void Attack()
    {
        switch(curWeapon)
        {
            case Weapons.knife:
                knife();
                break;
            case Weapons.pistol:
                pistol();
                break;
            case Weapons.machinegun:
                machinegun();
                break;
            case Weapons.shotgun:
                shotgun();
                break;
        }
    }

    void knife()
    {
        weaponAnim.Play("SwordAttack");
        cools = 1.325f;
    }

    void pistol()
    {
        Instantiate(bullet, weaponPos.transform.position, weaponPos.transform.rotation);
        cools = 0.275f;
    }

    void machinegun()
    {
        Instantiate(bullet, weaponPos.transform.position, weaponPos.transform.rotation);
        cools = 0.1f;
    }

    //Spawn 3-5 instead of 1 and modify their rotation
    void shotgun()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject obj = Instantiate(bullet, weaponPos.transform.position, weaponPos.transform.rotation * Quaternion.Euler(0, 0, -30 + (i*15)));
        }
        cools = 2.5f;
    }
    
}
