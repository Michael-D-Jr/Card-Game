using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Card_Game
{
   class Card
   {
      private string face;
      private string suit;

      public string getFace()
      {
         return face;
      }

      public string getSuit()
      {
         return suit;
      }

      public Card(string cardFace, string cardSuit)
      {
         face = cardFace;
         suit = cardSuit;
      } // end of constructor

      public override string ToString()
      {
         return face + " of " + suit;
      }  // end of ToString

      public void DisplayCard(int row, int col)
      {
         Console.SetCursorPosition(col, row);
         Console.BackgroundColor = ConsoleColor.White;
         Console.ForegroundColor = ConsoleColor.Blue;
         Console.Write("╔═══╗");
         Console.SetCursorPosition(col, row + 1);
         Console.Write("║ ");
         if (suit == "Diamonds" || suit == "Hearts")
         {
            Console.ForegroundColor = ConsoleColor.Red;
         }
         else
         {
            Console.ForegroundColor = ConsoleColor.Black;
         }
         Console.Write(face);
         Console.ForegroundColor = ConsoleColor.Blue;
         Console.Write(" ║");
         Console.SetCursorPosition(col, row + 2);
         Console.Write("║   ║");
         Console.SetCursorPosition(col, row + 3);
         Console.Write("║ ");
         if (suit == "Diamonds" || suit == "Hearts")
         {
            Console.ForegroundColor = ConsoleColor.Red;
         }
         else
         {
            Console.ForegroundColor = ConsoleColor.Black;
         }
         if (suit == "Diamonds")
         {
            Console.Write("♦");
         }
         if (suit == "Hearts")
         {
            Console.Write("♥");
         }
         if (suit == "Spades")
         {
            Console.Write("♠");
         }
         if (suit == "Clubs")
         {
            Console.Write("♣");
         }
         Console.ForegroundColor = ConsoleColor.Blue;
         Console.Write(" ║");
         Console.SetCursorPosition(col, row + 4);
         Console.Write("╚═══╝");

         Console.BackgroundColor = ConsoleColor.Black;
         Console.ForegroundColor = ConsoleColor.White;
      }

   } // end of class
} // end of namespace
