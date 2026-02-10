using UnityEngine;


public class Bullet : MonoBehaviour
{
    public Vector3 direction = new Vector3(1, 0, 0);
    public float speed = 0.1f;
    Rigidbody2D rb;

    private void Update()
    {
        transform.position += direction * speed;
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherGameObject = collision.gameObject;
        if (otherGameObject.CompareTag("Enemy"))
        {
            Enemy health = otherGameObject.GetComponent<Enemy>();
            health.TakeDamage();
            Destroy(gameObject);
        }
    }
}