﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float padding = 1f;
	public GameObject projectile;
	public float projectileSpeed = 1.0f;
	public float firingRate = 0.5f;

	float xmin;
	float xmax;


	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint( new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint( new Vector3(1,0,distance));
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate ()
	{
		Vector2 move = new Vector2 (0.0f, 0.0f);
		if (Input.GetKey (KeyCode.LeftArrow))
			move.x--;
		if (Input.GetKey (KeyCode.RightArrow))
			move.x++;

		GetComponent<Rigidbody2D> ().velocity = move * speed;

		/*Clamp distance player can move*/
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		transform.position = new Vector2 (newX, transform.position.y);

		if (Input.GetKeyDown(KeyCode.Space)) {
			InvokeRepeating("Fire",0.0001f, firingRate);
		}

		if (Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke();
		}


	}

	//shooting laser
	void Fire(){
		GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = Vector2.up * projectileSpeed;
		
	}
}
