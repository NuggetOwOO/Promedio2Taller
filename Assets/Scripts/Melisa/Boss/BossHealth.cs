using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;
    private int currentHealth;
    [SerializeField] private ChangeSceneButton sceneChanger;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Boss defeated");
        sceneChanger.ChangeScene(); 
    }
}
