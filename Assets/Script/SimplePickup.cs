using UnityEngine;
using TMPro;

public class SimplePickup : MonoBehaviour
{
    public static int score = 0;
    private static TMP_Text sharedScoreText;

    public TMP_Text scoreText;
    public GameObject goalToUnlock;
    public int coinsNeededForGoal = 3;

    void Awake()
    {
        score = 0;
        if (scoreText != null)
        {
            sharedScoreText = scoreText;
        }
    }

    void Start()
    {
        if (goalToUnlock != null)
        {
            goalToUnlock.SetActive(false);
        }
        UpdateScore();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            score += 1;
            UpdateScore();

            if (goalToUnlock != null && score >= coinsNeededForGoal)
            {
                goalToUnlock.SetActive(true);
            }

            gameObject.SetActive(false);
        }
    }

    void UpdateScore()
    {
        if (sharedScoreText != null)
        {
            sharedScoreText.text = "Poäng: " + score;
        }
    }
}