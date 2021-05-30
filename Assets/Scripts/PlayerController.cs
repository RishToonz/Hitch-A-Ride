using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed;

	public float jumpForce;

	private float moveInput;

	private Rigidbody2D rb;

	private bool facingRight = true;

	private bool isGrounded;

	public Transform groundCheck;

	public float checkRadius;

	public LayerMask whatIsGround;

	private int extraJumps;

	public int extraJumpsValue;
	// Start is called before the first frame update
    void Start()
    {
	    extraJumps = extraJumpsValue;
	    rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
	    isGrounded = Physics2D.OverlapCircle(groundCheck.position,checkRadius, whatIsGround);
	    
	    moveInput = Input.GetAxis("Horizontal");
	    rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

	    if (facingRight == false && moveInput > 0)
	    {
		    Flip();
	    }

	    else if (facingRight == true && moveInput <0)
	    {
		    Flip();
	    }
	    
	}

    void Update()
    {
	    if (isGrounded == true)
	    {
		    extraJumps = extraJumpsValue;
	    }
	    
	    if (Input.GetButtonDown("Jump") && extraJumps > 0)
	    {
			rb.velocity = Vector2.up * jumpForce;
			extraJumps--;
	    }
		else if (Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)
	    {
		    rb.velocity = Vector2.up * jumpForce;
		}
    }
    
    void Flip()
    {
	    facingRight = !facingRight;
	    Vector3 Scaler = transform.localScale;
	    Scaler.x *= -1;
	    transform.localScale = Scaler;
    }

   
}
