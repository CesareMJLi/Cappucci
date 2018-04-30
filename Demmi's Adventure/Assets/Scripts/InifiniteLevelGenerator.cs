using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InifiniteLevelGenerator : MonoBehaviour {

	public GameObject platformPrefab;
	
	public GameObject Player;

	public int numPlatforms = 10;
	public float distance = 40.0f;
	public float levelWidth =10f;
	public float minY = 3f;
	public float maxY = 6f;

	private float currentHeight;

	private float nextTimePlayerHeight;
	
	// Use this for initialization
	void Start () {
		nextTimePlayerHeight = Player.transform.position.y+distance;
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
