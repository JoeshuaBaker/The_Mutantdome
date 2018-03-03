using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	public GameObject player;

	float speed = 2.0f;
	private enum AIState {
		Slow, 
		Fuming, 
		Charging
	};

	private AIState currentState;
	private int AICounter = 0;

	private Vector3 directionToPlayer = new Vector3(0.0f, 0.0f, 0.0f);
	private Vector2 movementToPlayer = new Vector2(0.0f, 0.0f);

	// Use this for initialization
	void Start () {
		changeAIState (AIState.Slow);
	}
	
	// Update is called once per frame
	void Update () {
		if (currentState == AIState.Slow) {
			getDirectionToPlayer ();
			move ();
		} else if (currentState == AIState.Fuming) {
			AICounter++;
			if (AICounter > 90) {
				changeAIState (AIState.Charging);
			}
		} else if (currentState == AIState.Charging) {
			move ();
			speed -= 0.1f;
			AICounter++;
			if (AICounter > 60) {
				changeAIState (AIState.Slow);
			}
		}
	}

	void getDirectionToPlayer()
	{
		float playerX = player.transform.position.x;
		float playerY = player.transform.position.y;

		directionToPlayer.x = playerX - transform.position.x;
		directionToPlayer.y = playerY - transform.position.y;

		//directionToPlayer = Vector2.Distance (player.transform.position, this.transform.position);
		directionToPlayer = (directionToPlayer / directionToPlayer.magnitude);
	}

	void move()
	{
		movementToPlayer.x = (directionToPlayer.x * speed);
		movementToPlayer.y = (directionToPlayer.y*speed);
		this.GetComponent<Rigidbody2D> ().velocity = movementToPlayer;
	}

	void changeAIState(AIState newState)
	{
		currentState = newState;
		AICounter = 0;

		if (newState == AIState.Slow) {
			speed = 3.0f;
		} else if (newState == AIState.Fuming) {
			this.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			//TODO:have an animation controller that updates the sprite
		} else if (newState == AIState.Charging) {
			speed = 10.0f;
			getDirectionToPlayer ();
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (currentState == AIState.Slow) {
			changeAIState (AIState.Fuming);
		}
		if (currentState == AIState.Charging) {
			directionToPlayer = directionToPlayer * -1;
		}
	}
}
