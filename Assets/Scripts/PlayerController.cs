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
    //Variables for shooting
    public enum Weapons { knife, pistol, machinegun, shotgun };
    public Weapons curWeapon = Weapons.knife;
    public float cools = 0f;
    //Variables for animation
    //Sprite order: right, up, left, down
    public Sprite[] facingSprites;
    SpriteRenderer rend;
    
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
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		moveVelocity = moveInput.normalized * speed;

        if (Input.GetMouseButton(0) && cools <= 0f)
        {
            Attack();
        }

        if (cools > 0) cools -= Time.deltaTime;


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
            rend.flipX = false;
            rend.sprite = facingSprites[2];
        }
        //Facing down
        else
        {
            rend.flipX = true;
            rend.sprite = facingSprites[3];
        }
    }

	void FixedUpdate()
	{
		rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
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

        cools = 0.55f;
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
