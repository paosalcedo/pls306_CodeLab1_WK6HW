﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour {
	public float timer;
	[SerializeField]const float TIMER_RESET = 0.5f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Attack ();	
	}

	private void Attack ()
	{
		timer -= Time.deltaTime;
		if (timer <= 0) {
		GameObject fireball;
		fireball = Instantiate (Resources.Load ("Prefabs/Fireball") as GameObject);
		fireball.transform.position = transform.position;
		fireball.transform.rotation = transform.rotation;
		timer = TIMER_RESET;
		}
	}
}



