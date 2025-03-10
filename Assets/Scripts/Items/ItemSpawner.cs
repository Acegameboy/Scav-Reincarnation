using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _collectablePrefabs;

    public void SpawnCollectable(Vector2 position)
    {
        if (_collectablePrefabs.Count == 0)
        {
            Debug.LogError("No collectable prefabs assigned in ItemSpawner!");
            return;
        }

        int index = Random.Range(0, _collectablePrefabs.Count);
        var selectedCollectable = _collectablePrefabs[index];

        Debug.Log($"Spawning collectable: {selectedCollectable.name} at {position}");
        Instantiate(selectedCollectable, position, Quaternion.identity);
    }
}
