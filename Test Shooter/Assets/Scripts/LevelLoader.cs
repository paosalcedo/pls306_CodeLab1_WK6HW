using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	[SerializeField]GameObject crosshair;
	GameObject enemy;
	GameObject[] enemies;
	public float offsetX = 0;
	public float offsetY = 0;
	public float tileZ;

	public string[] fileNames;
	public static int levelNum = 0;

	// Use this for initialization
	void Start ()
	{
		Cursor.visible = true;		
		Cursor.lockState = CursorLockMode.Confined;

		string fileName = fileNames [levelNum];

		string filePath = Application.dataPath + "/" + fileName;

		StreamReader sr = new StreamReader (filePath);

		GameObject levelHolder = new GameObject ("Level Holder");

		int yPos = 0;

		//Instantiate the crosshair.
		GameObject crosshair = Instantiate (Resources.Load("Prefabs/Crosshair") as GameObject);
	
		//Read from level text files.
		while (!sr.EndOfStream) {
			string line = sr.ReadLine ();

			for (int xPos = 0; xPos < line.Length; xPos++) {

				if (line [xPos] == 'x') {
					GameObject wall = Instantiate (Resources.Load ("Prefabs/Tile01") as GameObject);

					wall.transform.parent = levelHolder.transform;

					wall.transform.position = new Vector3 (
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
					GameObject tile = Instantiate (Resources.Load("Prefabs/Icetile") as GameObject);
					tile.transform.position = new Vector3(
						xPos + offsetX,
						yPos + offsetY,
						tileZ
						);
				}
				//Instantiate player2
				if (line [xPos] == 'e') {
					GameObject enemy = Instantiate (Resources.Load ("Prefabs/Enemy") as GameObject); 
					enemy.transform.position = new Vector3 (
						xPos + offsetX, 
						yPos + offsetY, 
						0f);
					GameObject tile = Instantiate (Resources.Load("Prefabs/Icetile") as GameObject);
					tile.transform.position = new Vector3(
						xPos + offsetX,
						yPos + offsetY,
						tileZ
						);
				}

				//Instantiate ice tiles
				if (line [xPos] == '-') {
					GameObject tile = Instantiate (Resources.Load("Prefabs/Icetile") as GameObject);
					tile.transform.position = new Vector3(
						xPos + offsetX,
						yPos + offsetY,
						tileZ
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