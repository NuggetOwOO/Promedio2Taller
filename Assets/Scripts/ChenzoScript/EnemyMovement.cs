using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Enemy Movement Settings")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform target;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (target == null) return;

        Vector2 direction = (target.position - transform.position).normalized;

        rb.linearVelocity = direction * speed;
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}