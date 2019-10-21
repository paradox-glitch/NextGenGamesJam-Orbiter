//* Morgan Joshua Finney
//* For Next Gen Games Jam
//* 12-03-18
//* alows the user to go to menu and reset the level

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour {

	bool back = false;			//* bool val
	bool reset = false;			//* bool val

	// Use this for initialization
	void FixedUpdate () {


		//* starts function dependant on bool
		if (back == true)
		{
			ExitMenu ();
		}

		if (reset == true)
		{
			ResetGame ();
		}

	}
	
	// Update is called once per frame
	void Update () {

		//* sets bool dependant on keypress
		if (Input.GetKeyDown("r"))
		{
			reset = true;
		}
		if (Input.GetKeyUp("r"))
		{
			reset = false;
		}
		if (Input.GetKeyDown("q"))
		{
			back = true;
		}
		if (Input.GetKeyUp("q"))
		{
			back = false;
		}

    }

	//* reloads the menu sence
	public void ExitMenu()
	{
		SceneManager.LoadScene(0);
	}

	//* reloads the curant scene
	public void ResetGame()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

}
