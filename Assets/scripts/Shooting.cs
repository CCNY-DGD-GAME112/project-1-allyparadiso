using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float speed = 1f;
    public Vector3 direction = new Vector3(1, 0, 0);


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.right, Quaternion.Euler(0, 0, 0));
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * speed, ForceMode2D.Impulse); ;
            transform.position += transform.right * speed;
            

        }
    }
}
