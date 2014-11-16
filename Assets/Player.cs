using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2(3, 5);

	public bool standing;
	public float jumpSpeed = 15f;
	public float airSpeedMultiplier = .3f;

	private PlayerController controller;

	void Start(){
		controller = GetComponent<PlayerController> ();
	}

	// Update is called once per frame
	void Update () {
		var forceX = 0f;
		var forceY = 0f;

		var absVelX = Mathf.Abs(rigid2D.velocity.x);
		var absVelY = Mathf.Abs(rigid2D.velocity.y);

		if (absVelX < .2f){
			standing = true;
		}else{
			standing = false;
		}

		if (controller.moving.x != 0){
			if (absVelX < maxVelocity.x){
				forceX = standing ? speed * controller.moving.x : (speed*controller.moving.x * airSpeedMultiplier);
				transform.localScale = new Vector3(forceX > 0 ? 1: -1, 1, 1);
			}
		}

		if (controller.moving.y > 0){
			if(absVelY < maxVelocity.y)
				forceY = jumpSpeed * controller.moving.y;
		}
		rigidbody2D.AddForce (new Vector2 (forceX, forceY));
	}
}
