using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02Behaviour : MonoBehaviour 
{

	[HideInInspector]
	public int startingHealth = 20;
	public int curHealth;
	public int num;

	public float shootDelay;
	private float lastShoot;
	private float rotationsPerMinute = 10.0f;

	public GameObject bullet;
	public GameObject InstantiatedObj;
	public GameObject barrier;

	// Use this for initialization
	void Start () 
	{
		curHealth = startingHealth;
	}

	void Movement ()
	{
		if (num == 0)
		{
			transform.Rotate(0.0f , 0.0f , 10.0f * rotationsPerMinute * Time.deltaTime);	
		}
		else if (num == 1)
		{
			transform.Rotate(0.0f , 0.0f , -10.0f * rotationsPerMinute * Time.deltaTime);
		}
	}

	void Shoot ()
	{
		if (Time.time > shootDelay + lastShoot)
		{
			InstantiatedObj = (GameObject)Instantiate(bullet, this.transform.position, this.transform.rotation);
			lastShoot = Time.time;
		}
	}

	void Kill ()
	{
		if (curHealth <= 0)
		{
			SoundManagerScript.Instance.PlaySFX(SoundManagerScript.AudioClipID.SFX_DEATH);
			Destroy(gameObject);
		}
	}

	// Update is called once per frame
	void Update () 
	{
		Movement();
		if (EnemySpawnManager.counter >= 20)
		{
			Destroy(barrier.gameObject);
			Shoot();
			Kill();
		}
	}

	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.gameObject.tag == "Bullet")
		{
			curHealth--;
		}
	}
}
