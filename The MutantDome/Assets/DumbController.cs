using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbController : MonoBehaviour {

	Rigidbody2D rb;
	Vector2 velocity = new Vector2();
	public float speed = 10;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update()
	{
		//var x = Input.GetAxis("Horizontal") * Time.deltaTime * 200.0f;
		//var z = Input.GetAxis("Vertical") * Time.deltaTime * 200.0f;

		if (Input.GetKey (KeyCode.RightArrow))
			velocity.x = speed;
		else if (Input.GetKey (KeyCode.LeftArrow))
			velocity.x = speed * -1;
		else
			velocity.x = 0;

		if (Input.GetKey (KeyCode.UpArrow))
			velocity.y = speed;
		else if (Input.GetKey (KeyCode.DownArrow))
			velocity.y = -1 * speed;
		else
			velocity.y = 0;

		rb.velocity = velocity;
	}
}
