using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyShooterOrb : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    void Start()
    {
        transform.DOMoveY(transform.position.y + 1, 2).SetLoops(-1, LoopType.Yoyo);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnemyShooter tmp = other.gameObject.AddComponent<EnemyShooter>();
            tmp.enemyPrefab = enemyPrefab;
            Destroy(gameObject);
        }
    }
}
