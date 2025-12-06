using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCardsOnTable : MonoBehaviour
{
    public GenerateSelection generator;

    private List<GameObject> currentCards = new List<GameObject>();
    public GameObject cardPrefab;
    public RectTransform tableArea;     
    public float spacing = 160f;        
    public Sprite[] cardSprites;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            SpawnHand();
        }
    }

    void SpawnHand()
    {
        // destruir cartas previas
        foreach (var card in currentCards)
            Destroy(card);
        currentCards.Clear();

        // obtener mano de 5 cartas
        List<int> hand = generator.Selection(5);

        for (int i = 0; i < hand.Count; i++)
        {
            GameObject card = Instantiate(cardPrefab, tableArea);
            //chatgpt
            RectTransform rt = card.GetComponent<RectTransform>();
            // Posición = separada por spacing
            rt.anchoredPosition = new Vector2(i * spacing, 0);

            // Imagen 
            Image img = card.GetComponent<Image>();
            img.sprite = cardSprites[hand[i]];
            img.preserveAspect = true;

            currentCards.Add(card);
            //chatgpt
        }
    }
}
