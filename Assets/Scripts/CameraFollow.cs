//* Morgan Joshua Finney
//* For Next Gen Games Jam
//* 12-03-18
//* makes a object such as a camra follow another object with out being atached. so when the main one is destroyed the secondy one is not.




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {




	public GameObject player; //* varable of the players ship
    private Vector3 offset; //* variable of the distance between player and camera




	// Use this for initialization
	void Start () {


		//* finds the player in the game 
		player = GameObject.FindWithTag("Player");


		//* calculates the diffrance between the player and camra
        offset = transform.position - player.transform.position;
	}




	// Update is called once per each frame
	void Update () {


		//* if the player is missing it recalls the start function to find it
		if (player == null) {
			Start();
		}


		//* sets the position of the camera based on the players position and the offset
        transform.position = player.transform.position + offset;
	}
}
