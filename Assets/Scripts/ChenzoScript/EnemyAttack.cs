using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Enemy Shooting Settings")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private float shootRate = 1.5f;
    [SerializeField] private float shootRange = 8f;
    [SerializeField] private Transform target;

    private float nextShootTime = 0f;

    void Update()
    {
        if (target == null) return;

        float distance = Vector2.Distance(transform.position, target.position);

        if (distance <= shootRange && Time.time >= nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + 1f / shootRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        Vector2 direction = (target.position - shootPoint.position).normalized;
        rb.linearVelocity = direction * bulletSpeed;

        Debug.Log("Enemy fired a projectile!");
    }
}
