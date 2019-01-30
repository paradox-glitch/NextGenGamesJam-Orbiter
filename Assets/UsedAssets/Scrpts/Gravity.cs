//* Morgan Joshua Finney
//* For Next Gen Games Jam
//* 12-03-18
//* makes a object sling shot around another object when within the gravity filed, if the objects collide the explode. also adds a visable number to the planet in the playable game.




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//* script will only work if there is a rigid body
[RequireComponent (typeof (Rigidbody))]
public class Gravity : MonoBehaviour {




	public GameObject playerGameObject;						//* defines player 
	public float gravityAmount = 1000f;						//* the amount the gravity effect the ship
	public float gravityRemove = 0f;						//* used to stop the application of gravity
	public float gravityRadius = 10f;						//* the area around he planet effected by gravity
	public Color effectRadiusMarkerColor = Color.blue;		//* used for debuging shows the effect area of the gravity in game
	Vector3 targetDirection;								//* the difrance in position between player and planet
	float distance;											//* the calculated distace between the player and an object
	float rotSpeed = 180f;									//* the speed the ship can rotate around the planet
	bool playerOverPlanet = false;							//* shows if the player has been over the planet
	bool noRepeat = false;									//* stops an if in update constantly updateing
	bool clockWise = false;									//* if true he player is traviling clockwise if false anticlockwise
	float recheck;											//* used to time a value
	bool noRecheck = false;									//* makes a if funcktion only work opce
	float playerX;											//* the players x cords
	float playerY;											//* the players y cords
	float planetX;											//* the planets x cords
	float planetY;											//* the planets y cords
	bool noJoltCW;											//* added to stop the layer glitching when recheck and going clock wise 
	bool noJoltACW;											//* added to stop the layer glitching when recheck and going clock wise 
	float GSFtime;											//* used to time the gravity destabilzer
	float GSFtimeNext = 8f;							//* the time when it will fail
	public int planetNum;									//* the number of the current planet
	public Text planetNuberText;							//* the ui element to display the number in game
	public Text gameOverText;								//* the ui element to show game over on screen
	public GameObject explosion;							//* a referance to a prefab for explosion




    void Start()
    {


		//* finds the player ship and sets it to a verable
		playerGameObject = GameObject.FindWithTag("Player");


		//* sets the default scene gravity to 0
        Physics.gravity = Vector3.zero;


		//* shows the planet number in game
		string planetNumberString = string.Format ("{0:0}", planetNum);
		planetNuberText.text = planetNumberString;
    }




