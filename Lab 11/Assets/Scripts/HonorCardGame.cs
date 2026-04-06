using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardGame : MonoBehaviour
{
    void Start()
    {
        // 1. Build and shuffle the deck
        string[] suits = { "\u2660", "\u2663", "\u2665", "\u2666" }; // ♠ ♣ ♥ ♦
        string[] ranks = { "K", "Q", "J", "A" };

        List<string> deck = (
            from suit in suits
            from rank in ranks
            select rank + suit
        ).OrderBy(_ => Random.value).ToList();

        // 2. Deal opening hand of 4 cards
        List<string> hand = deck.Take(4).ToList();
        deck = deck.Skip(4).ToList();

        Debug.Log($"I made the initial deck and draw. My hand is: {string.Join(", ", hand)}.");

        // 5. Game loop
        while (true)
        {
            // 4. Evaluate winning condition — at least three cards share the same suit
            bool isWinningHand = hand
                .GroupBy(card => card[^1].ToString())   // group by last char (the suit symbol)
                .Any(g => g.Count() >= 3);

            if (isWinningHand)
            {
                Debug.Log($"My hand is: {string.Join(", ", hand)}. The game is WON.");
                break;
            }

            if (deck.Count == 0)
            {
                Debug.Log("The deck is empty. The game is LOST.");
                break;
            }

            // Discard a random card and draw a new one
            int discardIndex = Random.Range(0, hand.Count);
            string discarded = hand[discardIndex];
            string drawn = deck[0];
            deck.RemoveAt(0);

            hand[discardIndex] = drawn;

            Debug.Log(
                $"I discarded {discarded} and drew {drawn}. " +
                $"My hand is: {string.Join(", ", hand)}. " +
                $"This is not a winning hand. I will attempt to play another round."
            );
        }
    }
}