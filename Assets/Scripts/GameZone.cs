//* Morgan Joshua Finney
//* For Next Gen Games Jam
//* 12-03-18
//* destroys the player if they go to far out

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameZone : MonoBehaviour {

	public GameObject playerGameObject;		//* refranxces the player
	public GameObject explosion;			//* defins the correct prefab to use
	public Text gameOverText;				//* ui elemnt

	void Start ()
	{
		//* finds the player
		playerGameObject = GameObject.FindWithTag("Player");
	}

	void Update()
	{
		//* if player is not found fin it
		if (playerGameObject == null) {
			Start();
		}
	}

	//* if polyer leavs the game zone - end game
	private void OnTriggerExit()
	{
		Debug.Log ("GameOverPlayerLeftGameZone");
		Instantiate(explosion, playerGameObject.transform.position, playerGameObject.transform.rotation);
		Destroy(playerGameObject);
		string gameOverString = string.Format("GAME OVER");
		gameOverText.text = gameOverString;
		gameOverText.color = Color.red;
		gameOverText.fontSize = 300;
	}

}
