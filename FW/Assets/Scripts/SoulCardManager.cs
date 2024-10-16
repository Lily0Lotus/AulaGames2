using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoulCardManager : MonoBehaviour
{
    [Header("Card Parameters")]
    public int amtOfSouls;
    int currAmtCard = 0;
    public CardScriptableObject[] SoulCardSO;
    public GameObject cardPrefab;
    public Transform cardHolderTransform;

    [Header("Soul Parameters")]
    public GameObject[] soulCards;
    public float cooldown;
    public int custo;
    public Texture soulIcon;

    private void Start()
    {
        soulCards = new GameObject[amtOfSouls];

        for (int i = 0; i < amtOfSouls; i++)
        {
            AddSoulCard(i);
        }
    }

    public void AddSoulCard(int index)
    {

        GameObject card = Instantiate(cardPrefab, cardHolderTransform);

        soulCards[index] = card;

        //pega as variáveis
        soulIcon = SoulCardSO[index].SoulIcon;
        custo = SoulCardSO[index].custo;
        cooldown = SoulCardSO[index].cooldown;

        //atualizar UI
        card.GetComponentInChildren<RawImage>().texture = soulIcon;
        card.GetComponentInChildren<TMP_Text>().text = "" + custo;
    }
}
