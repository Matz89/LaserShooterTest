using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	private Text txtRef;
	static public int score;

	// Use this for initialization
	void Start () {
		txtRef = GetComponent<Text>();
		Reset();
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	public void Reset(){
		score = 0;
		setText();
	}

	//add mah score
	public void addScore (int i)
	{
		score += i;
		setText();
	}

	void setText(){
		txtRef.text = score.ToString();
	}
}
