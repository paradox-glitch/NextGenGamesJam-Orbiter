//* Morgan Joshua Finney
//* For Next Gen Games Jam
//* 12-03-18
//* backup of original gravity
//* makes a object sling shot around another object when within the gravity filed, if the objects collide the explode. also adds a visable number to the planet in the playable game.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (Rigidbody))]
public class GravityBackUp : MonoBehaviour {

    public Transform player;
    float rotSpeed = 180f;
    public Rigidbody playerRigidbody;
    public float gravityAmount = 1000f;
	public float gravityRemove = 0f;
    public float gravityRadius = 10f;
    public Color effectRadiusMarkerColor = Color.blue;
    Vector3 targetDirection;

	public int planetNum;
	public Text planetNuberText;

	public Text gameOverText;
	public GameObject explosion;

    void Start()
    {
        Physics.gravity = Vector3.zero;
		string planetNumberString = string.Format ("{0:0}", planetNum);
		planetNuberText.text = planetNumberString;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        targetDirection = transform.position - player.position;
        targetDirection = targetDirection.normalized;
        if (distance < gravityRadius)
        {
            playerRigidbody.AddForce(targetDirection * gravityAmount * Time.deltaTime);

			Vector3 dir = transform.position - player.position;
			dir.Normalize();
			float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
			player.rotation = Quaternion.RotateTowards(player.rotation, desiredRot, rotSpeed * Time.deltaTime);
        }
    }


	private void OnCollisionEnter()
	{
        string gameOverString = string.Format("GAME OVER");
        gameOverText.text = gameOverString;
        gameOverText.color = Color.red;
        gameOverText.fontSize = 300;
        Instantiate (explosion, transform.position, transform.rotation);
		Destroy (gameObject);
		Destroy (player);
	}

		
    void OnDrawGizmos()
    {
        Gizmos.color = effectRadiusMarkerColor;
        Gizmos.DrawWireSphere(transform.position, gravityRadius);
    }
}
