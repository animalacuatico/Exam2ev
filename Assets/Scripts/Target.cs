using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int targetHealth = 2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Bullet>())
        {
            targetHealth -= 1;
            Debug.Log("Daño a objetivo");
        }
        if (targetHealth == 0)
        {
            Debug.Log("Eliminado un objetivo");
            Destroy(gameObject);
        }
    }
}
