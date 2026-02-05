using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0) * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0) * speed;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0) * speed;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0) * speed;
        }
    }
}
public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 0));
        }
    }
}
public class Bullet : MonoBehaviour
{
    public Vector3 direction = new Vector3(1, 0, 0);
    public float speed = 0.1f;

    private void Update()
    {
        transform.position += direction * speed;
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