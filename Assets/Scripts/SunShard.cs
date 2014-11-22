using UnityEngine;
using System.Collections;

public class SunShard : MonoBehaviour {

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
		if (c.gameObject.tag == "Player") {
			Player player = c.gameObject.GetComponent<Player>();
			player.sunshards++;
			Destroy (gameObject);
		}
	}
}
