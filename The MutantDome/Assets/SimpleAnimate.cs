using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAnimate : MonoBehaviour {
	//public vars to be changed in the editor
	public bool loop;				//bool that controls if animator loops
	public float frameSeconds = 1;	//how often to change frames. Defaults to 1 second.
	public string location;			//File path to the folder where sprite frames are located.

	//private vars to be used within the class
	private SpriteRenderer spr;		//SpriteRenderer reference on this object
	private Sprite[] sprites;		//Array of sprites, loaded from filepath provided above
	private int frame = 0;			//counter for which frame of the sprites we are on
	private float deltaTime = 0;	//deltaTime represents time between game tick updates.

	// Use this for initialization
	void Start () {
		//initialize the sprite renderer
		spr = GetComponent<SpriteRenderer> ();

		//load sprites from filePath. Will load the entire folder.
		sprites = Resources.LoadAll<Sprite> (location);
	}
	
	// Update is called once per frame
	void Update () {
		//increment deltaTime
		deltaTime += Time.deltaTime;

		//if enough time has passed to advance the frame...
		while (deltaTime >= frameSeconds) {
			//subtract our frameSeconds to begin tracking again from near zero
			deltaTime -= frameSeconds;

			//move frame counter 1 forward
			frame++;

			if (loop) {
				frame %= sprites.Length;	//if we loop, go back to beginning
			} else if (frame >= sprites.Length) {
				frame = sprites.Length - 1;	//else, sit on last frame forever
			}

			//index into sprites array using the frame counter, and set the spriteRenderer to that sprite
			spr.sprite = sprites [frame];
		}


	}
}
