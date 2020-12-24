using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Card_Game
{
   class DeckOfCards
   {
      private Card[] deck;
      private int currentCard;
      private const int NUMBER_OF_CARDS = 52;
      private Random randomNumbers;

      public DeckOfCards()
      {
         string[] faces = {"A", "2", "3",
                           "4", "5", "6",
                           "7", "8", "9",
                           "T", "J", "Q",
                           "K"};
         string[] suits = {"Hearts", "Diamonds",
                           "Clubs", "Spades"};

         deck = new Card[NUMBER_OF_CARDS];
         currentCard = 0;
         randomNumbers = new Random();

         for (int count = 0; count < deck.Length; count++)
         {
            deck[count] = new Card(faces[count % 13],
                                   suits[count / 13]);
         }// end of for

      }  // end of constructor

      public void Shuffle()
      {
         currentCard = 0;

         for (int first = 0; first < deck.Length; first++)
         {
            int second = randomNumbers.Next(NUMBER_OF_CARDS);

            Card temp = deck[first];
            deck[first] = deck[second];
            deck[second] = temp;
         } // end of for
      } // end of method Shuffle

      public Card DealCard()
      {
         if (currentCard < deck.Length)
         {
            return deck[currentCard++];
         }
         else
         {
            return null;
         }
      } // end of DealCard
   } // end of class
} // end of namespace
