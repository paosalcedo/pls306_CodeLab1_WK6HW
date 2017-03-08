using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHolder : MonoBehaviour {

	private int score = 100;

	public int Score{
		get{
			Debug.Log(score);
			return score;
		}

		set{
			score = value;
		}

	}

	public static ScoreHolder instance;
	// Use this for initialization
	void Start () {
		if(instance == null){
			instance = this;
			DontDestroyOnLoad(this);
		} else {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
