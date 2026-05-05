using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    [Header("Kart Verisi")]
    public CardData card;

    [Header("Arayüz (UI) Referanslarý")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI healthText;
    public Image artworkImage;

    // SAVAÞ ÝÇÝN YENÝ EKLENEN DEÐÝÞKENLER
    [HideInInspector] public int currentAttack;
    [HideInInspector] public int currentHealth;

    void Start()
    {
        if (card != null)
        {
            // Kart masaya indiðinde, þablondaki verileri kendi geçici hafýzasýna alýr
            currentAttack = card.attack;
            currentHealth = card.health;

            UpdateCardDisplay();
        }
    }

    public void UpdateCardDisplay()
    {
        nameText.text = card.cardName;
        attackText.text = currentAttack.ToString(); // Artýk mevcut gücü yazdýrýyoruz
        healthText.text = currentHealth.ToString(); // Artýk mevcut caný yazdýrýyoruz

        if (card.artwork != null)
        {
            artworkImage.sprite = card.artwork;
        }
    }

    // HASAR ALMA FONKSÝYONU
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Caný hasar kadar düþür

        // Eðer can 0 veya altýna indiyse kartý yok et
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            // Caný 0'dan büyükse, ekrandaki yazýyý güncelle (Örn: 5'ten 2'ye düþtüðünü göster)
            UpdateCardDisplay();
        }
    }

    // KARTIN ÖLÜM FONKSÝYONU
    void Die()
    {
        Debug.Log(card.cardName + " yok edildi!");
        Destroy(gameObject); // Kart objesini sahneden sil
    }
}