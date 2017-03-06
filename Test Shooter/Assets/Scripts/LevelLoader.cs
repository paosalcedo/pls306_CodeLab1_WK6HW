using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	GameObject enemy;
	GameObject[] enemies;
	public float offsetX = 0;
	public float offsetY = 0;

	public string[] fileNames;
	public static int levelNum = 0;

	// Use this for initialization
	void Start ()
	{
		string fileName = fileNames [levelNum];

		string filePath = Application.dataPath + "/" + fileName;

		StreamReader sr = new StreamReader (filePath);

		GameObject levelHolder = new GameObject ("Level Holder");

		int yPos = 0;


		while (!sr.EndOfStream) {
			string line = sr.ReadLine ();

			for (int xPos = 0; xPos < line.Length; xPos++) {

				if (line [xPos] == 'x') {
					GameObject cube = Instantiate (Resources.Load ("Prefabs/Tile01") as GameObject);

					cube.transform.parent = levelHolder.transform;

					cube.transform.position = new Vector3 (
						xPos + offsetX, 
						yPos + offsetY, 
						0);
				}
			
				//Instantiate player1
				if (line [xPos] == 'p') { 
					GameObject player = Instantiate (Resources.Load ("Prefabs/Player") as GameObject);
					player.transform.position = new Vector3 (
						xPos + offsetX, 
						yPos + offsetY, 
						0f);
				}
				//Instantiate player2
				if (line [xPos] == 'e') {
					GameObject enemy = Instantiate (Resources.Load ("Prefabs/Enemy") as GameObject); 
					enemy.transform.position = new Vector3 (
						xPos + offsetX, 
						yPos + offsetY, 
						0f);
				}

				//Instantiate ice tiles
				if (line [xPos] == '-') {
					GameObject tile = Instantiate (Resources.Load("Prefabs/icetile") as GameObject);
					tile.transform.position = new Vector3(
						xPos + offsetX,
						yPos + offsetY,
						0f
						);
				}		
			
			}
			
			yPos--;
		}

		sr.Close();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P)){
			levelNum++;
			SceneManager.LoadScene("test");
		}
	}
//
//	void EndLevel ()
//	{
//		enemies = GameObject.FindGameObjectsWithTag("Enemy");
//
//		foreach (GameObject 
//	}
}