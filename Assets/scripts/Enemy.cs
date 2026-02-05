using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int currentHealth = 10;

    public void TakeDamage()
    {
        currentHealth -= 1;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
