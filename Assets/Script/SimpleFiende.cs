using UnityEngine;
using TMPro;

public class SimpleEnemy : MonoBehaviour
{
    public int hp = 3;
    public TMP_Text hpText;

    void Start()
    {
        UpdateText();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hp -= 1;
            if (hp <= 0)
            {
                hp = 0;
                UpdateText();
                if (hpText != null) hpText.gameObject.SetActive(false);
                gameObject.SetActive(false);
                return;
            }
            UpdateText();
        }
    }

    void UpdateText()
    {
        if (hpText != null) hpText.text = "HP: " + hp;
    }
}