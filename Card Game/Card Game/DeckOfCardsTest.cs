using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Card_Game
{


   class DeckOfCardsTest
   {
     

      static void Main(string[] args)
      {
         //create a new instance of DeckOfCardsTest to call methods
         DeckOfCardsTest test = new DeckOfCardsTest();

         //create Card arrays to hold the hands
         Card[] compHand = new Card[5];
         Card[] playerHand = new Card[5];

         //create a new deck and shuffle the cards
         DeckOfCards myDeck = new DeckOfCards();
         myDeck.Shuffle();

         //deal the cards to the hand arrays
         for (int i = 0; i < 5; i++)
         {
            playerHand[i] = myDeck.DealCard();
            compHand[i] = myDeck.DealCard();            
         } // end of for

         
         //display the hands
         Console.WriteLine($"Player's Hand");
         for (int i = 0; i < 5; i++)
         {
            playerHand[i].DisplayCard(1, i * 6);  
         }

         Console.SetCursorPosition(0, 7);
         Console.WriteLine($"Computer's Hand");
         for (int i = 0; i < 5; i++)
         {
            compHand[i].DisplayCard(8, i * 6);
         }
         
         //call the CheckHand method to determine the hands held
         test.CheckHand(playerHand, compHand);

         
         //display each players hand
         Console.WriteLine($"Player Hand: {test.handp}");
         Console.WriteLine();
         Console.WriteLine($"Computer Hand: {test.handc}");
         Console.WriteLine();

         //use the DetermineWinner method to determine and display the winner
         test.DetermineWinner(test.handp, test.handc);
         
      }// end of Main

      //create strings to hold the player's hands
      private string handp = "Nothing";
      private string handc = "Nothing";

      public void CheckHand(Card[] playerHand, Card[] compHand)
      {
         //create variables to be used to determine the hands
         int playerPair = 0;
         int playerThreeKind = 0;
         int compPair = 0;
         int compThreeKind = 0;

         
        //sort both hands by face and suit seperately
         var sortedPlayerHand = from playerCard in playerHand
                                orderby playerCard.getFace()
                                select playerCard.getFace();

         var sortedComputerHand = from computerCard in compHand
                                  orderby computerCard.getFace()
                                  select computerCard.getFace();

         var sortedPlayerHandSuits = from playerCard in playerHand
                                orderby playerCard.getSuit()
                                select playerCard.getSuit();

         var sortedComputerHandSuits = from computerCard in compHand
                                  orderby computerCard.getSuit()
                                  select computerCard.getSuit();

         //sort and store how many times if any a duplicate happens
         var faces = from x in sortedPlayerHand
                 group x by x into g
                 let count = g.Count()
                 orderby count descending
                 select new { Value = g.Key, Count = count, };

         //sort and store how many times a duplicate happens
         var suits = from x in sortedPlayerHandSuits
                     group x by x into g
                     let count = g.Count()
                     orderby count descending
                     select new { Value = g.Key, Count = count, };

         //create new arrays so convert string to int and determine if the player has a straight
         string[] playerStringValue = new string[5];
         int[] playerCardValue = new int[5];
         Console.WriteLine();

         //loop to convert faces to string and letters to number equivalents
         for (int i = 0; i < playerHand.Length; i++)
         {
            playerStringValue[i] = playerHand[i].getFace().ToString();

            //switch the letter values to numbers
            switch (playerStringValue[i])
            {
               case "A":
                  playerStringValue[i] = "1";
                  break;
               case "T":
                  playerStringValue[i] = "10";
                  break;
               case "J":
                  playerStringValue[i] = "11";
                  break;
               case "Q":
                  playerStringValue[i] = "12";
                  break;
               case "K":
                  playerStringValue[i] = "13";
                  break;
               default:
                  break;
            }
         }

         //loop to convert strings to number and store them in an array
         for (int i = 0; i < playerStringValue.Length; i++)
         {
            playerCardValue[i] = int.Parse(playerStringValue[i]);
         }

         Console.WriteLine();

         //sort the aray in ascending order
         Array.Sort(playerCardValue);

         //determine if the player holds a straight
         if (playerCardValue[0] +4 == playerCardValue[4])
         {
            handp = "Straight";
         }

         //arrays to convert strings to numbers for the computers hand
         string[] computerStringValue = new string[5];
         int[] computerCardValue = new int[5];

         //loop to convert face cards to string in computer hand
         for (int i = 0; i < compHand.Length; i++)
         {
            computerStringValue[i] = compHand[i].getFace().ToString();

            switch (computerStringValue[i])
            {
               case "A":
                  computerStringValue[i] = "1";
                  break;
               case "T":
                  computerStringValue[i] = "10";
                  break;
               case "J":
                  computerStringValue[i] = "11";
                  break;
               case "Q":
                  computerStringValue[i] = "12";
                  break;
               case "K":
                  computerStringValue[i] = "13";
                  break;
               default:
                  break;
            }
         }

         //loop to convert strings to numbers in the computers hand
         for (int i = 0; i < computerStringValue.Length; i++)
         {
            computerCardValue[i] = int.Parse(computerStringValue[i]);
         }

         Console.WriteLine();

         //sort the array in ascending order
         Array.Sort(computerCardValue);

         //determine if the computer is holding a striaght
         if (computerCardValue[0] + 4 == computerCardValue[4])
         {
            handc = "Straight";
         }

         //determine the players hand
         foreach (var x in suits)
         {
            if (x.Count == 5)
            {
               handp = "Flush";
            }
         }
         Console.WriteLine();
         
         foreach (var x in faces)
         {

            
            if (x.Count == 2)
            {
               playerPair++;
               handp = "Pair";
            }
            if (x.Count == 3)
            {
               handp = "Three of a Kind";
               playerThreeKind++;
            }
            if (x.Count == 4)
            {
               handp = "Four of a Kind";

            }
            if (playerPair == 1 && playerThreeKind == 1)
            {
               handp = "Full House";
            }
            if (playerPair == 2)
            {
               handp = "Two Pair";
            }
            
         }         
         Console.WriteLine();


         //sort the computers hand by face and suit
         var compFaces = from y in sortedComputerHand
                 group y by y into h
                 let count = h.Count()
                 orderby count descending
                 select new { Value = h.Key, Count = count, };

         var compSuits = from y in sortedComputerHandSuits
                 group y by y into h
                 let count = h.Count()
                 orderby count descending
                 select new { Value = h.Key, Count = count, };

         //determine the computers hand
         foreach (var y in compSuits)
         {
            if (y.Count == 5)
            {
               handc = "Flush";
            }
         }
         Console.WriteLine();
         foreach (var y in compFaces)
         {
            //Console.WriteLine("Value: " + y.Value + " Count: " + y.Count);
            if (y.Count == 2)
            {
               compPair++;
               handc = "Pair";
            }
            if (y.Count == 3)
            {
               handc = "Three of a Kind";
               compThreeKind++;
            }
            if (y.Count == 4)
            {
               handc = "Four of a Kind";

            }
            if (compPair == 1 && compThreeKind == 1)
            {
               handc = "Full House";
            }
            if (compPair == 2)
            {
               handc = "Two Pair";
            }
         }         
      }

      public void DetermineWinner(string playerHand, string computerHand)
      {
         //variables to detrermine the winner
         int pHand = 0;
         int cHand = 0;

         //used a switch statement to equate the hand name to a value according to the project documents
         switch (playerHand)
         {
            case "Four of a Kind":
               pHand = 7;
               break;
            case "Full House":
               pHand = 6;
               break;
            case "Flush":
               pHand = 5;
               break;
            case "Straight":
               pHand = 4;
               break;
            case "Three of a Kind":
               pHand = 3;
               break;
            case "Two Pairs":
               pHand = 2;
               break;
            case "Pair":
               pHand = 1;
               break;
            default:
               break;
         }

         //used a switch statement to equate the hand name to a value according to the project documents
         switch (computerHand)
         {
            case "Four of a Kind":
               cHand = 7;
               break;
            case "Full House":
               cHand = 6;
               break;
            case "Flush":
               cHand = 5;
               break;
            case "Straight":
               cHand = 4;
               break;
            case "Three of a Kind":
               cHand = 3;
               break;
            case "Two Pairs":
               cHand = 2;
               break;
            case "Pair":
               cHand = 1;
               break;
            default:
               break;
         }

         //use the following if statements to determine win, loss, and tie 
         if (pHand == cHand)
         {
            Console.WriteLine("Tie Game");
         }
         if (pHand > cHand)
         {
            Console.WriteLine("Player Wins");
         }
         if (pHand < cHand)
         {
            Console.WriteLine("Computer Wins");
         }
         

      }
   } // end of class
}
