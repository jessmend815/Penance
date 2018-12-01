using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //Variables for movement
	public float speed;
	private Rigidbody2D rb;
	private Vector2 moveVelocity;
    //Variables for shooting
    public enum Weapons { knife, pistol, machinegun, shotgun };
    public Weapons curWeapon = Weapons.knife;
    public float cools = 0f;
    //
    
	void Awake () 
	{
		rb = GetComponent<Rigidbody2D>();
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
