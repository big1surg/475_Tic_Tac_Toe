using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Tic_Tac_Toe{
    /// <summary>
    /// Program is a game of simple tic tac toe
    /// </summary>
    class TicTacToe{
        private int player;
        int choice;
        static char [] arr = {'0','1','2','3','4','5','6','7','8','9'};
        static char[,] arr1 = new char [3,3];
        private int win;
        string choice1;

        /// <summary>
        /// Construtor
        /// </summary>
        public TicTacToe(){
            Console.Clear();
            int count = 1;
            for(int i=0; i<3; i++) {
                for(int j =0; j<3; j++) {
                    arr1[i, j] = arr[count++];
                    //Console.WriteLine(arr1[i, j]);
                }
            }

            player = 1;
            win = 0;
        }

        /// <summary>
        /// Prints the game board
        /// </summary>
        public void PrintBoard(){
            
            Console.WriteLine("Player1: X and Player2 : O");
            Console.WriteLine("\n");
            Console.WriteLine("      |      |    ");
            Console.WriteLine("   {0}  |  {1}   |   {2} ", arr1[0,0], arr1[0, 1], arr1[0, 2]);
            Console.WriteLine("______|______|______");
            Console.WriteLine("      |      |    ");
            Console.WriteLine("   {0}  |  {1}   |   {2} ", arr1[1, 0], arr1[1, 1], arr1[1, 2]);
            Console.WriteLine("______|______|______");
            Console.WriteLine("      |      |    ");
            Console.WriteLine("   {0}  |  {1}   |   {2} ", arr1[2, 0], arr1[2, 1], arr1[2, 2]);
            Console.WriteLine("      |      |    ");
        }

        /// <summary>
        /// Logic for the game
        /// </summary>
        public void Play(){
            do{
                if (player==2){
                    Console.WriteLine("Player 2 Chance");
                }else{
                    Console.WriteLine("Player 1 Chance");
                }
                Console.WriteLine("\n");

                do {
                    Console.Write("Enter: ");
                    choice1 = Console.ReadLine();
                } while (!int.TryParse(choice1, out choice));

                if(choice>0 && choice < 4) {
                    if(arr1[0,choice-1] != 'X' && arr1[0,choice-1] != 'O') {
                        if(player == 2) {
                            arr1[0, choice-1] = '0';
                            player--;
                        }else {
                            arr1[0, choice-1] = 'X';
                            player++;
                        }
                    }else {
                        Console.WriteLine("Square {0} is {1}", choice, arr1[0, choice-1]);
                        Thread.Sleep(1000);
                    }
                }else if (choice > 3 && choice < 7) {
                    //4,5,6
                    if (arr1[1, choice-4] != 'X' && arr1[1, choice-4] != 'O') {
                        if (player == 2) {
                            arr1[1, choice-4] = '0';
                            player--;
                        } else {
                            arr1[1, choice-4] = 'X';
                            player++;
                        }
                    } else {
                        Console.WriteLine("Square {0} is {1}", choice, arr1[1, choice-4]);
                        Thread.Sleep(1000);
                    }
                }else {
                    if (arr1[2, choice-7] != 'X' && arr1[2, choice-7] != 'O') {
                        if (player == 2) {
                            arr1[2, choice-7] = '0';
                            player--;
                        } else {
                            arr1[2, choice-7] = 'X';
                            player++;
                        }
                    } else {
                        Console.WriteLine("Square {0} is {1}", choice, arr1[0, choice-7]);
                        Thread.Sleep(1000);
                    }
                }
                win = CheckWin();
                Console.Clear();
                PrintBoard();
            } while (win != 1 && win != -1);

            Console.Clear();
            PrintBoard();

            if(win == 1){
                Console.WriteLine("Player {0} has won", (player % 2) + 1); //(1%2) == 1 + 1 == player 2
            } else {
                Console.WriteLine("Draw");
            }
            Console.ReadLine();
        }

        //method used for checking if there is a winner after every turn
        /// <summary>
        /// Checks if anyone has won, it is checked after every turn
        /// </summary>
        /// <returns>a 1 is someone has won, returns -1 if its a draw, 0 is no one has one</returns>
        public int CheckWin(){
            int count = 0;

            if (arr1[0, 0] == arr1[0, 1] && arr1[0, 1] == arr1[0, 2]) {
                return 1;//if any column is the same they win
            } else if (arr1[1, 0] == arr1[1, 1] && arr1[1, 1] == arr1[1, 2]) {
                return 1;
            } else if(arr1[2, 0] == arr1[2, 1] && arr1[2, 1] == arr1[2, 2]) {
                return 1;
            }
            //vertical win
            else if (arr1[0, 0] == arr1[1, 0] && arr1[1, 0] == arr1[2, 0]) {
                return 1;
            } else if (arr1[0, 1] == arr1[1, 1] && arr1[1, 1] == arr1[2, 1]) {
                return 1;
            } else if (arr1[0, 2] == arr1[1, 2] && arr1[1, 2] == arr1[2, 2]) {
                return 1;
            }
            //diagonal
            else if (arr1[0,0] == arr1[1,1] && arr1[1,1] == arr1[2, 2]) {
                return 1;
            } else if (arr1[0,2] == arr1[1,1] && arr1[1,1] == arr1[2, 0]) {
                return 1;
            }else if (count != 0 && CheckDraw()) {
                return -1;
            } else {
                return 0;
            }
            count++;
 
        } //end checkwin method

        //method used for checking if there is a draw
        /// <summary>
        /// method that checks if there is a draw
        /// </summary>
        /// <returns>bool stating whether there is a draw or not</returns>
        public bool CheckDraw(){
            bool draw = false;
            int count =1;
            for (int i = 0; i < 3; i++) {
                for (int k = 0; k < 3; k++) {
                    if (arr1[i, k] == 'X' || arr1[i,k] == 'O') {
                        draw = true;
                    }
            
                } 
            }
            return draw;
        } //end checkDraw

    } //end class
}
