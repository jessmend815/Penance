using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //Singleton behavior for player
    public static PlayerController player;
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
    bool pistolUnlocked = false;
    bool machinegunUnlocked = false;
    bool shotgunUnlocked = false;
    public Weapons curWeapon = Weapons.knife;
    public float cools = 0f;
    //Variables for animation
    //Sprite order: right, up, left, down
    public Sprite[] facingSprites;
    SpriteRenderer rend;
    public GameObject weaponPos;
    public float[] weaponPositions;
    int currentPos = 0;
    public Animator weaponAnim;
    SpriteRenderer weaponRend;
    //Variable Blood
    public float blood;
    //Shop Variables
    public float time;

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
        weaponRend = GetComponentInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        //Move inputs
		Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		moveVelocity = moveInput.normalized * regSpd;

        //Move dude
        rb.velocity = moveVelocity;
        //if (moveInput.x != 0) rb.AddForce(Vector2.right * speed * moveInput.x * Time.fixedDeltaTime);
        //if (moveInput.y != 0) rb.AddForce(Vector2.up * speed * moveInput.y * Time.fixedDeltaTime);
        
        //Attack button
        if (Input.GetMouseButton(0) && cools <= 0f)
        {
            Attack();
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
            currentPos = 0;
        }
        //Facing up
        else if (worldPos.x < 0.5f && worldPos.y > 0.5f)
        {
            rend.flipX = true;
            rend.sprite = facingSprites[1];
            currentPos = 1;
        }

        //Facing left
        else if (worldPos.x <= 0.5f && worldPos.y <= 0.5f)
        {
            rend.flipX = true;
            rend.sprite = facingSprites[0];
            currentPos = 2;
        }
        //Facing down
        else
        {
            rend.flipX = true;
            rend.sprite = facingSprites[3];
            currentPos = 3;
        }
        //Set the position of the weaponPos gameobject
        weaponPos.transform.localPosition = new Vector2(weaponPositions[currentPos], weaponPos.transform.localPosition.y);
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
        cools = 1.25f;
    }

    void pistol()
    {

    }

    void machinegun()
    {

    }

    void shotgun()
    {

    }
}
