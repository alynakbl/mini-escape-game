using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public Player player;

    [Header("Managers")]
    public EnemyManager enemyManager;
    public LevelManager levelManager;

    private void Start()
    {
        RestartLevel();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        levelManager.RestartLevel();
        enemyManager.RestartEnemyManager();
        player.RestartPlayer();
    }

    public void LevelCompleted() // private olursa ya da public olmazsa dýþarýdan ulaþýlamaz
    {
        enemyManager.StopEnemies();
    }
    
}
