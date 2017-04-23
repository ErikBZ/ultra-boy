using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameOverUI : MonoBehaviour {

    public Transform defTransform;
    public Vector2 Checkpoint;
    public HealthController Player;

	// Use this for initialization
	void Start()
	{
        this.gameObject.SetActive(false);
        if(defTransform != null)
        {
            Checkpoint = defTransform.position;
        }
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
        //		SceneManager.LoadScene ( SceneManager.GetActiveScene().buildIndex );

        Player.GoToCheckpoint(Checkpoint);
        this.gameObject.SetActive(false);
	}
}
