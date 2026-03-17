using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timer = 3;
    public GameObject enemyPrefab;
    public Transform targetTransform;

    public float minX = -3f;
    public float maxX = 10f;
    public float maxY = -3.75f;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("F2");
        if (timer <= 0)
        {
            timer = 3;
            SpawnEnemy();
        }
        void SpawnEnemy()
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(minX, maxX), maxY, 0);
            GameObject newInstance = Instantiate(enemyPrefab, randomSpawnPosition, Quaternion.identity);

            Enemy enemyScript = newInstance.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.SetTarget(targetTransform);
            }
        }
    }
}
