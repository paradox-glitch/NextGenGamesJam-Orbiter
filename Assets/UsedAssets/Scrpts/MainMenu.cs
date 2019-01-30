//* Morgan Joshua Finney
//* For Next Gen Games Jam
//* 12-03-18
//* main menu scripots

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject shipPrefab;

	SpriteRenderer sr;			//* the sprite renderer
	public Sprite sprite1;		//* one sprite
	public Sprite sprite2;		//* two sprite
	public Sprite sprite3;		//* three sprite


	//* function called from button - starts main game
    public void OpenGameLevel()
    {
        SceneManager.LoadScene(3);
    }

	//* function called from button - closes game
    public void QuitGame()
    {
        Application.Quit ();
    }

	//* function called from button - opens options
	public void OpenOptions()
	{
		SceneManager.LoadScene(1);
	}

	//* function called from button - opens how to
	public void OpenHowTo()
	{
		SceneManager.LoadScene(2);
	}

	//* function called from button - opens main menu
	public void OpenMainMenu()
	{
		SceneManager.LoadScene(0);
	}

	//* function called from button - changes sprtie of prefab player
	public void ChangeSprite1()
	{
		sr = shipPrefab.GetComponent<SpriteRenderer> ();
		sr.sprite = sprite1;
	}

	//* function called from button - changes sprtie of prefab player
	public void ChangeSprite2()
	{
		sr = shipPrefab.GetComponent<SpriteRenderer> ();
		sr.sprite = sprite2;
	}

	//* function called from button - changes sprtie of prefab player
	public void ChangeSprite3()
	{
		sr = shipPrefab.GetComponent<SpriteRenderer> ();
		sr.sprite = sprite3;
	}
}
