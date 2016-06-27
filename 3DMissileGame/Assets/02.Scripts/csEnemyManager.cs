using UnityEngine;
using System.Collections;

public class csEnemyManager : MonoBehaviour {
	public GameObject enemy1; 
	public GameObject enemy2; 
	public GameObject enemy3; 
	public GameObject enemy4; 
	public GameObject enemy5; 

	GameObject enemyObj;

	public float spawnTime = 10.0f; 

	int ranNum = 0;

	float deltaSpawnTime = 0.0f;

	int spawnCnt = 0; 
	int maxSpawnCnt = 4; 

	//GameObject[] enemyPool; 

	int poolSize = 10;

	public static int enemyNum;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(spawnCnt > maxSpawnCnt){
			return;
		}

		deltaSpawnTime += Time.deltaTime;

		if(deltaSpawnTime > spawnTime){
			deltaSpawnTime = 0.0f;


			//int x = Random.Range (0, 5);
			if(spawnCnt == 0){
				enemyObj = Instantiate(enemy1) as GameObject;
			}
			else if(spawnCnt == 1){
				enemyObj = Instantiate(enemy2) as GameObject;
			}
			else if(spawnCnt == 2){
				enemyObj = Instantiate(enemy3) as GameObject;
			}
			else if(spawnCnt == 3){
				enemyObj = Instantiate(enemy4) as GameObject;
			}
			else if(spawnCnt == 4){
				enemyObj = Instantiate(enemy5) as GameObject;
			}


			//enemyObj.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
			enemyObj.name = "Enemy_" + spawnCnt;
			++spawnCnt;
		}
		/*
		deltaSpawnTime += Time.deltaTime; 

		if (deltaSpawnTime > spawnTime) 

		{ 

			deltaSpawnTime = 0.0f; 



			for (int i=0; i<poolSize; i++) 
			{ 
				Debug.Log (i + "");

				if (enemyPool [i].activeSelf == true)
					continue;
				else {
					
					enemyPool [i].SetActive (true); 

					enemyPool [i].name = "Enemy_" + spawnCnt; 

					++spawnCnt; 

					break; 
				}
			} 

		} 
		*/
	}
}
