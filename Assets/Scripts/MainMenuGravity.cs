//* Morgan Joshua Finney
//* For Next Gen Games Jam
//* 12-03-18
//* makes a object sling shot around another object when within the gravity filed, if the objects collide the explode. also adds a visable number to the planet in the playable game.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//* makes sure there is a rb componant
[RequireComponent (typeof (Rigidbody))]
public class MainMenuGravity : MonoBehaviour {

	public GameObject playerGameObject;						//*  the ingame player
	public float gravityAmount = 1000f;						//*  force of gravity
	public float gravityRadius = 10f;						//*  effective range of gravity
	public Color effectRadiusMarkerColor = Color.blue;		//*  color of debuging gizmoz
	Vector3 targetDirection;								//*  diffrance between player and planet
	float distance;											//*  distance between player and planet
	float rotSpeed = 180f;									//*  rot speed of player
	bool playerOverPlanet = false;							//*  if player has been over planet
	bool noRepeat = false;									//*  stops a loop
	bool clockWise = false;									//*  make sure of CW or ACW
	float recheck;											//*  time of reck
	bool noRecheck = false;									//*  stops reck
	float playerX;											//* player pos
	float playerY;											//*  play pos
	float planetX;											//* plnet pos
	float planetY;											//*  plnet pos
	bool noJoltCW;											//*  stops glitch
	bool noJoltACW;											//*  stops movemnt glitch
	float letGo;											//*  makes the plnet let go after time
	const int letItGo = 6;									//*  time untill let go
	bool letItNotTurn = false;								//*  stops turning

	void Start()
	{

		//* sets the default level gravity to 0
		Physics.gravity = Vector3.zero;
	}




	void Update()
	{

		//* calculates the distance from player to planet
		distance = Vector3.Distance (playerGameObject.transform.position, transform.position);


		//* works out weather the ship is bellow, to the left , abobe or the right of the planet
		targetDirection = transform.position - playerGameObject.transform.position;
		targetDirection = targetDirection.normalized;


		//* if the ship not in gravcity
		if (distance > gravityRadius) {
			letItNotTurn = false;
			letGo = 0;
		}

		//* if ship is in gravity
		if (distance < gravityRadius) {

			//*  let it go timer and function
			letGo += Time.deltaTime;
			if (letGo > letItGo) {
				Debug.Log ("LetItGo");
				gravityAmount = 0.0f;
				letItNotTurn = true;
			}

			Debug.Log ("PlayerInGravityFiled");


			//* adds the gravity to the player and draws them towards the planet
			playerGameObject.GetComponent<Rigidbody> ().AddForce (targetDirection * gravityAmount * Time.deltaTime);

			//* turns ship as long as let it go it true
			if (letItNotTurn == false) {

				Vector3 dir = transform.position - playerGameObject.transform.position;
				dir.Normalize ();
				float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
				Quaternion desiredRot = Quaternion.Euler (0, 0, zAngle);
				playerGameObject.transform.rotation = Quaternion.RotateTowards (playerGameObject.transform.rotation, desiredRot, rotSpeed * Time.deltaTime);

			}
		}
	}

	private void OnTriggerExit()
	{
		//*  resets values
		Debug.Log ("PlayerLeftGravityFiled");
		playerGameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		playerGameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		letItNotTurn = false;
	}


	//* draws debuging gizmoz
	void OnDrawGizmos()
	{
		Gizmos.color = effectRadiusMarkerColor;
		Gizmos.DrawWireSphere(transform.position, gravityRadius);
	}
}
