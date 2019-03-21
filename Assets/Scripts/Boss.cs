using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour {

	public int startHealth = 50;
	public int curHealth;

	public float shootDelay;
	private float lastShoot;
	private float rotationsPerMinute = 10.0f;

	public float speed = 2;

	bool isShoot1 = true;

	public GameObject bulletType1;
	public GameObject bulletType2;
	public GameObject InstantiatedObj;

	public Transform target;

	// Use this for initialization
	void Start () 
	{
		gameObject.SetActive(false);
		curHealth = startHealth;
	}

	void Movement ()
	{
		transform.Rotate(0.0f , 0.0f , 10.0f * rotationsPerMinute * Time.deltaTime);
		transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
	}

	IEnumerator Shoot ()
	{
		while (true)
		{
			if (isShoot1)
			{
				if (Time.time > shootDelay + lastShoot)
				{
					InstantiatedObj = (GameObject)Instantiate(bulletType1, this.transform.position, this.transform.rotation);
					lastShoot = Time.time;
				}
				yield return new WaitForSeconds(1.0f);
				isShoot1 = false;
			}
			else if (!isShoot1)
			{
				if (Time.time > shootDelay + lastShoot)
				{
					InstantiatedObj = (GameObject)Instantiate(bulletType2, this.transform.position, this.transform.rotation);
					lastShoot = Time.time;
				}
				yield return new WaitForSeconds(1.0f);
				isShoot1 = true;
			}

			yield return null;
		}
	}

	void Kill ()
	{
		if (curHealth <= 0)
		{
			Destroy(gameObject);
			SceneManager.LoadScene(3);
		}
	}

	// Update is called once per frame
	void Update () 
	{
		Movement();
		StartCoroutine(Shoot());
		Kill();
	}

	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.gameObject.tag == "Bullet")
		{
			curHealth -= 1;
		}
	}
}
