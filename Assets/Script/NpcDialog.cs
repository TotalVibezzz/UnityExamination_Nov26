using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class SimpleTalk : MonoBehaviour
{
    public string npcName = "Kalle";
    public string line = "Hej! Tryck E igen för att stänga.";
    public TMP_Text dialogText;
    public GameObject dialogBox;

    private bool playerNear = false;
    private bool isOpen = false;

    void Start()
    {
        if (dialogBox != null) dialogBox.SetActive(false);
    }

    void Update()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        if (kb.eKey.wasPressedThisFrame)
        {
            Debug.Log("E tryckt. playerNear = " + playerNear);
            if (!playerNear) return;

            isOpen = !isOpen;
            if (dialogBox != null) dialogBox.SetActive(isOpen);
            if (dialogText != null && isOpen) dialogText.text = npcName + ": " + line;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) playerNear = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
            isOpen = false;
            if (dialogBox != null) dialogBox.SetActive(false);
        }
    }
}