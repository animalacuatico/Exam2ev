using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance { get; private set; }
    public GameObject poolPrefab;
    public int initialSize = 10;
    public bool expandIfEmpty = true;
    private readonly Queue<GameObject> pool = new Queue<GameObject>();
    private void Awake()
    {
        Instance = this;
        for (int i = 0; i < initialSize; i++)
        {
            CreateAndEnqueue();
        }
    }
    private GameObject CreateAndEnqueue()
    {
        GameObject obj = Instantiate(poolPrefab);
        obj.SetActive(false);
        pool.Enqueue(obj);
        return obj;
    }
    public GameObject GetFromPool(Vector3 position, Quaternion rotation)
    {
        GameObject obj = null; if (pool.Count > 0)
        {
            obj = pool.Dequeue();
        }
        else if (expandIfEmpty)
        {
            obj = Instantiate(poolPrefab);
        }
        if (obj == null)
        {
            return obj;
        }
    }
}
