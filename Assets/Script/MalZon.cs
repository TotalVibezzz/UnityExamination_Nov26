using UnityEngine;
using TMPro;

public class SimpleGoal : MonoBehaviour
{
    public static bool gameWon = false;

    public int requiredScore = 3;
    public TMP_Text winText;
    public string message = "Banan klar!";
    public Animator playerAnimator;
    public string winAnimationName = "Win";

    private bool goalUnlocked = false;

    void Start()
    {
        gameWon = false;

        if (winText != null)
        {
            winText.gameObject.SetActive(false);
        }

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
        if (!gameWon && goalUnlocked && other.CompareTag("Player"))
        {
            gameWon = true;

            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }

            if (playerAnimator == null)
            {
                playerAnimator = other.GetComponentInChildren<Animator>();
            }

            if (playerAnimator != null && !string.IsNullOrEmpty(winAnimationName))
            {
                playerAnimator.Play(winAnimationName);
            }

            if (winText != null)
            {
                winText.text = message;
                winText.gameObject.SetActive(true);
            }
        }
    }
}