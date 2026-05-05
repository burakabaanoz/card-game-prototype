using UnityEngine;
using UnityEngine.EventSystems;

public class CardDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Transform originalParent;
    private CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    // 1. KARTA TIKLANIP SÜRÜKLENMEYE BAÞLANDIÐI AN
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;

        // YENÝ EKLENEN KISIM: Eðer kart bir yuvadan (slot) çýkýyorsa, o yuvanýn hafýzasýný temizle
        CardSlot currentSlot = originalParent.GetComponent<CardSlot>();
        if (currentSlot != null)
        {
            currentSlot.currentCard = null; // Yuva artýk boþ
        }

        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        canvasGroup.blocksRaycasts = false;
    }

    // 2. KART SÜRÜKLENÝRKEN
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    // 3. FARENÝN TUÞU BIRAKILDIÐINDA
    public void OnEndDrag(PointerEventData eventData)
    {
        // Kartý eski yerine (veya yeni atandýðý yuvaya) geri koy
        transform.SetParent(originalParent);
        canvasGroup.blocksRaycasts = true;

        // YENÝ EKLENEN KISIM: Eðer kart geçerli bir yere býrakýlmayýp eski yuvasýna geri döndüyse,
        // yuvaya kendini tekrar tanýtmasý gerekir.
        CardSlot slot = originalParent.GetComponent<CardSlot>();
        if (slot != null)
        {
            slot.currentCard = GetComponent<CardDisplay>();
        }
    }
}