using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameOverUI : MonoBehaviour {
	
	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
	}


	public void Quit()
	{
		SceneManager.LoadScene ("Main Menu");

	}

	public void Retry()
	{
		Debug.Log ("Restart from checkpoint");

		// Loads screen based on checkpoint

		//ScreenManger.LoadScreen ();
	}
}
