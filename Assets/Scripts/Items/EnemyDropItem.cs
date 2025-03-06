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

        if (_chanceOfCollectableDrop >= random)
        {
            _collectableSpawner.SpawnCollectable(transform.position);
        }
    }
}
