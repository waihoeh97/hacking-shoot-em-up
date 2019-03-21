using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraProperties : MonoBehaviour {

	GameObject player;

	private Vector3 offset;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		player.GetComponent<Transform>();
	}

	// Use this for initialization
	void Start () 
	{
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	// Update is called after Update each frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
