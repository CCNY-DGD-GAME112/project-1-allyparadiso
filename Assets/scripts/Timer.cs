using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timer = 5;
    public GameObject Coin;
    public AudioSource audioSource;
    public AudioClip audioClip;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("F2");
        if (timer <= 0)
        {
            timer = 5;
            Vector3 spawnPoint = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0);
            Instantiate(Coin, spawnPoint, Quaternion.identity);

            audioSource.PlayOneShot(audioClip);
        }
    }
}
