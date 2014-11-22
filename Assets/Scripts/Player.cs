//Make Player a Rigid 2D
//Make player a box Collider or circle Collider
//attach this file to player
//tag the player as 'Player'
using System.Collections;

public class Player : MonoBehaviour {

	public float jumpForce = 350.0f; // force applied vertically when the player jumps.
	public float moveForce = 150.0f; // movement speed
	public float maxSpeed = 5.0f; // maximum movement speed
	public int sunshards = 0; // number of pickups the player is holding
	public bool hasDoubleJump = false; // Boolean of weather player can do a double jump
	private bool facingRight = true; // flagged true if the player is facing right
	public bool canJump = false; //Test Boolean to try and get the infinite jumps fixed
	private bool jump; // flagged true if the player will jump next fixed fram
//	private float distToGround;
	public float GroundDistance;
//	public bool IsGrounded;
	// Use this for initialization
	void Start () {
		//distToGround = collider.bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () {



		// if the player is grounded and presses the jump button...
		if (Input.GetButtonDown ("Jump") && rigidbody2D.velocity.y==0) {
			jump = true; // flag them to jump next frame
			//canJump = false;
		}
		if (Input.GetButtonDown ("Jump") && hasDoubleJump && rigidbody2D.velocity.y != 0) {
			jump = true; // flag them to jump next frame
			hasDoubleJump = false;
		}



	}

	// FixedUpdate is called at fixed time intervals
	void FixedUpdate() {

		float h = Input.GetAxis ("Horizontal"); // cache horizontal input

			// if player is changing direction or hasn't reached speed cap yet...
			if (h * rigidbody2D.velocity.x < maxSpeed) {
					rigidbody2D.AddForce (Vector2.right * h * moveForce); // apply horizontal force
			}

			// if player's horizontal speed is greater than the speed cap...
			if (Mathf.Abs (rigidbody2D.velocity.x) > maxSpeed) {
				// enforce the speed cap
				rigidbody2D.velocity = new Vector2(Mathf.Sign (rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
			}

			// check if player is switching directions...
			if (h > 0 && !facingRight) {
				Flip ();
			}
			else if (h < 0 && facingRight) {
				Flip ();
			}

		// if the player is jumping this frame...
		if (jump) {
			rigidbody2D.AddForce(Vector2.up * jumpForce); // apply upwards force
			jump = false; // reset jump flag
		}
	}

	// Flip the direction the player is facing
	void Flip () {
		facingRight = !facingRight; // flip flag

		Vector3 ls = transform.localScale; // cache current scale
		ls.x *= -1; // flip horizontally
		transform.localScale = ls; // maintain scale
	}
	
}
