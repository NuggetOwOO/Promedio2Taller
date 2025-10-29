using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Shoot")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firepoint;
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private float fireRate = 0.025f;

    private PlayerMovement movement;
    private float nextFireTime;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        HandleShooting();
    }

    private void HandleShooting()
    {
        if(Input.GetMouseButtonDown(0) && Time.time  >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Shoot()
    {
        if (bulletPrefab == null || firepoint == null) return;

        Vector2 dir = movement.LastMoveDirection;
        if (dir == Vector2.zero) dir = Vector2.right;

        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, Quaternion.identity);

        float angle = Mathf.Atan2 (dir.x, dir.y) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = dir.normalized * bulletSpeed;
        }
    }
}
