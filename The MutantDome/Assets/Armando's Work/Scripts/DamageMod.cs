// Attach this script to the interactibles, i.e. enemies, traps, health packs. Will require modification for attacks.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMod : MonoBehaviour {

	public int damageMod = 10; // is the modifier to the health. positive adds health, negative removes it.

	void OnCollisionEnter2D (Collision2D collision){ // on collision applies the damageMod
		collision.transform.GetComponent<HealthTracker>().modHP(damageMod);
	}
}
