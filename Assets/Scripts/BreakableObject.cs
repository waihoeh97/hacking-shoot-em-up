using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour {

	[HideInInspector]
	public int health;

	// Use this for initialization
	void Start () {
		health = 10;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.gameObject.tag == "Bullet")
		{
			health--;
		}
	}
}
