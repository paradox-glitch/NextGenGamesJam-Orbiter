//* Morgan Joshua Finney
//* For Next Gen Games Jam
//* 12-03-18
//* gives the user instructions on start and then times them when they leave ther starting position and ends the timer when they cross the finish line

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public GameObject playerGameObject;		//* refances the ingame player
	public Transform player;				//* refrances the position of the ingame player
	public Text gameTimer;					//* refrances the ingame timer ui
	float seconds;							//* the currant seconds
	int minute = 0;							//* the currant min
	bool finish = false;					//* shows if we have been to the finish
	Vector3 originPos;						//* the original pos of the player

	// Use this for initialization
	void Start () {


		//* finds and defgines to verable the position of the player
		playerGameObject = GameObject.FindWithTag("Player");
		player = playerGameObject.transform;


		//* remembers the original pos of the player
		originPos = player.position;
	}




	// Update is called once per frame
	void Update () {

        //* starts the timer after the player leaves there original spot
        if (finish == false) {
			if (player.position != originPos) {
				seconds += Time.deltaTime;
				gameTimer.text = minute + "m:" + (int)seconds + "s";

				//* when 60 seconds, set 1 min, and reset sec to 0
				if (seconds > 60) {
					minute++;
					seconds = 0;
				}
			}
		}

		//* once the player has reached the finish the timr is no longer added to
		else if (finish == true) {
			gameTimer.text = minute + "m:" + (int)seconds + "s";
		}
	}


	//* stops player momentr and sets finish to true
	void OnTriggerEnter()
	{
		Debug.Log ("FinishCrossed");
		finish = true;
		playerGameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		playerGameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
	}
}
