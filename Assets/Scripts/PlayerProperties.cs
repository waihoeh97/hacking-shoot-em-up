using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerProperties : MonoBehaviour {

	public int startHealth = 5;
	public int curHealth;

	public float speed;
	public float shootDelay;

	private float lastShoot;

	public GameObject bullet;
	[HideInInspector]
	public GameObject InstantiatedObj;

	// Use this for initialization
	void Start () 
	{
		curHealth = startHealth;
	}

	void Movement ()
	{
		if (Input.GetKey(KeyCode.A)) 
		{
			transform.Translate (Vector3.left * Time.deltaTime * speed);
		}
		if (Input.GetKey(KeyCode.D)) 
		{
			transform.Translate (Vector3.right * Time.deltaTime * speed);
		}
		if (Input.GetKey(KeyCode.W)) 
		{
			transform.Translate (Vector3.up * Time.deltaTime * speed);
		}
		if (Input.GetKey(KeyCode.S)) 
		{
			transform.Translate (Vector3.down * Time.deltaTime * speed);
		}
	}

	void MouseFollow ()
	{
		Vector3 mousePos = (Camera.main.ScreenToWorldPoint (Input.mousePosition));
		mousePos.z = 0f;
		Vector3 direction = mousePos - transform.position;
		direction.Normalize();
		float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (0f, 0f, angle-90f), Time.deltaTime * 30f);
	}

	void Shooting ()
	{
		if (Input.GetKey(KeyCode.Mouse0))
		{
			if (Time.time > shootDelay + lastShoot)
			{
				SoundManagerScript.Instance.PlaySFX(SoundManagerScript.AudioClipID.SFX_SHOOT);
				InstantiatedObj = (GameObject)Instantiate(bullet, this.transform.position, this.transform.rotation);
				lastShoot = Time.time;
			}
		}
	}

	void Death ()
	{
		if (curHealth <= 0)
		{
			SceneManager.LoadScene(2);
		}
	}

	// Update is called once per frame
	void Update () {
		Movement();
		MouseFollow();
		Shooting();
		Death();
	}

	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.gameObject.tag == "EnemyBullet")
		{
			curHealth -= 1;
		}
	}
}
