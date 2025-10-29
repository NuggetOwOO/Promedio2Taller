using System.Collections;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private float attackInterval = 2f; 
    [SerializeField] private float attackDuration = 0.5f; 

    [Header("Attack Areas")]
    [SerializeField] private GameObject attackUp;
    [SerializeField] private GameObject attackDown;
    [SerializeField] private GameObject attackLeft;
    [SerializeField] private GameObject attackRight;

    private Transform player;
    private bool isAttacking = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        StartCoroutine(AttackLoop());
    }

    private IEnumerator AttackLoop()
    {
        while (true)
        {
            if (!isAttacking && player != null)
            {
                yield return new WaitForSeconds(attackInterval);
                Attack();
            }
            yield return null;
        }
    }

    private void Attack()
    {
        isAttacking = true;

        attackUp.SetActive(false);
        attackDown.SetActive(false);
        attackLeft.SetActive(false);
        attackRight.SetActive(false);

        Vector2 direction = player.position - transform.position;
        float absX = Mathf.Abs(direction.x);
        float absY = Mathf.Abs(direction.y);

        if (absX > absY)
        {
            if (direction.x > 0)
                StartCoroutine(ActivateAttack(attackRight));
            else
                StartCoroutine(ActivateAttack(attackLeft));
        }
        else
        {
            if (direction.y > 0)
                StartCoroutine(ActivateAttack(attackUp));
            else
                StartCoroutine(ActivateAttack(attackDown));
        }
    }

    private IEnumerator ActivateAttack(GameObject attackObject)
    {
        attackObject.SetActive(true);
        yield return new WaitForSeconds(attackDuration);
        attackObject.SetActive(false);
        isAttacking = false;
    }
}
