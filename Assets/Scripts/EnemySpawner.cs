using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public bool goRight = true;
	public float speed = 0.05f;

	private float xmin;
	private float xmax;
	private float padding;


	// Use this for initialization
	void Start ()
	{
		

		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint( new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint( new Vector3(1,0,distance));
		padding = 0f;
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
		

		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}

	public void OnDrawGizmos ()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}
	
	// Update is called once per frame
	void Update () {
		if (goRight) {
			//move
			transform.position += Vector3.right * speed * Time.deltaTime;

			//switch direction
			if((transform.position.x + padding) >= xmax)
				goRight = false;
		} else {
			//move
			transform.position -= Vector3.right * speed * Time.deltaTime;

			//switch direction
			if((transform.position.x - padding) <= xmin)
				goRight = true;
		}
	}

	void FixedUpdate ()
	{
		

	}
}
