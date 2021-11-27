using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] public GameObject enemyPrefab;
    [SerializeField] public float cooldown = 3;

    private bool canShoot = true;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && canShoot)
        {
            canShoot = false;
            Invoke(nameof(ResetCooldown), cooldown);
            GameObject enemyprojectile = Instantiate(enemyPrefab,transform.position + transform.forward, Quaternion.identity);
            enemyprojectile.GetComponent<Enemy>().SetAsProjectile();
            enemyprojectile.GetComponent<Rigidbody>().AddForce((transform.forward+transform.up)*5, ForceMode.Impulse);
            enemyprojectile.GetComponent<EnemyFollowing>().player = transform;
        }
    }

    void ResetCooldown() => canShoot = true;
}
