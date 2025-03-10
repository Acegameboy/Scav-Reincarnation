using UnityEngine;

public class EnemyDropItem : MonoBehaviour
{
    [SerializeField]
    private float _chanceOfCollectableDrop;

    private ItemSpawner _collectableSpawner;

    private void Awake()
    {
        _collectableSpawner = FindObjectOfType<ItemSpawner>();
    }

    public void RandomlyDropCollectable()
    {
        float random = Random.Range(0f, 1f);
        Debug.Log($"Random drop chance: {random} vs Drop Threshold: {_chanceOfCollectableDrop}");

        if (_chanceOfCollectableDrop >= random)
        {
            Debug.Log("Item should drop!");
            _collectableSpawner.SpawnCollectable(transform.position);
        }
    }
}
