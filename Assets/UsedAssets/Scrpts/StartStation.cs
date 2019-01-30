//* Morgan Joshua Finney
//* For Next Gen Games Jam
//* 12-03-18
//* if the player hits the object playership will explode. 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartStation: MonoBehaviour {

	public Text gameOverText;				//*  ingame ui
	public GameObject playerGameObject;		//*  the player
	public GameObject explosion;			//* explosion prefab

	// Use this for initialization
	void Start () {
		//* finds the player
		playerGameObject = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		//*  refinds the platyer
		playerGameObject = GameObject.FindWithTag("Player");
	}

	void OnCollisionEnter()
	{
		//* if playter hits the ship it will blow up and game over
		Debug.Log ("GameOverCollision");
		string gameOverString = string.Format("GAME OVER");
		gameOverText.text = gameOverString;
		gameOverText.color = Color.red;
		gameOverText.fontSize = 300;
		Instantiate (explosion, playerGameObject.transform.position, playerGameObject.transform.rotation);
		Destroy (playerGameObject);
	}
}
