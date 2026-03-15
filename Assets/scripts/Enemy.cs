using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public int currentHealth;
    public float moveSpeed = 2f;
    private Rigidbody2D rb;
    private bool isFacingRight = true;
    public int direction = 1;
    public int attackDamage = 1;
    public int maxHealth = 5;
    

    public ParticleSystem blood;
    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.01f);  
    }

    void Flip()
    {
        direction *= -1;
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    public void TakeDamage()
    {
        currentHealth -= 1;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        ParticleSystem bloodEffect = Instantiate(blood, transform.position, Quaternion.identity);
        bloodEffect.Play();
        Destroy(bloodEffect.gameObject, bloodEffect.main.duration);
        Destroy(gameObject);
    }
}
