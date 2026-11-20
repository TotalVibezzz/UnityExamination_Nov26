using UnityEngine;
using TMPro;

public class SimpleGoal : MonoBehaviour
{
    public int requiredScore = 3;
    public TMP_Text winText;
    public string message = "Banan klar!";

    private bool goalUnlocked = false;
    private bool won = false;

    void Start()
    {
        if (winText != null) winText.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (!goalUnlocked && SimplePickup.score >= requiredScore)
        {
            goalUnlocked = true;
            gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!won && goalUnlocked && other.CompareTag("Player"))
        {
            won = true;
            if (winText != null)
            {
                winText.text = message;
                winText.gameObject.SetActive(true);
            }
        }
    }
}