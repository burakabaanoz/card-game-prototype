using UnityEngine;
using System.Collections; // Zamanlama (Coroutine) kullanabilmek için gerekli
using System.Collections.Generic; // Liste (List) kullanabilmek için gerekli

public class TurnManager : MonoBehaviour
{
    [Header("Oyuncu Yuvalarý (Soldan Saða)")]
    public List<CardSlot> playerSlots; // Masadaki 4 yuvamýzý bu listeye ekleyeceðiz

    // Bu fonksiyonu doðrudan Tur Atla butonuna baðlayacaðýz
    public void OnEndTurnButtonClicked()
    {
        // Saldýrýlarý sýrayla baþlatmak için Coroutine çalýþtýrýyoruz
        StartCoroutine(ExecuteAttacksSequence());
    }

    // Kartlarýn soldan saða sýrayla saldýrmasýný saðlayan zamanlý döngü
    IEnumerator ExecuteAttacksSequence()
    {
        Debug.Log("--- SAVAÞ AÞAMASI BAÞLADI ---");

        // Listeye eklediðimiz her bir yuva (slot) için sýrayla iþlem yap
        foreach (CardSlot slot in playerSlots)
        {
            // Sadece içinde kart olan yuvalar saldýrabilir
            if (slot.currentCard != null)
            {
                slot.AttackOpponent(); // Yuvaya "Saldýr!" emrini ver

                // Bir sonraki kartýn saldýrmasý için 0.5 saniye bekle (Hissiyatý güçlendirir)
                yield return new WaitForSeconds(0.5f);
            }
        }

        Debug.Log("--- SAVAÞ AÞAMASI BÝTTÝ ---");
    }
}