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
