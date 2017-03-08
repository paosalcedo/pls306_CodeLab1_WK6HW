using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHolder : MonoBehaviour {

	//Make a private int score
	private int score;

	//Make a public property "Score" that prints to
	//the console when you get/set it's value
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
