using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemies;
    public Enemy enemyPrefab;
    public Player player;

    public Vector2 enemyCount;

    public void RestartEnemyManager()
    {
        DeleteEnemies();
        GenerateEnemies();
    }

    private void GenerateEnemies()
    {
        var randomEnemyCount = UnityEngine.Random.Range(enemyCount.x, enemyCount.y);
        for(int i = 0; i < randomEnemyCount; i++)
        {
            var enemyXpos = UnityEngine.Random.Range(-2.3f, 2.3f);
            var newEnemy = Instantiate(enemyPrefab);
            newEnemy.transform.position = new Vector3(enemyXpos, 0, 3 + i * 1.5f);
            enemies.Add(newEnemy);
            newEnemy.StartEnemy(player);
        }
      
    }

    private void DeleteEnemies()
    {
        foreach (var e in enemies)
        {
            Destroy(e.gameObject);
        }

        enemies.Clear();
    }

    public void StopEnemies()
    {
        foreach (var e in enemies)
        {
            e.Stop();
        }
    }
}
