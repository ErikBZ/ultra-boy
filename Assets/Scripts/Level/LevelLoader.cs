using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    // Use this for initialization

    public int nextLevel;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    // 0 is level 1
    // 1 is level 2
    // 2 is main menu
    public void LoadLevel(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void GameExit()
    {
        Application.Quit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LoadLevel(nextLevel);
    }
        
}
