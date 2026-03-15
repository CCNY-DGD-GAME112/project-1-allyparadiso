using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float speed = 1f;
    public Vector3 direction = new Vector3(1, 0, 0);
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
