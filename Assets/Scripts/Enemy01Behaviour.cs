using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01Behaviour : MonoBehaviour {

	[HideInInspector]
	public int startingHealth = 5;
	public int curHealth;
	public int speed;

	public float shootDelay;
	private float lastShoot;
	
	public GameObject bullet;
	public GameObject InstantiatedObj;

	// Use this for initialization
	void Start () 
	{
		speed = 2;
		curHealth = startingHealth;
	}

	void Chase ()
	{
		transform.Translate(Vector3.down * Time.deltaTime * speed); 
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
		Chase();
		Shoot();
		Kill();
	}

	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.gameObject.tag == "Bullet")
		{
			curHealth--;
		}
		if (target.gameObject.tag == "Border")
		{
			Destroy(gameObject);
		}
	}
}
