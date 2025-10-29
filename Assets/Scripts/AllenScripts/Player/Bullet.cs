using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header ("Bullet settings")]
    [SerializeField] private float lifetime = 1.0f;
    [SerializeField] private bool destroyOnHit = true;
    [SerializeField] int damage = 1;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) return;

        EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
        if (enemy != null) enemy.TakeDamage(damage);

        if (destroyOnHit)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
            return;
    }
}
