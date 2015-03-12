using UnityEngine;
using System.Collections;

public class PlayerSpawnManager : MonoBehaviour {

	public GameObject playerPrefab;
	GameObject playerInstance;

	float respawnTimer = 1;

	private int numLives = 4;

	// Use this for initialization
	void Start ()
	{
		SpawnPlayer ();
	}

	void SpawnPlayer()
	{
		playerInstance = (GameObject)Instantiate (playerPrefab, transform.position, Quaternion.identity);
		playerInstance.name = "PlayerShip";
		numLives--;
		respawnTimer = 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (playerInstance == null)
		{
			if(numLives > 0)
			{
				respawnTimer -= Time.deltaTime;
				if(respawnTimer <= 0)
				{
					SpawnPlayer ();
				}
			}
			else
			{
				WaveMarker.text.text = "GAME OVER";
				StartCoroutine("GameOverCo");
			}
		}
		LivesMarker.numLives = numLives;
	}

	IEnumerator GameOverCo()
	{
		yield return new WaitForSeconds(3);
		Application.LoadLevel (0);
	}
}
