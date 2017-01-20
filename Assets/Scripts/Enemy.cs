using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float hp = 1;
	public GameObject projectile;


	public float shotsPerSecond = 0.5f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (checkFire())
			fireWeapon();

	}

	bool checkFire(){
		float probability = Time.deltaTime * shotsPerSecond;

		return Random.value < probability;
	}

	void fireWeapon(){
		GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = Vector2.down * beam.GetComponent<Projectile>().projectileSpeed;
	}

	void OnTriggerEnter2D(Collider2D col){
		GameObject hitObj = col.gameObject;
		if(hitObj.GetComponent<Projectile>()){
			Hit(hitObj.GetComponent<Projectile>().GetDamage());
			//Debug.Log(string.Format("Ship is hit, HP @ {0}", hp));
			Destroy(hitObj);
		}
	}

	void Hit (float damage)
	{
		hp -= damage;

		//destroy is hp is below 0
		if (hp <= 0) {
			Destroy(gameObject);
		}

	}
}
