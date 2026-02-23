using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float deathTime = 2f;
    private float deathTimer = 0f;
    public float bulletSpeed = 5f;
    private Vector3 bulletDirection;
    private void OnEnable()
    {
        deathTimer = 0f;
        float x = 5;
        bulletDirection = new Vector3(x * bulletSpeed, 0, 0);
    }
    private void Update()
    {
        deathTimer += Time.deltaTime;
        if (deathTimer > deathTime)
        {
            if (BulletPool.Instance != null)
            {
                BulletPool.Instance.ReturnToPool(gameObject);
            }
        }

    }

}
