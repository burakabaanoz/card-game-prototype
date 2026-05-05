using UnityEngine;

// Bu satýr, Unity'de sað týkladýðýmýzda menüde "Yeni Kart" seçeneði çýkmasýný saðlar
[CreateAssetMenu(fileName = "YeniKart", menuName = "Kart Oyunu/Yeni Kart")]
public class CardData : ScriptableObject
{
    public string cardName;
    public string description;
    public int attack;
    public int health;
    public Sprite artwork; // Kartýn üzerindeki resim
}