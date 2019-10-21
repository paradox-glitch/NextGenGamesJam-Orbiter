//* Morgan Joshua Finney
//* For Next Gen Games Jam
//* 12-03-18
//* spawns the prefab

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

	public GameObject playerPrefab;		//* refrance the player prefab

	// Use this for initialization
	void Start () {

		//* creates the player prefab in game
		Instantiate (playerPrefab, transform.position, transform.rotation);

	}

}
