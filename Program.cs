using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Puzzle
{
    public class gameBoard
    {
        private int moveCount;
        private String[] puzzlePieces = new string[7];

        public gameBoard()
        {
            int moveCount = 0;
            puzzlePieces = new string[7] { "L", "L", "L", " ", "R", "R", "R" };
            randomize();
            print();
        }

        public void randomize()
        {
            Random rnd = new Random();
            for (int i = 0; i < 300; i++) { 
                int ran = rnd.Next(0, 6);
                int ran2 = rnd.Next(0, 6);
                string temp = puzzlePieces[ran2];
                puzzlePieces[ran2] = puzzlePieces[ran];
                puzzlePieces[ran] = temp;
            }
        }

        public bool winner()
        {
            if (puzzlePieces[0].Equals("L") && puzzlePieces[1].Equals("L") && puzzlePieces[2].Equals("L") 
                && puzzlePieces[3].Equals(" ") && puzzlePieces[4].Equals("R") && puzzlePieces[5].Equals("R") && puzzlePieces[6].Equals("R"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void moveLeft(int pos)
        {
            string temp = puzzlePieces[pos];
            puzzlePieces[pos] = puzzlePieces[pos - 1];
            puzzlePieces[pos - 1] = temp;
            moveCount++;
        }

        public void moveLeft2(int pos)
        {
            string temp = puzzlePieces[pos];
            puzzlePieces[pos] = puzzlePieces[pos - 2];
            puzzlePieces[pos - 2] = temp;
            moveCount = moveCount + 2;
        }

        public void moveRight(int pos)
        {
            string temp = puzzlePieces[pos];
            puzzlePieces[pos] = puzzlePieces[pos + 1];
            puzzlePieces[pos + 1] = temp;
            moveCount++;
        }

        public void moveRight2(int pos)
        {
            string temp = puzzlePieces[pos];
            puzzlePieces[pos] = puzzlePieces[pos + 2];
            puzzlePieces[pos + 2] = temp;
            moveCount = moveCount + 2;
        }

        public void print()
        {
            for (int i = 0; i < 7; i++)
            {
                Console.Write(puzzlePieces[i] + " ");
            }
            Console.WriteLine();
        }

        public int getMoveCount()
        {
            return moveCount;
        }
    } 

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            gameBoard puzzle = new gameBoard();
            puzzle.randomize();
            Instructions();
            puzzle.print();
            userInput(puzzle);
        }

        static void Instructions()
        {
            Console.WriteLine("Enter the position number followed by the direction");
            Console.WriteLine("Legal position can be between 1 and 7");
            Console.WriteLine("Legal directions are R, 2R, L, and 2L");
            Console.WriteLine("Type Q to quit");
        }

        static void userInput(gameBoard Puzzle)
        {
            while(true){
               string input = Console.ReadLine();
               Puzzle =  parse(input, Puzzle);
               Puzzle.print();
               Console.WriteLine(Puzzle.getMoveCount());
               Puzzle.winner();
            }
        }

        static gameBoard parse(string input,gameBoard Puzzle)
        {
            char[] delimiterChars = { ' '};
            string[] words = input.Split(delimiterChars);
            if (words[0].Equals("q") || words[0].Equals("Q"))
            {
                Environment.Exit(0);
            }
            else if (words.Length == 2)
            {
               int pos = 0;
               string piece = words[0];
               bool result = int.TryParse(piece, out pos);
               if (result == false)
               {
                   Console.WriteLine("Bad number value");
               }
               else
               {
                   if (words[1].Equals("R") || words[1].Equals("r"))
                   {
                       if (pos < 7)
                       {
                           Puzzle.moveRight(pos - 1);
                       }
                       else
                       {
                           Console.WriteLine("Move is invalid");
                       }
                   }
                   else if (words[1].Equals("L") || words[1].Equals("l"))
                   {
                       if (pos > 1)
                       {
                           Puzzle.moveLeft(pos - 1);
                       }
                       else
                       {
                           Console.WriteLine("Move is invalid");
                       }
                   }
                   else if (words[1].Equals("2L") || words[1].Equals("2l"))
                   {
                       if (pos < 2)
                       {
                           Puzzle.moveLeft2(pos - 1);
                       }
                       else
                       {
                           Console.WriteLine("Move is invalid");
                       }
                   }
                   else if (words[1].Equals("2R") || words[1].Equals("2r"))
                   {
                       if (pos < 6)
                       {
                           Puzzle.moveRight2(pos - 1);
                       }
                       else
                       {
                           Console.WriteLine("Move is invalid");
                       }
                   }
                   else
                   {
                       Console.WriteLine("Please type the proper direction");
                   }
               }
            }
            else
            {
                Console.WriteLine("Please retype command");
            }
            return Puzzle;
        }
    }
}