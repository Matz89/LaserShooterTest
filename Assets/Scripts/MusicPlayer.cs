using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;

	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip endClip;

	private AudioSource music;

	// Use this for initialization
	void Start ()
	{
		

		if (instance != null && instance != this) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing.");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
			music = GetComponent<AudioSource>();
			music.clip = startClip;
			music.loop = false;
			music.Play();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable ()
	{
		SceneManager.sceneLoaded += changeMusicOnLevelLoad;
	}
	void OnDisable ()
	{
		SceneManager.sceneLoaded -= changeMusicOnLevelLoad;
	}

	void changeMusicOnLevelLoad( Scene scene, LoadSceneMode mode)
	{
		Debug.Log ("Music Player Loaded, " + scene);
		Debug.Log ("Music Player Loaded Mode, " + mode);
		music.Stop();

		switch (scene.buildIndex) {
			case 0:
				music.clip = startClip;
				music.loop = false;
				break;
			case 1:
				music.clip = gameClip;
				music.loop = true;
				break;
			case 2:
				music.clip = endClip;
				music.loop = false;
				break;
		}


		music.Play();
	}
}
