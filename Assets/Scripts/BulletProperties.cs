using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProperties : MonoBehaviour {

	private float speed;

	// Use this for initialization
	void Start () 
	{
		speed = 10;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.up * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.gameObject.tag == "Border")
		{
			Destroy(gameObject);
		}
	}
}
