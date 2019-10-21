//* Morgan Joshua Finney
//* For Next Gen Games Jam
//* 12-03-18
//* restarts the level if the player has been destoyed

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour {

	public GameObject playerGameObject;		//* defins the player
	bool playerSearch = false;				//* stops the player search from looping
	float endGameWait = 0f;					//* timer befor restarting

	// Use this for initialization
	void Start () {
		//* looks for player ship
		playerGameObject = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

		//* if layer is missing find it
		if (playerGameObject == null)
		{
			playerGameObject = GameObject.FindWithTag("Player");

			//* starts timer if player is missing
			if (playerGameObject == null)
			{
				Debug.Log ("PlayerNotFound");
				endGameWait += Time.deltaTime;
			}
		}

		//* waits 3 secs befor restaring 
		if (endGameWait > 3)
		{
			Debug.Log ("Quit");
			Application.LoadLevel(Application.loadedLevel);
		}

}
}
