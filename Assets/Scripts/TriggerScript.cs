using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public string sceneName;
    public string spawnPoint;

    public void OnTriggerEnter2D(Collider2D other)
    {
        gameManager.levelManager.LoadLevel(sceneName, spawnPoint);
    }
}
