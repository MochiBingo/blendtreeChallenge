using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class LevelManager : MonoBehaviour
{
    public GameManager gameManager;
    public string spawnPoint;
    public GameObject player;
    public GameObject spawner;
    public void Start()
    {
        SceneManager.sceneLoaded += onSceneLoaded;
    }
    public void LoadLevel(string sceneName, string SpawnPoint)
    {
        SceneManager.LoadScene(sceneName);
        spawnPoint = SpawnPoint;
    }
    public void onSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        spawner = GameObject.Find(spawnPoint);
        player.transform.position = spawner.transform.position;
    }
}
