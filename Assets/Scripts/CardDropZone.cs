using UnityEngine;
using UnityEngine.EventSystems; // UI etkileþimleri için gerekli

// Bu objenin bir býrakma alaný (Drop Zone) olduðunu belirten arayüzü (Interface) ekliyoruz
public class CardDropZone : MonoBehaviour, IDropHandler
{
    // Üzerine bir UI objesi býrakýldýðýnda otomatik çalýþýr
    public void OnDrop(PointerEventData eventData)
    {
        // Eðer býrakýlan obje boþ deðilse
        if (eventData.pointerDrag != null)
        {
            // Býrakýlan objenin içindeki CardDrag scriptini bul
            CardDrag draggableCard = eventData.pointerDrag.GetComponent<CardDrag>();

            // Eðer sürüklenen þey gerçekten bir kartsa
            if (draggableCard != null)
            {
                // Kartýn geri döneceði "orijinal yuvasýný" bu masa olarak deðiþtir!
                draggableCard.originalParent = this.transform;
            }
        }
    }
}