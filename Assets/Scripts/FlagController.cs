//Add to Flags
//Add BoxCollider
//Set Box collider to trigger
//set "Level2" to the name of the next Level
//Make sure you add all the levels in the build settings


using UnityEngine;
using System.Collections;

public class FlagController : MonoBehaviour {

	public int requiredShards = 3;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	// Called when this collides with another 2D collider
	void OnTriggerEnter2D(Collider2D c)
	{
		// If collision is with the player...
		if (c.tag == "Player") {
			Player player = c.gameObject.GetComponent<Player>();
			if (player.sunshards >= requiredShards)
			{

				Application.LoadLevel("Level2");
			}
		}
	}
}
