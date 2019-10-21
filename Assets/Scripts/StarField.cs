//* Morgan Joshua Finney
//* For Next Gen Games Jam
//* 12-03-18
//* makes the uv of an object move based on its global position

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarField : MonoBehaviour {

	public float parralax = 2f;		//* the difrance between the forgroud and background speed
	
	// Update is called once per frame
	void Update () {

        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = mr.material;
        Vector2 offset = mat.mainTextureOffset;
        offset.x = transform.position.x / transform.localScale.x / parralax;
        offset.y = transform.position.y / transform.localScale.y / parralax;
        mat.mainTextureOffset = offset;
    }
}
