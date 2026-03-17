using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI killCountText;
    public int kills = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        UpdateKillCount();
    }
    public void AddKill()
    {
        kills++;
        UpdateKillCount();
    }

    void UpdateKillCount()
    {
        killCountText.text = "Kills: " + kills.ToString();
    }
}