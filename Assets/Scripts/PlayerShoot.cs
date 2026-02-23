using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public BulletPool pool;
    public Transform playerGafas;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SpawnBullet();
        }
    }
    void SpawnBullet()
    {
        Vector3 spawnPos = transform.position + new Vector3(3, 1.60f, 0);
        var p = pool != null ? pool : BulletPool.Instance;
        if (p != null)
        {
            p.GetFromPool(spawnPos, Quaternion.identity);
        }
    }
}
