using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            Instance = this;
        }
    }
}
public class Score : MonoBehaviour
{
    public TextMeshPro ScoreText;
    public int score = 0;
    public GameObject coin;
    public Rigidbody2D rb;
    GameObject player;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateScore();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (coin != null)
        {
            Destroy(coin);
            score++;
            UpdateScore();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(player);
        }
    }
    void UpdateScore()
    {
        ScoreText.text = "Score: " + score;
    }
   
}