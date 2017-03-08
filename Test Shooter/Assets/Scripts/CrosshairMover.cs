using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairMover : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(0f,0f,0f);

	}
	
	// Update is called once per frame
	void Update () {
		FollowMouse();
	}

	void FollowMouse ()
	{
		var mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
		transform.position = mousePos;
	}

}

