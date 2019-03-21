using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour {

	public GameObject enemy;
	public GameObject parent;
	public GameObject bossChild;

	float randY;
	float randX;

	public float spawnRate = 3f;
	float nextSpawn = 0.0f;

	public static int counter;
	public static int killed = 0;

	Vector3 spawnArea;

	// Use this for initialization
	void Start ()
	{
		bossChild.transform.parent = parent.transform;
		counter = 0;
	}

	void SpawnType01 ()
	{
		if (Time.time > nextSpawn)
		{
			nextSpawn = Time.time + spawnRate;
			randX = Random.Range(-4.0f, 4.0f);
			randY = Random.Range(10.0f, 14.0f);
			spawnArea = new Vector3 (randX, randY);
			Instantiate (enemy, spawnArea, Quaternion.identity);
			counter++;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		SpawnType01();
		foreach (Transform child in this.transform)
		{
			if (GameObject.FindGameObjectWithTag("Enemy2") == null)
			{
				child.gameObject.SetActive(true);
				SoundManagerScript.Instance.PlayBGM(SoundManagerScript.AudioClipID.BGM_BOSS);
			}
		}
	}
}