    void Update()
    {


		//* if player is not found repeats the function
		if (playerGameObject == null) {
			Start();
		}


		//* calculates the distance from player to planet
		distance = Vector3.Distance(playerGameObject.transform.position, transform.position);


		//* works out weather the ship is bellow, to the left , abobe or the right of the planet
		targetDirection = transform.position - playerGameObject.transform.position;
        targetDirection = targetDirection.normalized;


		//* if the ship is in the gravity filed of the planet
        if (distance < gravityRadius)
        {


			//* timer works out if player has been in orbit to long if they have it causes the player to crash
			GSFtime += Time.deltaTime;
			if (GSFtime > GSFtimeNext)
			{
				gravityAmount *= 2f;
				GSFtimeNext += 0.5f;
			}


			Debug.Log ("PlayerInGravityFiled");


			//* adds the gravity to the player and draws them towards the planet
			playerGameObject.GetComponent<Rigidbody>().AddForce(targetDirection * gravityAmount * Time.deltaTime);


			//* finds and sets the player and planet positions to veribles 
			playerX = playerGameObject.transform.position.x;
			playerY = playerGameObject.transform.position.y;
			planetX = transform.position.x;
			planetY = transform.position.y;


			//* if the player is directly above the planet and this hasent already been done send a debug line and changes a bool
			if (playerX + planetX > planetX + 0.005 && playerX + planetX > planetX - 0.005  && playerY > planetY && playerOverPlanet == false)
			{
				Debug.Log ("PlayerPlanetAllined");
				playerOverPlanet = true;
				noJoltCW = false;
				noJoltACW = false;
			}


			//* performs the frame after the line 81 and th bool is set
			//* if planetX is grater then it is moving anticlock wise noRepeate applied to stop wasted processing
			if (playerX < planetX && playerOverPlanet == true && noRepeat == false)
			{
				Debug.Log ("SetClockwise");
				clockWise = true;
				noRepeat = true;
			}

			//* if playerX is grater then it is moving clock wise noRepeate applied to stop wasted processing
			else if (playerX > planetX && playerOverPlanet == true && noRepeat == false)
			{
				Debug.Log ("SetAntiClockwise");
				clockWise = false;
				noRepeat = true;
			}



			//* performs the frame after the line 81 and the bool is set
			//* starts a timer
			if (playerOverPlanet == true) 
			{
				Debug.Log ("RecheckTimeing");
				recheck += Time.deltaTime;
			}

			//* waits for timer to reach 4 then resets it and rechecks the anti and clock wise code this only happens once
			if (recheck > 4 && clockWise == true)
			{
				Debug.Log ("RecheckTimed");
				noJoltCW = true;
				playerOverPlanet = false;
				noRepeat = false;
				recheck = 0;
				noRecheck = true;
			}

			if (recheck > 4 && clockWise == false)
			{
				noJoltACW = true;
				Debug.Log ("RecheckTimed");
				playerOverPlanet = false;
				noRepeat = false;
				recheck = 0;
				noRecheck = true;
			}


			//* anticlock wise code rotates the ship so the left side always faces the planet
			if (clockWise == false && playerOverPlanet == true && noRepeat == true)
			{
				Debug.Log ("RotatingAntiClockwise");
				Vector3 dir = transform.position - playerGameObject.transform.position;
				dir.Normalize();
				float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
				Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
				playerGameObject.transform.rotation = Quaternion.RotateTowards(playerGameObject.transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
			}

			//*clock wise code mkaes the right side of the ship face the planet
			else if (clockWise == true && playerOverPlanet == true && noRepeat == true)
			{
				Debug.Log ("RotatingClockwise");
				Vector3 dir = transform.position - playerGameObject.transform.position;
				dir.Normalize();
				float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 180;
				Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
				playerGameObject.transform.rotation = Quaternion.RotateTowards(playerGameObject.transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
			}
				

			//* nojolt continues to rotate the ship while the recheck is done
			if (noJoltACW == true)
			{
				Debug.Log ("RotatingAntiClockwise");
				Vector3 dir = transform.position - playerGameObject.transform.position;
				dir.Normalize();
				float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
				Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
				playerGameObject.transform.rotation = Quaternion.RotateTowards(playerGameObject.transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
			}


			else if (noJoltCW == true)
			{
				Debug.Log ("RotatingClockwise");
				Vector3 dir = transform.position - playerGameObject.transform.position;
				dir.Normalize();
				float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 180;
				Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
				playerGameObject.transform.rotation = Quaternion.RotateTowards(playerGameObject.transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
			}

		}
    }


	//* if an object hits the planet the player is destroyed
	void OnCollisionEnter()
	{
		Debug.Log ("GameOverCollision");
        string gameOverString = string.Format("GAME OVER");
        gameOverText.text = gameOverString;
        gameOverText.color = Color.red;
        gameOverText.fontSize = 300;
		Instantiate (explosion, playerGameObject.transform.position, playerGameObject.transform.rotation);
		Destroy (playerGameObject);
	}

	//* resets values when player leaves orbit
	private void OnTriggerExit()
	{
		Debug.Log ("PlayerLeftGravityFiled");
		bool playerOverPlanet = false;
		bool noRepeat = false;
		noRecheck = true;
		//* removed to improve realness of game
		//*playerGameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		//*playerGameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
	}


	//* draws a debuging gizmo for gameplay testing
    void OnDrawGizmos()
    {
        Gizmos.color = effectRadiusMarkerColor;
        Gizmos.DrawWireSphere(transform.position, gravityRadius);
    }
}
