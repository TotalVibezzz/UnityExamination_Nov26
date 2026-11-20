using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class SimpleAction : MonoBehaviour
{
    public TMP_Text statusText;
    public string message = "Aktiverat!";
    private bool canUse = false;

    void Update()
    {
        if (!canUse) return;
        var kb = Keyboard.current;
        if (kb != null && kb.fKey.wasPressedThisFrame)
        {
            if (statusText != null) statusText.text = message;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) canUse = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) canUse = false;
    }
}