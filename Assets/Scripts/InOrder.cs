//* Morgan Joshua Finney
//* For Next Gen Games Jam
//* 12-03-18
//* makes sure the player goes to the numbered planets in order, if they do not there ship will explode. 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InOrder : MonoBehaviour {

	public GameObject planet01;				//* defines the planet game objects
	public GameObject planet02;
	public GameObject planet03;
	public GameObject planet04;
	public GameObject planet05;
	public GameObject planet06;
	public GameObject planet07;
	public GameObject planet08;
	public GameObject planet09;
	public GameObject planet10;
	public GameObject finish;				//* defins the finish
	bool vistedPlanet01 = false;			//* used to see if player has already been here
    bool vistedPlanet02 = false;
    bool vistedPlanet03 = false;
    bool vistedPlanet04 = false;
    bool vistedPlanet05 = false;
    bool vistedPlanet06 = false;
    bool vistedPlanet07 = false;
    bool vistedPlanet08 = false;
    bool vistedPlanet09 = false;
    bool vistedPlanet10 = false;
	const float visitedDistance = 4;		//* the distance needed to get points
	int planetCount = 0;					//* the currant number of visited planets
	float planetWait;						//* a timer
	const float planetWaitTime= 0.5f; 		//* time player has to wait for points
	public Text planetCountText;			//* ui element
	public GameObject explosion;			//* prefab
	public Text gameOverText;				//* ui element
	public GameObject mainTransform;		//* position of the camra
	public GameObject arrow;				//* refrance the arrow
	float rotSpeed = 360f;					//* rot speed of the arrow

    // Use this for initialization
    void Start () {
		AddPlanet ();
		AddText ();
	}


	//* finds the ingame text
	void AddText ()
	{
		planetCountText = GameObject.Find("Planet").GetComponent<Text>();
		gameOverText = GameObject.Find("GameOver").GetComponent<Text>();
	}

	//* finds ingame objects
	void AddPlanet () {
		planet01 = GameObject.Find("Planet01");
		planet02 = GameObject.Find("Planet02");
		planet03 = GameObject.Find("Planet03");
		planet04 = GameObject.Find("Planet04");
		planet05 = GameObject.Find("Planet05");
		planet06 = GameObject.Find("Planet06");
		planet07 = GameObject.Find("Planet07");
		planet08 = GameObject.Find("Planet08");
		planet09 = GameObject.Find("Planet09");
		planet10 = GameObject.Find("Planet10");
		finish= GameObject.Find("SpaceStationFinish");
		arrow = GameObject.Find("arrow");
		mainTransform = GameObject.FindWithTag ("MainCamera");
	}



	// Update is called once per frame
	void DirectionArrow ()
	{


		//* points the arrows the right way dependeant on scroer
		if (planetCount == 0) {
			Vector3 dir = planet01.transform.position - mainTransform.transform.position;
			dir.Normalize();
			float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
			arrow.transform.rotation = Quaternion.RotateTowards(arrow.transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
		}
		else if (planetCount == 1) {
			Vector3 dir = planet02.transform.position - mainTransform.transform.position;
			dir.Normalize();
			float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
			arrow.transform.rotation = Quaternion.RotateTowards(arrow.transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
		}
		else if (planetCount == 2) {
			Vector3 dir = planet03.transform.position - mainTransform.transform.position;
			dir.Normalize();
			float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
			arrow.transform.rotation = Quaternion.RotateTowards(arrow.transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
		}
		else if (planetCount == 3) {
			Vector3 dir = planet04.transform.position - mainTransform.transform.position;
			dir.Normalize();
			float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
			arrow.transform.rotation = Quaternion.RotateTowards(arrow.transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
		}
		else if (planetCount == 4) {
			Vector3 dir = planet05.transform.position - mainTransform.transform.position;
			dir.Normalize();
			float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
			arrow.transform.rotation = Quaternion.RotateTowards(arrow.transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
		}
		else if (planetCount == 5) {
			Vector3 dir = planet06.transform.position - mainTransform.transform.position;
			dir.Normalize();
			float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
			arrow.transform.rotation = Quaternion.RotateTowards(arrow.transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
		}
		else if (planetCount == 6) {
			Vector3 dir = planet07.transform.position - mainTransform.transform.position;
			dir.Normalize();
			float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
			arrow.transform.rotation = Quaternion.RotateTowards(arrow.transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
		}
		else if (planetCount == 7) {
			Vector3 dir = planet08.transform.position - mainTransform.transform.position;
			dir.Normalize();
			float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
			arrow.transform.rotation = Quaternion.RotateTowards(arrow.transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
		}
		else if (planetCount == 8) {
			Vector3 dir = planet09.transform.position - mainTransform.transform.position;
			dir.Normalize();
			float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
			arrow.transform.rotation = Quaternion.RotateTowards(arrow.transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
		}
		else if (planetCount == 9) {
			Vector3 dir = planet10.transform.position - mainTransform.transform.position;
			dir.Normalize();
			float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
			arrow.transform.rotation = Quaternion.RotateTowards(arrow.transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
		}
		else if (planetCount == 10) {
			Vector3 dir = finish.transform.position - mainTransform.transform.position;
			dir.Normalize();
			float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
			arrow.transform.rotation = Quaternion.RotateTowards(arrow.transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
		}
	}



	//* tells game what to happen when its at p1
	void PlanetCheck01 ()
	{
		//* givs points and upadtes ui
		if (planetCount == 0)
		{
			Debug.Log ("PlayerAtPlanet1");
			planetCount = 1;
			string planetTextString = string.Format("{0:0}/10", planetCount);
			planetCountText.text = planetTextString;
			vistedPlanet01 = true;
		}

		//* destroys object
		else if (planetCount != 0 || planetCount != 1)
		{
				Debug.Log ("GameOverPlanetSkiped-01");
				Instantiate(explosion, transform.position, transform.rotation);
				Destroy(gameObject);
				string gameOverString = string.Format("GAME OVER");
				gameOverText.text = gameOverString;
				gameOverText.color = Color.red;
				gameOverText.fontSize = 300;
		}
	}

	void PlanetCheck02 ()
	{
		if (planetCount == 1)
		{
			Debug.Log ("PlayerAtPlanet2");
			planetCount = 2;
			string planetTextString = string.Format("{0:0}/10", planetCount);
			planetCountText.text = planetTextString;
			vistedPlanet02 = true;
		}
		else if (planetCount != 1 || planetCount != 2)
		{
				Debug.Log ("GameOverPlanetSkiped-02");
				Instantiate(explosion, transform.position, transform.rotation);
				Destroy(gameObject);
				string gameOverString = string.Format("GAME OVER");
				gameOverText.text = gameOverString;
				gameOverText.color = Color.red;
				gameOverText.fontSize = 300;
		}
	}

	void PlanetCheck03 ()
	{
		if (planetCount == 2) {
			Debug.Log ("PlayerAtPlanet3");
			planetCount = 3;
			string planetTextString = string.Format ("{0:0}/10", planetCount);
			planetCountText.text = planetTextString;
			vistedPlanet03 = true;
		}
		else if (planetCount != 2 || planetCount != 3)
		{
				Debug.Log ("GameOverPlanetSkiped-03");
				Instantiate(explosion, transform.position, transform.rotation);
				Destroy(gameObject);
				string gameOverString = string.Format("GAME OVER");
				gameOverText.text = gameOverString;
				gameOverText.color = Color.red;
				gameOverText.fontSize = 300;
		}
	}

	void PlanetCheck04 ()
	{
		if (planetCount == 3)
		{
			Debug.Log ("PlayerAtPlanet4");
			planetCount = 4;
			string planetTextString = string.Format("{0:0}/10", planetCount);
			planetCountText.text = planetTextString;
			vistedPlanet04 = true;
		}
		else if (planetCount != 3 || planetCount != 4)
		{
				Debug.Log ("GameOverPlanetSkiped-04");
				Instantiate(explosion, transform.position, transform.rotation);
				Destroy(gameObject);
				string gameOverString = string.Format("GAME OVER");
				gameOverText.text = gameOverString;
				gameOverText.color = Color.red;
				gameOverText.fontSize = 300;
		}
	}

	void PlanetCheck05 ()
	{
		if (planetCount == 4)
		{
			Debug.Log ("PlayerAtPlanet5");
			planetCount = 5;
			string planetTextString = string.Format("{0:0}/10", planetCount);
			planetCountText.text = planetTextString;
			vistedPlanet05 = true;
		}
		else if (planetCount != 4 || planetCount != 5)
		{
				Debug.Log ("GameOverPlanetSkiped-05");
				Instantiate(explosion, transform.position, transform.rotation);
				Destroy(gameObject);
				string gameOverString = string.Format("GAME OVER");
				gameOverText.text = gameOverString;
				gameOverText.color = Color.red;
				gameOverText.fontSize = 300;
		}
	}

	void PlanetCheck06 ()
	{
		if (planetCount == 5)
		{
			Debug.Log ("PlayerAtPlanet6");
			planetCount = 6;
			string planetTextString = string.Format("{0:0}/10", planetCount);
			planetCountText.text = planetTextString;
			vistedPlanet06 = true;
		}
		else if (planetCount != 5 || planetCount != 6)
		{
				Debug.Log ("GameOverPlanetSkiped-06");
				Instantiate(explosion, transform.position, transform.rotation);
				Destroy(gameObject);
				string gameOverString = string.Format("GAME OVER");
				gameOverText.text = gameOverString;
				gameOverText.color = Color.red;
				gameOverText.fontSize = 300;
		}
	}

	void PlanetCheck07 ()
	{
		if (planetCount == 6)
		{
			Debug.Log ("PlayerAtPlanet7");
			planetCount = 7;
			string planetTextString = string.Format("{0:0}/10", planetCount);
			planetCountText.text = planetTextString;
			vistedPlanet07 = true;
		}
		else if (planetCount != 6 || planetCount != 7)
		{
				Debug.Log ("GameOverPlanetSkiped-07");
				Instantiate(explosion, transform.position, transform.rotation);
				Destroy(gameObject);
				string gameOverString = string.Format("GAME OVER");
				gameOverText.text = gameOverString;
				gameOverText.color = Color.red;
				gameOverText.fontSize = 300;
		}
	}

	void PlanetCheck08 ()
	{
		if (planetCount == 7)
		{
			Debug.Log ("PlayerAtPlanet8");
			planetCount = 8;
			string planetTextString = string.Format("{0:0}/10", planetCount);
			planetCountText.text = planetTextString;
			vistedPlanet08 = true;
		}
		else if (planetCount != 7 || planetCount != 8)
		{
				Debug.Log ("GameOverPlanetSkiped-08");
				Instantiate(explosion, transform.position, transform.rotation);
				Destroy(gameObject);
				string gameOverString = string.Format("GAME OVER");
				gameOverText.text = gameOverString;
				gameOverText.color = Color.red;
				gameOverText.fontSize = 300;
		}
	}

	void PlanetCheck09 ()
	{
		if (planetCount == 8)
		{
			Debug.Log ("PlayerAtPlanet9");
			planetCount = 9;
			string planetTextString = string.Format("{0:0}/10", planetCount);
			planetCountText.text = planetTextString;
			vistedPlanet09 = true;
		}
		else if (planetCount != 8 || planetCount != 9)
		{
				Debug.Log ("GameOverPlanetSkiped-09");
				Instantiate(explosion, transform.position, transform.rotation);
				Destroy(gameObject);
				string gameOverString = string.Format("GAME OVER");
				gameOverText.text = gameOverString;
				gameOverText.color = Color.red;
				gameOverText.fontSize = 300;
		}
	}

	void PlanetCheck10 ()
	{
		if (planetCount == 9)
		{
			Debug.Log ("PlayerAtPlanet10");
			planetCount = 10;
			string planetTextString = string.Format("{0:0}/10", planetCount);
			planetCountText.text = planetTextString;
			vistedPlanet10 = true;
		}
		else if (planetCount != 9 || planetCount != 10)
		{
				Debug.Log ("GameOverPlanetSkiped-10");
				Instantiate(explosion, transform.position, transform.rotation);
				Destroy(gameObject);
				string gameOverString = string.Format("GAME OVER");
				gameOverText.text = gameOverString;
				gameOverText.color = Color.red;
				gameOverText.fontSize = 300;
		}
	}

	void PlanetCheckFinish ()
	{
		if (planetCount == 10)
		{
			Debug.Log ("PlayerAtFinish");
			string gameOverString = string.Format("YOU WIN");
			gameOverText.text = gameOverString;
			gameOverText.color = Color.green;
			gameOverText.fontSize = 300;
		}
		else if (planetCount != 10)
		{
			Debug.Log ("GameOverPlanetSkiped-finish");
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy(gameObject);
			string gameOverString = string.Format("GAME OVER");
			gameOverText.text = gameOverString;
			gameOverText.color = Color.red;
			gameOverText.fontSize = 300;
		}
	}

	void Update () {

		//* if game object is missing refindas it
		if (planet01 == null) {
			Debug.Log ("not found");
			AddPlanet ();
		}

		//* timmer
        planetWait += Time.deltaTime;

		//* calls for arrow update
		DirectionArrow ();


		//* statrs each planet function if we are in perimetrt - use a loop
		if (Vector3.Distance (transform.position, planet01.transform.position) < visitedDistance && planetWait > planetWaitTime && vistedPlanet01 == false) {
			PlanetCheck01 ();
		}
		if (Vector3.Distance (transform.position, planet02.transform.position) < visitedDistance && planetWait > planetWaitTime && vistedPlanet02 == false) {
			PlanetCheck02 ();
		}
		if (Vector3.Distance (transform.position, planet03.transform.position) < visitedDistance && planetWait > planetWaitTime && vistedPlanet03 == false) {
			PlanetCheck03 ();
		}
		if (Vector3.Distance (transform.position, planet04.transform.position) < visitedDistance && planetWait > planetWaitTime && vistedPlanet04 == false) {
			PlanetCheck04 ();
		}
		if (Vector3.Distance (transform.position, planet05.transform.position) < visitedDistance && planetWait > planetWaitTime && vistedPlanet05 == false) {
			PlanetCheck05 ();
		}
		if (Vector3.Distance (transform.position, planet06.transform.position) < visitedDistance && planetWait > planetWaitTime && vistedPlanet06 == false) {
			PlanetCheck06 ();
		}
		if (Vector3.Distance (transform.position, planet07.transform.position) < visitedDistance && planetWait > planetWaitTime && vistedPlanet07 == false) {
			PlanetCheck07 ();
		}
		if (Vector3.Distance (transform.position, planet08.transform.position) < visitedDistance && planetWait > planetWaitTime && vistedPlanet08 == false) {
			PlanetCheck08 ();
		}
		if (Vector3.Distance (transform.position, planet09.transform.position) < visitedDistance && planetWait > planetWaitTime && vistedPlanet09 == false) {
			PlanetCheck09 ();
		}
		if (Vector3.Distance (transform.position, planet10.transform.position) < visitedDistance && planetWait > planetWaitTime && vistedPlanet10 == false) {
			PlanetCheck10 ();
		}
		if (Vector3.Distance (transform.position, finish.transform.position) < 5 && planetWait > planetWaitTime) {
			PlanetCheckFinish ();
		}


		}

	//* resets the timer 
	private void OnTriggerEnter()
    {
        planetWait = 0f;
    }

	//* resets the timer
	private void OnTriggerExit()
	{
		planetWait = 0f;
	}


	//* draws gizmoz for debuging
	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(planet01.transform.position, visitedDistance);
		Gizmos.DrawWireSphere(planet02.transform.position, visitedDistance);
		Gizmos.DrawWireSphere(planet03.transform.position, visitedDistance);
		Gizmos.DrawWireSphere(planet04.transform.position, visitedDistance);
		Gizmos.DrawWireSphere(planet05.transform.position, visitedDistance);
		Gizmos.DrawWireSphere(planet06.transform.position, visitedDistance);
		Gizmos.DrawWireSphere(planet07.transform.position, visitedDistance);
		Gizmos.DrawWireSphere(planet08.transform.position, visitedDistance);
		Gizmos.DrawWireSphere(planet09.transform.position, visitedDistance);
		Gizmos.DrawWireSphere(planet10.transform.position, visitedDistance);
	}
}
