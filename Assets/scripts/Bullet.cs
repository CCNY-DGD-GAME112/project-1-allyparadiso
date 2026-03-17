using UnityEngine;


public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherGameObject = collision.gameObject;
        if (otherGameObject.CompareTag("Enemy"))
        {
            Enemy health = otherGameObject.GetComponent<Enemy>();
            health.TakeDamage();
            
        }
        Destroy(gameObject);
    }
}