using System;
using System.Collections.Generic;
using System.Threading;

namespace Roulette_Ex07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class Program
    {

        static void Main(string[] args)
        {
            int[,] roulettearray = new int[3, 12] {
            {1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34},//0
            {2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35},//1
            {3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36 }//2
            };


            Roulette roulette = new Roulette();
            roulette.PickNums();




            Console.ReadKey();

        }
    }

    class Roulette
    {
        private int _Score = 100;
        private int _bet;
        private int _atStake;
        private int _iterations = 0;
        private string _userGuess;
        private int _ranInd;
        private int _loanPayOff =1;
        private int _loan;
        private bool _hasDebt =false;
        private static int[] _RouletteNums = new int[38] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 100 };
        private static string[] _RouletteColors = new string[38] { "green", "red", "black", "red", "black", "red", "black", "red", "black", "red", "black", "black", "red", "black", "red", "black", "red", "black", "red", "red", "black", "red", "black", "red", "black", "red", "black", "red", "black", "black", "red", "black", "red", "black", "red", "black", "red", "green" };
        private static int[] thirdRow = new int[12] { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36 };
        private static int[] secondRow = new int[12] { 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 };
        private static int[] firstRow = new int[12] { 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34 };
        Random indexer = new Random();
        enum Options
        {
            Numbers,
            EvenOdds,
            RedsBlacks,
            LowsHighs,
            Dozens,
            Columns,
            Street,
            SixNums,
            Split,
            Corner
        }
        private List<int> returnCorner(int firstNum)
        {
            List<int> possibleNums = new List<int>();


            int indexOfFirstNum;
            if (Array.IndexOf(firstRow, firstNum) >= 0)
            {
                indexOfFirstNum = Array.IndexOf(firstRow, firstNum);
                switch (indexOfFirstNum)
                {
                    case 0:
                        possibleNums.Add(firstRow[indexOfFirstNum + 1]);
                        possibleNums.Add(secondRow[indexOfFirstNum]);
                        possibleNums.Add(secondRow[indexOfFirstNum + 1]);
                        break;
                    case 11:
                        possibleNums.Add(firstRow[indexOfFirstNum - 1]);
                        possibleNums.Add(secondRow[indexOfFirstNum]);
                        possibleNums.Add(secondRow[indexOfFirstNum - 1]);
                        break;
                    default:
                        possibleNums.Add(firstRow[indexOfFirstNum + 1]);
                        possibleNums.Add(secondRow[indexOfFirstNum]);
                        possibleNums.Add(secondRow[indexOfFirstNum + 1]);

                        possibleNums.Add(secondRow[indexOfFirstNum - 1]);
                        possibleNums.Add(secondRow[indexOfFirstNum]);
                        possibleNums.Add(firstRow[indexOfFirstNum - 1]);
                        break;
                }
            }
            else if (Array.IndexOf(secondRow, firstNum) >= 0)
            {
                indexOfFirstNum = Array.IndexOf(secondRow, firstNum);
                switch (indexOfFirstNum)
                {
                    case 0:
                        possibleNums.Add(firstRow[indexOfFirstNum + 1]);
                        possibleNums.Add(firstRow[indexOfFirstNum]);
                        possibleNums.Add(secondRow[indexOfFirstNum + 1]);

                        possibleNums.Add(thirdRow[indexOfFirstNum + 1]);
                        possibleNums.Add(thirdRow[indexOfFirstNum]);
                        possibleNums.Add(secondRow[indexOfFirstNum + 1]);

                        break;
                    case 11:
                        possibleNums.Add(firstRow[indexOfFirstNum]);
                        possibleNums.Add(secondRow[indexOfFirstNum - 1]);
                        possibleNums.Add(firstRow[indexOfFirstNum - 1]);

                        possibleNums.Add(thirdRow[indexOfFirstNum]);
                        possibleNums.Add(secondRow[indexOfFirstNum - 1]);
                        possibleNums.Add(thirdRow[indexOfFirstNum - 1]);
                        break;
                    default:
                        possibleNums.Add(firstRow[indexOfFirstNum]);
                        possibleNums.Add(secondRow[indexOfFirstNum - 1]);
                        possibleNums.Add(firstRow[indexOfFirstNum - 1]);

                        possibleNums.Add(thirdRow[indexOfFirstNum]);
                        possibleNums.Add(secondRow[indexOfFirstNum - 1]);
                        possibleNums.Add(thirdRow[indexOfFirstNum - 1]);

                        possibleNums.Add(firstRow[indexOfFirstNum + 1]);
                        possibleNums.Add(firstRow[indexOfFirstNum]);
                        possibleNums.Add(secondRow[indexOfFirstNum + 1]);

                        possibleNums.Add(thirdRow[indexOfFirstNum + 1]);
                        possibleNums.Add(thirdRow[indexOfFirstNum]);
                        possibleNums.Add(secondRow[indexOfFirstNum + 1]);
                        break;
                }
            }
            else if (Array.IndexOf(thirdRow, firstNum) >= 0)
            {
                indexOfFirstNum = Array.IndexOf(thirdRow, firstNum);
                switch (indexOfFirstNum)
                {
                    case 0:
                        possibleNums.Add(thirdRow[indexOfFirstNum + 1]);
                        possibleNums.Add(secondRow[indexOfFirstNum]);
                        possibleNums.Add(secondRow[indexOfFirstNum + 1]);
                        break;
                    case 11:
                        possibleNums.Add(thirdRow[indexOfFirstNum - 1]);
                        possibleNums.Add(secondRow[indexOfFirstNum]);
                        possibleNums.Add(secondRow[indexOfFirstNum - 1]);
                        break;
                    default:
                        possibleNums.Add(thirdRow[indexOfFirstNum + 1]);
                        possibleNums.Add(secondRow[indexOfFirstNum]);
                        possibleNums.Add(secondRow[indexOfFirstNum + 1]);

                        possibleNums.Add(secondRow[indexOfFirstNum - 1]);
                        possibleNums.Add(secondRow[indexOfFirstNum]);
                        possibleNums.Add(thirdRow[indexOfFirstNum - 1]);
                        break;
                }
            }
            return possibleNums;
        }
        private List<int> returnSplit(int firstNum)
        {
            List<int> possibleNums = new List<int>();

            int indexOfFirstNum;
            if (Array.IndexOf(firstRow, firstNum) >= 0)
            {
                indexOfFirstNum = Array.IndexOf(firstRow, firstNum);
                switch (indexOfFirstNum)
                {
                    case 0:
                        possibleNums.Add(firstRow[indexOfFirstNum + 1]);
                        possibleNums.Add(secondRow[indexOfFirstNum]);
                        break;
                    case 11:
                        possibleNums.Add(firstRow[indexOfFirstNum - 1]);
                        possibleNums.Add(secondRow[indexOfFirstNum]);
                        break;
                    default:
                        possibleNums.Add(firstRow[indexOfFirstNum + 1]);
                        possibleNums.Add(secondRow[indexOfFirstNum]);
                        possibleNums.Add(firstRow[indexOfFirstNum - 1]);
                        break;
                }
            }
            else if (Array.IndexOf(secondRow, firstNum) >= 0)
            {
                indexOfFirstNum = Array.IndexOf(secondRow, firstNum);
                switch (indexOfFirstNum)
                {
                    case 0:
                        possibleNums.Add(firstRow[indexOfFirstNum]);
                        possibleNums.Add(thirdRow[indexOfFirstNum]);
                        possibleNums.Add(secondRow[indexOfFirstNum + 1]);
                        break;
                    case 11:
                        possibleNums.Add(firstRow[indexOfFirstNum]);
                        possibleNums.Add(thirdRow[indexOfFirstNum]);
                        possibleNums.Add(secondRow[indexOfFirstNum - 1]);
                        break;
                    default:
                        possibleNums.Add(firstRow[indexOfFirstNum]);
                        possibleNums.Add(thirdRow[indexOfFirstNum]);
                        possibleNums.Add(secondRow[indexOfFirstNum + 1]);
                        possibleNums.Add(secondRow[indexOfFirstNum - 1]);
                        break;
                }
            }
            else if (Array.IndexOf(thirdRow, firstNum) >= 0)
            {
                indexOfFirstNum = Array.IndexOf(thirdRow, firstNum);
                switch (indexOfFirstNum)
                {
                    case 0:
                        possibleNums.Add(secondRow[indexOfFirstNum + 1]);
                        possibleNums.Add(secondRow[indexOfFirstNum]);
                        break;
                    case 11:
                        possibleNums.Add(thirdRow[indexOfFirstNum - 1]);
                        possibleNums.Add(secondRow[indexOfFirstNum]);
                        break;
                    default:
                        possibleNums.Add(thirdRow[indexOfFirstNum + 1]);
                        possibleNums.Add(secondRow[indexOfFirstNum]);
                        possibleNums.Add(thirdRow[indexOfFirstNum - 1]);
                        break;
                }
            }
            return possibleNums;
        }
        private bool BetChecker()
        {

            if (_bet <= _Score && _Score>0  )
            {
                Console.WriteLine("Bet accepted");
                return true;
            }
            else
            {
                Console.WriteLine("You do not have a sufficient balance for this bet");
                return false;
            }
        }
        private bool askBet(int payOut)
        {
            Console.WriteLine($"How much would you like to bet?:\t\t\tCurrent Balance: ${_Score}");
            Console.Write("$");
            this._bet = int.Parse(Console.ReadLine());
            this._atStake = _bet * payOut;
            if (BetChecker())
            {
                return true;
            }
            
            else
            {
                return false;
            }
        }
        private void WinningsCalc(bool won)
        {
            if (won)
            {
                this._Score += _atStake;
                Console.WriteLine($"You Won ${_atStake}.\nYour current Holdings are: ${_Score}");
                ++_iterations;
                if (_hasDebt)
                {
                    _loanPayOff--;
                }
            }

            else
            {
                if (_hasDebt)
                {
                    _loanPayOff--;
                }
                this._Score -= _bet;
                Console.WriteLine($"You Lost ${_bet}.\nYour current balance is at: ${_Score}\n\n");
                ++_iterations;
                
                if (_Score <= 0 && !_hasDebt)
                {
                    do
                    {
                    Console.WriteLine($"'To help you get back on your feet; Here is a small loan, Dont forget, you owe us.'\n\t\t\t\t\t\t\t\t-Mob Boss Dimitri\n");
                    Console.WriteLine("type a loan amount, up to 1000");
                    this._loan += int.Parse(Console.ReadLine());
                    this._loanPayOff = 20 - (_loan / 70);
                    this._hasDebt = true;
                    this._Score += _loan;
                    Console.WriteLine($"You picked  loan of ${_loan}, you have {_loanPayOff} rounds to pay it back");
                    Console.WriteLine($"-${_loan} in debt\t\t|\tcr.bal: ${ _Score}\n");
                    

                    } while (this._loan < 0 && this._loan > 1000);
                }
            }
            Console.ReadLine();
        }
        public bool AskHasDebt()
        {
            if (this._hasDebt)
            {
                Console.WriteLine($"Iteration: { _iterations}\t\t\tBalance: ${_Score}\t|\t-${_loan} debt owed\t|\t{_loanPayOff} rounds to pay back");
                return true;
            }
            else
            {
                Console.WriteLine($"Iteration: { _iterations}\t\t\tBalance: ${_Score}\t");
                return false;
            }
        }
        private void AskPayDebt()
        {
            string userInput ="";
            int payOff = -1;
            if (_hasDebt)
            {
                do
                {
                    Console.WriteLine($"Would you like to put some money towards your debt of ${_loan} (yes/no)");
                    userInput = Console.ReadLine();
                } while (userInput.ToLower() != "yes" && userInput.ToLower() != "no");

                if (userInput.ToLower() == "yes")
                {
                    do
                    {
                        Console.Write("how much would you like to pay off?\n(enter amount, or enter '0' to not choose not to pay now)\n$");
                        payOff = int.Parse(Console.ReadLine());

                    } while (payOff > _Score - _loan && payOff != 0);
                    if (payOff > 0)
                    {
                        _loan -= payOff;
                        _Score -= payOff;
                        if (_loan<=0)
                        {
                           
                            _hasDebt = false;
                            Console.WriteLine($"you paid off all your debt! You paid ${payOff}, your current balance is now at ${_Score}");

                        }
                        else
                        {
                            Console.WriteLine($"you paid off ${payOff} your current balance is at ${_Score}\t\tyour loan is at {_loan}, with {_loanPayOff} rounds left to pay it off");
                        }
                        
                    }
                }
            }
           
            
        }
        private bool isKeepPlaynig()
        {
            if(_hasDebt)
            {
                if(_loan > 0 && _Score <= 0)
                {
                    return false;
                }
                else if (_loanPayOff < 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {

                return true;
            }
            
        }
        public void PickNums()
        {
            int ah = 0;
            do
            {
                Console.Clear();
                if (AskHasDebt())
                {
                    AskPayDebt();
                }
                string userConfirmation = "";
                do
                {
                    int optNum = 0;
                    Console.WriteLine($"Type a number for an option:");
                    foreach (var opt in Enum.GetValues(typeof(Options)))
                    {
                        Console.Write($"{optNum}: ");
                        Console.WriteLine(opt);
                        optNum++;
                    }
                    try
                    {
                        ah = int.Parse(Console.ReadLine());
                        Options selectedOpt = (Options)ah;
                        Console.WriteLine($"You have selected {selectedOpt}, type 'no' to pick another, or anything else to continue");
                        userConfirmation = Console.ReadLine();
                        Console.Clear();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        PickNums();
                    }
                } while (userConfirmation.ToLower().Trim() == "no");
                FindWinningPicks(ah);
            } while (isKeepPlaynig());
            Console.WriteLine("You lost all your money, and have no way of paying it back, Sorry");
        }
        private void FindWinningPicks(int selectOpt)
        {
            switch (selectOpt)
            {
                case 0:
                    Numbers();

                    break;
                case 1:
                    EvenOdds();

                    break;
                case 2:
                    RedsBlacks();

                    break;
                case 3:
                    LowsHighs();

                    break;
                case 4:
                    Dozens();

                    break;
                case 5:
                    Columns();

                    break;
                case 6:
                    Street();

                    break;
                case 7:
                    SixNums();

                    break;
                case 8:
                    Split();

                    break;
                case 9:
                    Corner();
                    break;

                default:
                    Numbers();
                    break;
            }
        }
        private void Rolling()
        {
            Console.Write("Ball is Rolling");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(400);
                Console.Write(" . ");

            }
            Console.WriteLine();
        }
        private void Numbers()
        {

            if (askBet(35))
            {
                Console.Write("What number would you like to pick?:\t");
                _userGuess = Console.ReadLine();
                _ranInd = indexer.Next(0, 37);
                Rolling();
                if (int.Parse(_userGuess) == _RouletteNums[_ranInd])
                {
                    Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]} matches your guess of {_userGuess}!\n ");
                    _Score += 10;
                    WinningsCalc(true);
                }
                else
                {
                    Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which does not match your guess of {_userGuess}!");
                    WinningsCalc(false);
                }
            }
            else
            {
                Numbers();
            }

        }
        private void EvenOdds()
        {
            if (askBet(1))
            {
                Console.WriteLine("Evens or Odds?");
                _userGuess = Console.ReadLine();
                _ranInd = indexer.Next(0, 37);
                Rolling();
                if (_userGuess.ToLower().Trim() == "evens" || _userGuess.ToLower().Trim() == "even")
                {
                    if (_RouletteNums[_ranInd] % 2 == 0)
                    {
                        Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]} which is even!\n ");
                        WinningsCalc(true);
                    }
                    else
                    {
                        Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not even!");
                        WinningsCalc(false);

                    }
                }
                else if (_userGuess.ToLower().Trim() == "odd" || _userGuess.ToLower().Trim() == "odds")
                {
                    if (_RouletteNums[_ranInd] % 2 == 1)
                    {
                        Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]} which is odd!\n ");
                        _Score += 10;
                        WinningsCalc(true);
                    }
                    else
                    {
                        Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not odd!");
                        WinningsCalc(false);

                    }
                }
                else
                {
                    Console.WriteLine("Please enter either 'Evens' or 'Odds'");
                    EvenOdds();
                }

            }
            else
            {
                EvenOdds();
            }

        }
        private void RedsBlacks()
        {
            if (askBet(1))
            {
                Console.WriteLine("Reds or Blacks?");
                _userGuess = Console.ReadLine();
                _ranInd = indexer.Next(0, 37);
                Rolling();

                if (_userGuess.ToLower().Trim() == "red" || _userGuess.ToLower().Trim() == "reds")
                {
                    if (_RouletteColors[_ranInd].ToLower().Trim() == "red")
                    {
                        Console.WriteLine($"Congratulations! The ball landed on: {_RouletteColors[_ranInd]}/{_RouletteNums[_ranInd]}!\n ");
                        WinningsCalc(true);
                    }
                    else
                    {
                        Console.WriteLine($"Sorry! the ball landed on: {_RouletteColors[_ranInd]}/{_RouletteNums[_ranInd]}!");
                        WinningsCalc(false);

                    }
                }
                else if (_userGuess.ToLower().Trim() == "black" || _userGuess.ToLower().Trim() == "blacks")
                {
                    if (_RouletteColors[_ranInd].ToLower().Trim() == "black")
                    {
                        Console.WriteLine($"Congratulations! The ball landed on: {_RouletteColors[_ranInd]}/{_RouletteNums[_ranInd]}\n ");
                        WinningsCalc(true);
                    }
                    else
                    {
                        Console.WriteLine($"Sorry! the ball landed on: {_RouletteColors[_ranInd]}/{_RouletteNums[_ranInd]}");
                        WinningsCalc(false);

                    }
                }
                else
                {
                    Console.WriteLine("Please enter either 'black' or 'red'");
                    RedsBlacks();
                }
            }
            else
            {
                RedsBlacks();
            }

        }
        private void LowsHighs()
        {
            if (askBet(1))
            {
                Console.WriteLine("Lows or Highs?");
                _userGuess = Console.ReadLine();
                _ranInd = indexer.Next(0, 37);
                Rolling();

                if (_userGuess.ToLower().Trim() == "low" || _userGuess.ToLower().Trim() == "lows")
                {
                    if (_RouletteNums[_ranInd] <= 18 && _RouletteNums[_ranInd] != 0 && _RouletteNums[_ranInd] != 100)
                    {
                        Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is low!\n ");
                        WinningsCalc(true);
                    }
                    else
                    {
                        Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not low!");
                        WinningsCalc(false);
                    }
                }
                else if (_userGuess.ToLower().Trim() == "high" || _userGuess.ToLower().Trim() == "highs")
                {
                    if (_RouletteNums[_ranInd] >= 19 && _RouletteNums[_ranInd] != 0 && _RouletteNums[_ranInd] != 100)
                    {
                        Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]} which is high!\n ");
                        WinningsCalc(true);
                    }
                    else
                    {
                        Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not high!");
                        WinningsCalc(false);
                    }
                }
                else
                {
                    Console.WriteLine("Please enter either 'high' or 'low'");
                    LowsHighs();
                }
            }
            else
            {
                LowsHighs();
            }

        }
        private void Dozens()
        {
            if (askBet(2))
            {
                Console.WriteLine("enter the number to the corresponding dozen:\n1: 1-12\n2: 13-24\n3: 25-36");
                _userGuess = Console.ReadLine();
                _ranInd = indexer.Next(0, 37);
                Rolling();

                if (_userGuess.ToLower().Trim() == "1" || _userGuess.ToLower().Trim() == "1")
                {
                    if (_RouletteNums[_ranInd] >= 1 && _RouletteNums[_ranInd] <= 12)
                    {
                        Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is between 1 and 12!\n ");
                        WinningsCalc(true);
                    }
                    else
                    {
                        Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not between 1 and 12!");
                        WinningsCalc(false);
                    }
                }
                else if (_userGuess.ToLower().Trim() == "2" || _userGuess.ToLower().Trim() == "2")
                {
                    if (_RouletteNums[_ranInd] >= 13 && _RouletteNums[_ranInd] <= 24)
                    {
                        Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]} which is between 13 and 24!\n ");
                        WinningsCalc(true);
                    }
                    else
                    {
                        Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not between 13 and 24!");
                        WinningsCalc(false);
                    }
                }
                else if (_userGuess.ToLower().Trim() == "3" || _userGuess.ToLower().Trim() == "3")
                {
                    if (_RouletteNums[_ranInd] >= 25 && _RouletteNums[_ranInd] <= 36)
                    {
                        Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]} which is between 25 and 36!\n ");
                        WinningsCalc(true);
                    }
                    else
                    {
                        Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not between 25 and 36!");
                        WinningsCalc(false);
                    }
                }
                else
                {
                    Console.WriteLine("Please enter either a  '1', '2', or '3'");
                    Dozens();
                }
            }
            else
            {
                Dozens();
            }

        }
        private void Columns()
        {
            if (askBet(2))
            {
                Console.WriteLine("enter the number to the corresponding column:\n1: 1,4,7,10,13,16,19,22,25,28,31,34" +
                                                                           "\n2: 2,5,8,11,14,17,20,23,26,29,32,35" +
                                                                           "\n3: 3,6,9,12,15,18,21,24,27,30,33,36");
                _userGuess = Console.ReadLine();
                _ranInd = indexer.Next(0, 37);
                Rolling();

                if (_userGuess == "1")
                {
                    switch (_RouletteNums[_ranInd])
                    {
                        case 1:
                        case 4:
                        case 7:
                        case 10:
                        case 13:
                        case 16:
                        case 19:
                        case 22:
                        case 25:
                        case 28:
                        case 31:
                        case 34:
                            Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 1!\n ");
                            WinningsCalc(true);
                            break;
                        default:
                            Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 1!");
                            WinningsCalc(false);
                            break;
                    }
                }
                else if (_userGuess == "2")
                {
                    switch (_RouletteNums[_ranInd])
                    {
                        case 2:
                        case 5:
                        case 8:
                        case 11:
                        case 14:
                        case 17:
                        case 20:
                        case 23:
                        case 26:
                        case 29:
                        case 32:
                        case 35:
                            Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 2!\n ");
                            WinningsCalc(true);
                            break;
                        default:
                            Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 2!");
                            WinningsCalc(false);

                            break;
                    }
                }
                else if (_userGuess == "3")
                {
                    switch (_RouletteNums[_ranInd])
                    {
                        case 3:
                        case 6:
                        case 9:
                        case 12:
                        case 15:
                        case 18:
                        case 21:
                        case 24:
                        case 27:
                        case 30:
                        case 33:
                        case 36:
                            Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 3!\n ");
                            WinningsCalc(true);

                            break;
                        default:
                            Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 3!");
                            WinningsCalc(false);

                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter either a  '1', '2', or '3'");
                    Columns();
                }
            }
            else
            {
                Columns();

            }


        }
        private void Street()
        {
            if (askBet(11))
            {
                Console.WriteLine("enter the number to the corresponding row:\n1: 1,2,3" +
               "\n2: 4,5,6" +
               "\n3: 7,8,9" +
               "\n4: 10,11,12" +
               "\n5: 13,14,15" +
               "\n6: 16,17,18" +
               "\n7: 19,20,21" +
               "\n8: 22,23,24" +
               "\n9: 25,26,27" +
               "\n10: 28,29,30" +
               "\n11: 31,32,33" +
               "\n12: 34,35,36");

                _userGuess = Console.ReadLine();
                _ranInd = indexer.Next(0, 37);
                Rolling();

                if (_userGuess.ToLower().Trim() == "1")
                {
                    switch (_RouletteNums[_ranInd])
                    {
                        case 1:
                        case 2:
                        case 3:
                            Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 1!\n ");
                            WinningsCalc(true);

                            break;
                        default:
                            Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 1!");
                            WinningsCalc(false);
                            break;
                    }
                }
                else if (_userGuess.ToLower().Trim() == "2")
                {
                    switch (_RouletteNums[_ranInd])
                    {
                        case 4:
                        case 5:
                        case 6:
                            Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 2!\n ");
                            WinningsCalc(true);

                            break;
                        default:
                            Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 2!");
                            WinningsCalc(false);

                            break;
                    }
                }
                else if (_userGuess.ToLower().Trim() == "3")
                {
                    switch (_RouletteNums[_ranInd])
                    {
                        case 7:
                        case 8:
                        case 9:
                            Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 3!\n ");
                            WinningsCalc(true);

                            break;
                        default:
                            Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 3!");
                            WinningsCalc(false);

                            break;
                    }
                }
                else if (_userGuess.ToLower().Trim() == "4")
                {
                    switch (_RouletteNums[_ranInd])
                    {
                        case 10:
                        case 11:
                        case 12:
                            Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 4!\n ");
                            WinningsCalc(true);

                            break;
                        default:
                            Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 4!");
                            WinningsCalc(false);

                            break;
                    }
                }
                else if (_userGuess.ToLower().Trim() == "5")
                {
                    switch (_RouletteNums[_ranInd])
                    {
                        case 13:
                        case 14:
                        case 15:
                            Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 5!\n ");
                            WinningsCalc(true);

                            break;
                        default:
                            Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 5!");
                            WinningsCalc(false);

                            break;
                    }
                }
                else if (_userGuess.ToLower().Trim() == "6")
                {
                    switch (_RouletteNums[_ranInd])
                    {
                        case 16:
                        case 17:
                        case 18:
                            Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 6!\n ");
                            WinningsCalc(true);

                            break;
                        default:
                            Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 6!");
                            WinningsCalc(false);

                            break;
                    }
                }
                else if (_userGuess.ToLower().Trim() == "7")
                {
                    switch (_RouletteNums[_ranInd])
                    {
                        case 19:
                        case 20:
                        case 21:
                            Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 7!\n ");
                            WinningsCalc(true);

                            break;
                        default:
                            Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 7!");
                            WinningsCalc(false);

                            break;
                    }
                }
                else if (_userGuess.ToLower().Trim() == "8")
                {
                    switch (_RouletteNums[_ranInd])
                    {
                        case 22:
                        case 23:
                        case 24:
                            Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 8!\n ");
                            WinningsCalc(true);

                            break;
                        default:
                            Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 8!");
                            WinningsCalc(false);

                            break;
                    }
                }
                else if (_userGuess.ToLower().Trim() == "9")
                {
                    switch (_RouletteNums[_ranInd])
                    {
                        case 25:
                        case 26:
                        case 27:
                            Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 9!\n ");
                            WinningsCalc(true);

                            break;
                        default:
                            Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 9!");
                            WinningsCalc(false);

                            break;
                    }
                }
                else if (_userGuess.ToLower().Trim() == "10")
                {
                    switch (_RouletteNums[_ranInd])
                    {
                        case 28:
                        case 29:
                        case 30:
                            Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 10!\n ");
                            WinningsCalc(true);

                            break;
                        default:
                            Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 10!");
                            WinningsCalc(false);

                            break;
                    }
                }
                else if (_userGuess.ToLower().Trim() == "11")
                {
                    switch (_RouletteNums[_ranInd])
                    {
                        case 31:
                        case 32:
                        case 33:
                            Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 11!\n ");
                            WinningsCalc(true);

                            break;
                        default:
                            Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 11!");
                            WinningsCalc(false);

                            break;
                    }
                }
                else if (_userGuess.ToLower().Trim() == "12")
                {
                    switch (_RouletteNums[_ranInd])
                    {
                        case 34:
                        case 35:
                        case 36:
                            Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 12!\n ");
                            WinningsCalc(true);

                            break;
                        default:
                            Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 12!");
                            WinningsCalc(false);

                            break;
                    }
                }

                else
                {
                    Console.WriteLine("Please enter a valid row");
                    Street();
                }
            }
            else
            {
                Street();
            }

        }

        private void SixNums()
        {
            if (askBet(5))
            {

            }
            else
            {
                SixNums();
            }

            Console.WriteLine("enter the number to the corresponding row:\n1: 1,2,3,4,5,6" +
                "\n2: 4,5,6,7,8,9" +
                "\n3: 7,8,9,10,11,12" +
                "\n4: 10,11,12,13,14,15" +
                "\n5: 13,14,15,16,17,18" +
                "\n6: 16,17,18,19,20,21" +
                "\n7: 19,20,21,22,23,24" +
                "\n8: 22,23,24,25,26,27" +
                "\n9: 25,26,2728,29,30" +
                "\n10: 28,29,30,31,32,33" +
                "\n11: 31,32,33,34,35,36" +
                "\n12: 34,35,36,1,2,3");

            _userGuess = Console.ReadLine();
            _ranInd = indexer.Next(0, 37);
            Rolling();

            if (_userGuess.ToLower().Trim() == "1")
            {
                switch (_RouletteNums[_ranInd])
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                        Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 1!\n ");
                        WinningsCalc(true);
                        break;
                    default:
                        Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 1!");
                        WinningsCalc(false);
                        break;
                }
            }
            else if (_userGuess.ToLower().Trim() == "2")
            {
                switch (_RouletteNums[_ranInd])
                {
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                        Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 2!\n ");
                        WinningsCalc(true);

                        break;
                    default:
                        Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 2!");
                        WinningsCalc(false);
                        break;
                }
            }
            else if (_userGuess.ToLower().Trim() == "3")
            {
                switch (_RouletteNums[_ranInd])
                {
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                        Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 3!\n ");
                        WinningsCalc(true);

                        break;
                    default:
                        Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 3!");
                        WinningsCalc(false);
                        break;
                }
            }
            else if (_userGuess.ToLower().Trim() == "4")
            {
                switch (_RouletteNums[_ranInd])
                {
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                        Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 4!\n ");
                        WinningsCalc(true);

                        break;
                    default:
                        Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 4!");
                        WinningsCalc(false);
                        break;
                }
            }
            else if (_userGuess.ToLower().Trim() == "5")
            {
                switch (_RouletteNums[_ranInd])
                {
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                        Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 5!\n ");
                        WinningsCalc(true);

                        break;
                    default:
                        Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 5!");
                        WinningsCalc(false);
                        break;
                }
            }
            else if (_userGuess.ToLower().Trim() == "6")
            {
                switch (_RouletteNums[_ranInd])
                {
                    case 16:
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                    case 21:
                        Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 6!\n ");
                        WinningsCalc(true);

                        break;
                    default:
                        Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 6!");
                        WinningsCalc(false);
                        break;
                }
            }
            else if (_userGuess.ToLower().Trim() == "7")
            {
                switch (_RouletteNums[_ranInd])
                {
                    case 19:
                    case 20:
                    case 21:
                    case 22:
                    case 23:
                    case 24:
                        Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 7!\n ");
                        WinningsCalc(true);

                        break;
                    default:
                        Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 7!");
                        WinningsCalc(false);
                        break;
                }
            }
            else if (_userGuess.ToLower().Trim() == "8")
            {
                switch (_RouletteNums[_ranInd])
                {
                    case 22:
                    case 23:
                    case 24:
                    case 25:
                    case 26:
                    case 27:
                        Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 8!\n ");
                        WinningsCalc(true);

                        break;
                    default:
                        Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 8!");
                        WinningsCalc(false);
                        break;
                }
            }
            else if (_userGuess.ToLower().Trim() == "9")
            {
                switch (_RouletteNums[_ranInd])
                {
                    case 25:
                    case 26:
                    case 27:
                    case 28:
                    case 29:
                    case 30:
                        Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 9!\n ");
                        WinningsCalc(true);

                        break;
                    default:
                        Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 9!");
                        WinningsCalc(false);

                        break;
                }
            }
            else if (_userGuess.ToLower().Trim() == "10")
            {
                switch (_RouletteNums[_ranInd])
                {
                    case 28:
                    case 29:
                    case 30:
                    case 31:
                    case 32:
                    case 33:
                        Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 10!\n ");
                        WinningsCalc(true);

                        break;
                    default:
                        Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 10!");
                        WinningsCalc(false);

                        break;
                }
            }
            else if (_userGuess.ToLower().Trim() == "11")
            {
                switch (_RouletteNums[_ranInd])
                {
                    case 31:
                    case 32:
                    case 33:
                    case 34:
                    case 35:
                    case 36:
                        Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 11!\n ");
                        WinningsCalc(true);

                        break;
                    default:
                        Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 11!");
                        WinningsCalc(false);

                        break;
                }
            }
            else if (_userGuess.ToLower().Trim() == "12")
            {
                switch (_RouletteNums[_ranInd])
                {
                    case 34:
                    case 35:
                    case 36:
                    case 1:
                    case 2:
                    case 3:
                        Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which is in column 12!\n ");
                        WinningsCalc(true);

                        break;
                    default:
                        Console.WriteLine($"Sorry! the ball landed on: {_RouletteNums[_ranInd]}, which is not in column 12!");
                        WinningsCalc(false);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid row");
                SixNums();
            }
        }
        private void Split()
        {
            if (askBet(17))
            {
                int count = 0;

                Console.WriteLine("What is the first number you would like to pick?");
                _userGuess = Console.ReadLine();
                Console.WriteLine("type the corresponding number from this index:");
                int[] posibleNums = returnSplit(int.Parse(_userGuess)).ToArray();
                foreach (var item in posibleNums)
                {
                    Console.WriteLine($"{count++}: {item}");
                }
                int indexOfSecondNum = int.Parse(Console.ReadLine());
                int secondNum = posibleNums[indexOfSecondNum];
                Console.WriteLine($"You chose numbers: {_userGuess} & {secondNum}");
                _ranInd = indexer.Next(0, 37);
                Rolling();

                if (_RouletteNums[_ranInd] == int.Parse(_userGuess) || _RouletteNums[_ranInd] == secondNum)
                {
                    Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which matches your split of: {_userGuess} & {secondNum}!\n ");
                    WinningsCalc(true);

                }
                else
                {
                    Console.WriteLine($"Sorry! The ball landed on: {_RouletteNums[_ranInd]}, which does not match your split of: {_userGuess} & {secondNum}!\n");

                    WinningsCalc(false);

                }
            }
            else
            {
                Split();
            }

        }
        private void Corner()
        {
            if (askBet(8))
            {
                int count = 1;

                Console.WriteLine("What is the corner number you would like to pick?");
                _userGuess = Console.ReadLine();
                Console.WriteLine("type the corresponding number group from this index:");
                int[] posibleNums = returnCorner(int.Parse(_userGuess)).ToArray();

                int index = 0;
                for (; count <= posibleNums.Length / 3; count++)
                {
                    int i = 0;
                    Console.Write($"{count}:  {_userGuess} |");
                    for (; i < 3; i++)
                    {
                        Console.Write($" {posibleNums[index++]} |");
                    }
                    Console.WriteLine();
                }
                int chosenCornerSet = int.Parse(Console.ReadLine());
                _ranInd = indexer.Next(0, 37);
                Rolling();

                if (chosenCornerSet == 1)
                {
                    if (_RouletteNums[_ranInd] == int.Parse(_userGuess) || _RouletteNums[_ranInd] == posibleNums[0] || _RouletteNums[_ranInd] == posibleNums[1] || _RouletteNums[_ranInd] == posibleNums[2])
                    {
                        Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which matches your corner of: {_userGuess},{posibleNums[0]},{posibleNums[1]},{posibleNums[2]}!\n ");
                        WinningsCalc(true);

                    }
                    else
                    {
                        Console.WriteLine($"Sorry! The ball landed on: {_RouletteNums[_ranInd]}, which does not match your corner of: {_userGuess},{posibleNums[0]},{posibleNums[1]},{posibleNums[2]}!\n");

                        WinningsCalc(false);
                    }
                }
                else if (chosenCornerSet == 2 && count >= chosenCornerSet)
                {
                    if (_RouletteNums[_ranInd] == int.Parse(_userGuess) || _RouletteNums[_ranInd] == posibleNums[3] || _RouletteNums[_ranInd] == posibleNums[4] || _RouletteNums[_ranInd] == posibleNums[5])
                    {
                        Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which matches your corner of: {_RouletteNums[_ranInd]}, which matches your split of: {_userGuess},{posibleNums[3]},{posibleNums[4]},{posibleNums[5]}!\n ");
                        WinningsCalc(true);
                    }
                    else
                    {
                        Console.WriteLine($"Sorry! The ball landed on: {_RouletteNums[_ranInd]}, which does not match your corner of: {_userGuess},{posibleNums[3]},{posibleNums[4]},{posibleNums[5]}!\n");

                        WinningsCalc(false);
                    }
                }
                else if (chosenCornerSet == 3 && count >= chosenCornerSet)
                {
                    if (_RouletteNums[_ranInd] == int.Parse(_userGuess) || _RouletteNums[_ranInd] == posibleNums[6] || _RouletteNums[_ranInd] == posibleNums[7] || _RouletteNums[_ranInd] == posibleNums[8])
                    {
                        Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which matches your corner of: {_RouletteNums[_ranInd]}, which matches your split of: {_userGuess},{posibleNums[6]},{posibleNums[7]},{posibleNums[8]}!\n ");
                        WinningsCalc(true);
                    }
                    else
                    {
                        Console.WriteLine($"Sorry! The ball landed on: {_RouletteNums[_ranInd]}, which does not match your corner of: {_userGuess},{posibleNums[6]},{posibleNums[7]},{posibleNums[8]}!\n");

                        WinningsCalc(false);
                    }
                }
                else if (chosenCornerSet == 4 && count >= chosenCornerSet)
                {
                    if (_RouletteNums[_ranInd] == int.Parse(_userGuess) || _RouletteNums[_ranInd] == posibleNums[9] || _RouletteNums[_ranInd] == posibleNums[10] || _RouletteNums[_ranInd] == posibleNums[11])
                    {
                        Console.WriteLine($"Congratulations! The ball landed on: {_RouletteNums[_ranInd]}, which matches your corner of: {_RouletteNums[_ranInd]}, which matches your split of: {_userGuess},{posibleNums[9]},{posibleNums[10]},{posibleNums[11]}!\n ");
                        WinningsCalc(true);
                    }
                    else
                    {
                        Console.WriteLine($"Sorry! The ball landed on: {_RouletteNums[_ranInd]}, which does not match your corner of: {_userGuess},{posibleNums[9]},{posibleNums[10]},{posibleNums[11]}!\n");

                        WinningsCalc(false);
                    }
                }
                else
                {
                    Console.WriteLine("Please enter correct option");
                    Corner();
                }

            }
            else
            {
                Corner();
            }



        }
    }

}
