//attach to player
//make sure player.cs is also attached

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public Vector2 moving = new Vector2();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		moving.x = moving.y = 0;
		if (Input.GetKey ("right" || "D")) {
			moving.x = 1;
		} else if (Input.GetKey ("left" || "A")) {
			moving.x = -1;
		}

		if (Input.GetKey ("up" || "W" || "space")) {
			moving.y = 1;
		}
	}
}
