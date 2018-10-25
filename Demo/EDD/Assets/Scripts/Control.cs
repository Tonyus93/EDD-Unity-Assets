using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

    public float speed;
	public float jumpForce;
	private float velocityX;
	//Floating point variable to store the player's movement speed.
	
    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
	private Animator animator;
	private SpriteRenderer renderer;
	private bool isGrounded;
	private bool isMoving;
	private bool isWalled;
    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		renderer = GetComponent<SpriteRenderer> ();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
		velocityX = rb2d.velocity.x;
		isGrounded = animator.GetBool("isGrounded");
		isMoving = animator.GetBool("isMoving");
		animator.SetFloat("velocityY", rb2d.velocity.y);
		if (rb2d.velocity.y == 0) {
			animator.SetBool ("isGrounded", true);
		} else {
			animator.SetBool ("isGrounded", false);
		}
        //Horizontal movement.
        if (Input.GetAxis ("Horizontal") != 0) {
			animator.SetBool("isMoving", true);
			rb2d.velocity = new Vector2(Input.GetAxis ("Horizontal") * speed, rb2d.velocity.y);
			if (Input.GetAxis ("Horizontal") < 0) {
				renderer.flipX = true;
			} else {
				renderer.flipX = false;
			}
			if (velocityX == 0) {
				isWalled = true;
				animator.SetBool("isMoving", false);
			} else {
				isWalled = false;
			}
		}
		else {
			animator.SetBool("isMoving", false);
		}
		
		//Jump
		if (Input.GetButtonDown("Jump") && isGrounded && !isWalled) {
			animator.SetTrigger("jump");
			rb2d.AddForce(new Vector2 (0, jumpForce));
		}
    }

	void OnCollisionStay2D (Collision2D col) {
		if (col.collider.tag == "Ground") {
			animator.SetBool ("isGrounded", true);
		}
	}
}