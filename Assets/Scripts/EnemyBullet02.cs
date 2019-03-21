using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet02 : MonoBehaviour {

	private float speed;

	// Use this for initialization
	void Start () {
		speed = 5;
	}

	void Update () {
		transform.Translate(Vector3.down * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.gameObject.tag == "Border")
		{
			Destroy(gameObject);
		}
		if (target.gameObject.tag == "Bullet")
		{
			SoundManagerScript.Instance.PlaySFX(SoundManagerScript.AudioClipID.SFX_DEATH);
		}
		if (target.gameObject.tag == "NonBreakableObject")
		{
			Destroy(gameObject);
		}
	}
}
