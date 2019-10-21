//* Morgan Joshua Finney
//* For Next Gen Games Jam
//* 12-03-18
//* creates a constant engine and lopps player round start screen


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuEngine : MonoBehaviour {

	float speed = 0f;			//*  curent speed
	float powerStage1 = 3f;		//*  main speed
	float timeout = 0f;			//*  currnt time out

	void FixedUpdate () {

		//*  sets speed
		speed = powerStage1;
	}

    // Update is called once per frame
    void Update () {

		//*  sets time 
		timeout += Time.deltaTime;

		//*  changes pos basded on speed
		transform.Translate(Vector3.up * -speed);




		//* whwn player hits edge it resets the player to the other side
		Vector3 pos = transform.position;

		if (pos.y > Camera.main.orthographicSize) {
			pos.y = -Camera.main.orthographicSize;
		}
		if (pos.y < -Camera.main.orthographicSize) {
			pos.y = Camera.main.orthographicSize;
		}

		float screenRatio = (float)Screen.width / (float)Screen.height;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;

		if (pos.x > widthOrtho) {
			pos.x = -widthOrtho;
		}
		if (pos.x < -widthOrtho) {
			pos.x = widthOrtho;
		}

	    transform.position = pos;
	}
}
