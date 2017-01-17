using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		Vector2 move = new Vector2(0.0f, 0.0f);
		if(Input.GetKey(KeyCode.LeftArrow))
			move.x--;
		if(Input.GetKey(KeyCode.RightArrow))
			move.x++;

		GetComponent<Rigidbody2D>().velocity = move * speed;
	}
}
