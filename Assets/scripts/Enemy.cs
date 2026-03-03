using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int currentHealth;
    public float moveSpeed = 2f;
    private Rigidbody2D rb;
    private bool isFacingRight = true;
    public int direction = 1;
    public int attackDamage = 1;
    public int maxHealth = 5;

    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;

    public ParticleSystem blood;
    private void Start()
    {
        
        currentHealth = maxHealth;
    }
    //private void Update()
    //{
        //rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
    //}
    private void FixedUpdate()
    {

        Vector2 clampedPosition = transform.position;

        clampedPosition.x = Mathf.Clamp(transform.position.x, minX, maxX);
        clampedPosition.y = Mathf.Clamp(transform.position.y, minY, maxY);

        transform.position = clampedPosition;
    }

    


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            Flip();
        }
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
