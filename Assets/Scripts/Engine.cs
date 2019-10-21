//* Morgan Joshua Finney
//* For Next Gen Games Jam
//* 12-03-18
//* creates a singel point of propultion, with a main thurst and a secondery boost.




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour {




	float speed = 0f;				//* The current speed of the player
	float powerStage1 = 0.001f;		//* The thurst speed of the player
	float powerStage2 = 0.005f;		//* The hyper speed of the player
	bool stage1 = false;			//* Defines if the primary engine is on or off
	bool stage2 = false;			//* Defines if the secondary engine is on or off
	bool finishTF = false;			//* Defines if the finishline has been crossed
	public GameObject finish;		//* Referances the finishline




	// Use this for initialization
	void Start () {


		//* finds the finish line and sets it to the veriable
		finish = GameObject.Find("SpaceStationFinish");
	}




    // FixedUpdate is called when a value in Update is changed
    void FixedUpdate()
    {


		//* applies the speed of the player determind by bool value
        if (stage1 == true && stage2 == false)
        {
			Debug.Log ("PowerOnStage1");
            speed += powerStage1;
        }
        else if (stage1 == true && stage2 == true)
        {
			Debug.Log ("PowerOnStage2");
            speed += powerStage2;
        }
        else if (stage1 == false && stage2 == true)
        {
			Debug.Log ("PowerOnStage2");
            speed += powerStage2;
        }
        else if (stage1 == false && stage2 == false)
        {
			Debug.Log ("PowerOff");
            speed *= 0.9f;
        }
    }

    // Update is called once per frame
    void Update () {


		//* sets the speed bool values dependent on the users imput
		//* if the user is at the finish engines stop working
		if (finishTF == false) {
			if (Input.GetKeyDown ("z")) {
				stage1 = true;
			}
			if (Input.GetKeyUp ("z")) {
				stage1 = false;
			}
			if (Input.GetKeyDown ("x")) {
				stage2 = true;
			}
			if (Input.GetKeyUp ("x")) {
				stage2 = false;
			}
		}


		//* checks if the player is at the finish line
		if (Vector3.Distance (transform.position, finish.transform.position) < 5) {
			finishTF = true;
			stage1 = false;
			stage2 = false;
		}

		//* changes the position of the player based on the value of veriable speed
        transform.Translate(Vector3.up * -speed);
    }
}
