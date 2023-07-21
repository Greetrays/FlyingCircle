using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pool : MonoBehaviour
{
    [SerializeField] private int _capacity;
    [SerializeField] private Transform _container;

    private List<SpawnObject> _pool = new List<SpawnObject>();

    protected void Init(SpawnObject template, PlayerCoin target)
    {
        for (int i = 0; i < _capacity; i++)
        {
            SpawnObject newSpawnObject = Instantiate(template, _container);
            newSpawnObject.SetTarget(target);
            newSpawnObject.gameObject.SetActive(false);
            _pool.Add(newSpawnObject);
        }
    }

    protected bool TryGetObject(out SpawnObject disableObject)
    {
        disableObject = _pool.FirstOrDefault(spawnObject => spawnObject.gameObject.activeSelf == false);
        return disableObject != null;
    }
}
