using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    public int currentHealth;
    public float moveSpeed = 2f;
    private Rigidbody2D rb;
    private bool isFacingRight;
    public int attackDamage = 1;
    public int maxHealth = 5;
    
    public ParticleSystem blood;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            if (target.position.x < transform.position.x && !isFacingRight)
            {
                Flip();
            }
            else if (target.position.x > transform.position.x && isFacingRight)
            {
                Flip();
            }
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.01f);
        }
    }

    void Flip()
    {
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
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddKill();
        }
        ParticleSystem bloodEffect = Instantiate(blood, transform.position, Quaternion.identity);
        bloodEffect.Play();
        Destroy(bloodEffect.gameObject, bloodEffect.main.duration);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherGameObject = collision.gameObject;
        if (otherGameObject.CompareTag("Player"))
        {
            PlayerScript health = otherGameObject.GetComponent<PlayerScript>();
            health.TakeDamage();

        }
    }
}
