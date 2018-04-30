using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteLevelGenerator : MonoBehaviour {

	public GameObject platformPrefab;
	
	public GameObject Player;

	public int numPlatforms = 10;
	public float distance = 35.0f;
	public float levelWidth =15.0f;
	public float minY = 3f;
	public float maxY = 7f;

	private float currentHeight;
	private float nextTimePlayerHeight;

	public int counter;

	public static float deadline;
	
	// Use this for initialization
	void Start () {
		deadline = -10.0f;
		counter = 0;
		nextTimePlayerHeight = Player.transform.position.y+distance;
		// currentHeight = Player.transform.position.y - 35f;
		// InstantiateObjects();
		currentHeight = Player.transform.position.y;
		// First instantiate 5 objects
		InstantiateObjects();
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.transform.position.y>nextTimePlayerHeight){
			nextTimePlayerHeight = Player.transform.position.y+distance;
			InstantiateObjects();	
		}
	}

	void InstantiateObjects(){
		deadline = DoodlePlayer.player.position.y - 36.0f;

		counter +=1;
		if (counter%3 == 0){
			minY+=2f;
			maxY+=2f;
		}

		Vector3 spawnPosition = new Vector3();
		spawnPosition.y = currentHeight;
		for(int i = 0; i<numPlatforms; i++){
			spawnPosition.y += Random.Range(minY, maxY);
			spawnPosition.x = Random.Range(-levelWidth,levelWidth);
			Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
		}
		currentHeight = spawnPosition.y;
	}
}
