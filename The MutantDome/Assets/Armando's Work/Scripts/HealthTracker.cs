using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTracker : MonoBehaviour {

	public int maxHP = 100; // the maximum HP for the unit this is attached to.

	int HP; // the current HP for unit

	// Use this for initialization
	void Start () {
		HP = maxHP;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (HP);
	}

	public void modHP (int HPAdjust){ // the function to modify the HP. Gets a adjustment modifier from DamageMod.cs
		HP = HP + HPAdjust;
		if (HP > maxHP) {
			HP = maxHP;
		}
	}

	public int getHealth (){ // used to get the current HP in another script
		return HP;
	}

}


