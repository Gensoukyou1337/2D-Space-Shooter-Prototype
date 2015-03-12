using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	float enemyRate = 5;
	float nextEnemy = 1;
	float spawnDistance = 20f;
	public GameObject enemyPrefab;
	GameObject enemyInstance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		nextEnemy -= Time.deltaTime;
		if (nextEnemy < 0)
		{
			nextEnemy = enemyRate;
			if(enemyRate > 2.5f)
			{enemyRate -= 0.1f;}
			else{return;}

			Vector3 offset = Random.onUnitSphere;
			offset.z = 0;
			offset = offset.normalized * spawnDistance;

			enemyInstance = (GameObject)Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);
			enemyInstance.name = "EnemyShip";
		}
	}
}
