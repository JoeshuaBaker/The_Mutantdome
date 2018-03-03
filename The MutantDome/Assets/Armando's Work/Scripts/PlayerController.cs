using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float maxspeed = 10f;

	public int playerDamageMod = 0;

	private Vector2 movement = new Vector2(0f,0f);

	Rigidbody2D rb;

	bool facingright = true; //will be used to orient the sprite in either left or right direction
	bool facingdown = true; //will be used to orient the sprite in up or down direction (down is towards the camera)


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
		Attack ();

		if (GetComponent<HealthTracker> ().getHealth () <= 0) {
			SceneManager.LoadScene (2);
		}
	}

	void Movement () {

		if (Input.GetKey ("right") || Input.GetKey ("d")) {
			movement.x = maxspeed;
		} else if (Input.GetKey ("left") || Input.GetKey ("a")) {
			movement.x = maxspeed * -1;
		} else {
			movement.x = 0;
		}

		if (Input.GetKey ("up") || Input.GetKey ("w")) {
			movement.y = maxspeed;
		} else if (Input.GetKey ("down") || Input.GetKey ("s")) {
			movement.y = maxspeed * -1;
		} else {
			movement.y = 0;
		}

		rb.velocity = movement;
	}

	void Attack(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			GetComponent<DamageMod> ().damageMod = playerDamageMod;
		} else if (Input.GetKeyUp (KeyCode.Space)) {
				GetComponent<DamageMod> ().damageMod = 0;
		}
	}
}
