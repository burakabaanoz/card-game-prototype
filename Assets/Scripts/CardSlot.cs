using UnityEngine;
using UnityEngine.EventSystems;

public class CardSlot : MonoBehaviour, IDropHandler
{
    [Header("Yuva Bilgileri")]
    public CardDisplay currentCard; // Bu yuvanýn içindeki kart
    public CardSlot opposingSlot;   // Tam karþýsýndaki düþman yuvasý

    // KART YUVAYA BIRAKILDIÐINDA ÇALIÞIR
    public void OnDrop(PointerEventData eventData)
    {
        // Eðer bu yuvada zaten bir kart yoksa
        if (currentCard == null && eventData.pointerDrag != null)
        {
            CardDrag draggableCard = eventData.pointerDrag.GetComponent<CardDrag>();
            if (draggableCard != null)
            {
                // Kartý bu yuvaya kilitle
                draggableCard.originalParent = this.transform;

                // Yuvanýn içine bu kartý kaydet (Artýk yuva dolu)
                currentCard = eventData.pointerDrag.GetComponent<CardDisplay>();

                // Kartýn pozisyonunu yuvanýn tam ortasýna oturt
                draggableCard.transform.position = transform.position;
            }
        }
    }

    // INSCRYPTION TARZI SALDIRI FONKSÝYONU
    public void AttackOpponent()
    {
        // Eðer bu yuvada bir kart varsa ve karþýsýndaki yuvada da bir düþman kartý varsa
        if (currentCard != null && opposingSlot.currentCard != null)
        {
            Debug.Log(currentCard.card.cardName + " saldýrýyor!");

            // Karþýdaki kartýn TakeDamage fonksiyonunu çalýþtýr ve kendi hasarýmýzý gönder
            opposingSlot.currentCard.TakeDamage(currentCard.currentAttack);

            // Karþýdaki kart öldüyse, karþýnýn yuvasýný "boþ" olarak güncelle
            if (opposingSlot.currentCard.currentHealth <= 0)
            {
                opposingSlot.currentCard = null;
            }
        }
        else if (currentCard != null && opposingSlot.currentCard == null)
        {
            // Eðer karþýsý boþsa, Inscryption'daki gibi doðrudan oyuncuya hasar vurma kodu buraya gelecek
            Debug.Log("Karþýsý boþ, doðrudan oyuncuya vuruldu!");
        }
    }
}