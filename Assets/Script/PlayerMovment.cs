using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SimplePlayer : MonoBehaviour
{
    public float speed = 7f;
    public float jumpForce = 11f;
    public float slideAccel = 12f;
    public string nextSceneName = "StoryScene";

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        float x = 0f;
        if (kb.aKey.isPressed || kb.leftArrowKey.isPressed) x -= 1f;
        if (kb.dKey.isPressed || kb.rightArrowKey.isPressed) x += 1f;

        if (x != 0f)
        {
            float targetVx = x * speed;
            float newVx = Mathf.MoveTowards(rb.linearVelocity.x, targetVx, slideAccel * Time.deltaTime);
            rb.linearVelocity = new Vector2(newVx, rb.linearVelocity.y);
        }

        if (kb.spaceKey.wasPressedThisFrame)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        if (kb.mKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}