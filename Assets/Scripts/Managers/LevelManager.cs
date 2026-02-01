using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;


public class LevelManager : MonoBehaviour
{
    public GameObject door; // GameObject türünde door adýnda bir deðiþken oluþturduk. GameObject sahnede yaþayan her þeydir.
    public GameObject collectablePrefab;
    public List<GameObject> collectables;

    public void RestartLevel()
    {
        DeactivateDoor();
        RandomizeDoorPosition();
        DeleteCollectables();
        GenerateCollectables();

    }

    private void DeleteCollectables()
    {
        foreach (GameObject c in collectables)
        {
            Destroy(c);
        }

        collectables.Clear();
    }

    private void GenerateCollectables()
    {
        var newCollectable = Instantiate(collectablePrefab);
        newCollectable.transform.position = new Vector3(UnityEngine.Random.Range(-2.1f, 2.1f), 0, 4.5f);
        collectables.Add(newCollectable);

    }

    private void RandomizeDoorPosition()
    {
        var pos = door.transform.position;
        pos.x = Random.Range(-2.2f, 2.2f);
        door.transform.position = pos;
    }

    private void DeactivateDoor()
    {
        door.SetActive(false);
    }

    public void AppleCollected()
    {
        door.SetActive(true);
    }
}
