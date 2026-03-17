using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float speed = 2f;
    public Transform firePoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, 0));
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.right * speed, ForceMode2D.Impulse);
        }
        
    }
}
