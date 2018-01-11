using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoMamaNeuralNetwork {
    class Program {
        
        static void Main(string[] args) {
            for (int z = 1; z > 0; z++) // INFINITE LOOP
            {
                Console.WriteLine("--CURRENTLY TRAINING--");
                Console.WriteLine("ITERATIONS: " + z);

                Random Random_Number = new Random();
                int Total_Lines = File.ReadAllLines("C:/Users/mrchargerlover/Documents/Programming Archive/Visual Studio C#/YoMamaNeuralNetwork/YMNN Training Data.txt").Length;
                StreamReader Joke_List = new StreamReader("C:/Users/mrchargerlover/Documents/Programming Archive/Visual Studio C#/YoMamaNeuralNetwork/YMNN Training Data.txt");
                String Sample_Joke = null;
                int Random_Line = Random_Number.Next(1, Total_Lines + 1);
                for (int i = 1; i <= Random_Line; i++) //Grabbing random line
                { 
                    Sample_Joke = Joke_List.ReadLine().ToString();
                }
                Joke_List.Close();
                Console.Write(Sample_Joke);

                double[] Initial_Nodes = new double[280 + 1]; //Sample_Joke.Length + 1
                for (int i = 1; i < 280; i++) //Storing number into array
                {
                    if (Sample_Joke == null) {
                    }
                    else if (Sample_Joke.Length < i)
                    {
                        Initial_Nodes[i] = 0;
                    }
                    else
                    {
                        Initial_Nodes[i] = Convert_Letters(Sample_Joke[i - 1].ToString());
                    }
                }

                for (int i = 1; i <= 280; i++) // 1st Weights
                { 
                    string FilePath = "C:/Users/mrchargerlover/Documents/Programming Archive/Visual Studio C#/YoMamaNeuralNetwork/YMNN Weights/Weights for sum #" + i;
                    if (File.Exists(FilePath) == false) //If .txt does not exist create random weights
                    {
                        FileStream Weights = File.Create(FilePath);
                        Weights.Close();
                        StreamWriter Weights_Write = new StreamWriter(FilePath);
                        for (int a = 1; a <= 280; a++)
                        {
                            Byte[] Random_Weight = new UTF8Encoding(true).GetBytes((Random_Number.Next(-1000, 1000) / 1000.0).ToString());
                            Weights_Write.WriteLine(System.Text.Encoding.UTF8.GetString(Random_Weight).ToCharArray(), 0, Random_Weight.Length);
                        }
                        Weights_Write.Close();
                    }
                }

                double[] Sum = new double[280 + 1];
                for (int i = 1; i <= 280; i++) // Creating (Sum #1 / Hidden Layer #1)
                {
                    string FilePath = "C:/Users/mrchargerlover/Documents/Programming Archive/Visual Studio C#/YoMamaNeuralNetwork/YMNN Weights/Weights for sum #" + i;
                    StreamReader Weights_Read = new StreamReader(FilePath);
                    for (int a = 1; a <= 280; a++) //This is really important (IT'S GUCCI?)
                    { 
                        Sum[i] += Initial_Nodes[a] * Convert.ToDouble(Weights_Read.ReadLine());
                    }
                    Weights_Read.Close();
                }

                String[] Final_Nodes = new String[280 + 1]; //Sample_Joke.Length + 1
                for (int i = 1; i <= 280; i++) //Converting double[] to string char[]
                { 
                    Final_Nodes[i] = Convert_Numbers(Sum[i]);
                }

                double Learning_Rate = 1f;
                for (int i = 1; i <= 280; i++) //Adjusting weights (THE LEARNING PART) (Sample_Joke.Length)
                { 
                    double Error = Initial_Nodes[i] - Convert_Letters(Final_Nodes[i]);
                    string FilePath = "C:/Users/mrchargerlover/Documents/Programming Archive/Visual Studio C#/YoMamaNeuralNetwork/YMNN Weights/Weights for sum #" + i;
                    double[] Initial_Weights = new double[280 + 1];
                    Initial_Weights = Get_Weights(FilePath);
                    StreamWriter Weights_Write = new StreamWriter(FilePath);
                    for (int a = 1; a <= 280; a++)
                    {
                        Byte[] New_Weight = new UTF8Encoding(true).GetBytes((Initial_Weights[a] + (Error * Initial_Nodes[a] * Learning_Rate)).ToString());
                        Weights_Write.WriteLine(System.Text.Encoding.UTF8.GetString(New_Weight).ToCharArray(), 0, New_Weight.Length);
                    }
                    Weights_Write.Close();
                }
                //Console.WriteLine("WEIGHTS ADJUSTED");
                //Console.ReadKey();
                Console.WriteLine("");
                Console.WriteLine(Final_Nodes[0]);
                Console.WriteLine("");
                Console.WriteLine(String.Join(" ", Final_Nodes));
                //Console.Clear();
            }
        }

        public static double Convert_Letters (string Character) { //Converting each character into number
            double Result = 0;

            if (Character == " ")
            {
                Result = 0;
            }
            else if (Character == "A" || Character == "a")
            {
                Result = 1;
            }
            else if (Character == "B" || Character == "b")
            {
                Result = 2;
            }
            else if (Character == "C" || Character == "c")
            {
                Result = 3;
            }
            else if (Character == "D" || Character == "d")
            {
                Result = 4;
            }
            else if (Character == "E" || Character == "e")
            {
                Result = 5;
            }
            else if (Character == "F" || Character == "f")
            {
                Result = 6;
            }
            else if (Character == "G" || Character == "g")
            {
                Result = 7;
            }
            else if (Character == "H" || Character == "h")
            {
                Result = 8;
            }
            else if (Character == "I" || Character == "i")
            {
                Result = 9;
            }
            else if (Character == "J" || Character == "j")
            {
                Result = 10;
            }
            else if (Character == "K" || Character == "k")
            {
                Result = 11;
            }
            else if (Character == "L" || Character == "l")
            {
                Result = 12;
            }
            else if (Character == "M" || Character == "m")
            {
                Result = 13;
            }
            else if (Character == "N" || Character == "n")
            {
                Result = 14;
            }
            else if (Character == "O" || Character == "o")
            {
                Result = 15;
            }
            else if (Character == "P" || Character == "p")
            {
                Result = 16;
            }
            else if (Character == "Q" || Character == "q")
            {
                Result = 17;
            }
            else if (Character == "R" || Character == "r")
            {
                Result = 18;
            }
            else if (Character == "S" || Character == "s")
            {
                Result = 19;
            }
            else if (Character == "T" || Character == "t")
            {
                Result = 20;
            }
            else if (Character == "U" || Character == "u")
            {
                Result = 21;
            }
            else if (Character == "V" || Character == "v")
            {
                Result = 22;
            }
            else if (Character == "W" || Character == "w")
            {
                Result = 23;
            }
            else if (Character == "X" || Character == "x")
            {
                Result = 24;
            }
            else if (Character == "Y" || Character == "y")
            {
                Result = 25;
            }
            else if (Character == "Z" || Character == "z")
            {
                Result = 26;
            }
            else if (Character == ".")
            {
                Result = 27;
            }
            else if (Character == "!")
            {
                Result = 28;
            }
            else if (Character == "?")
            {
                Result = 29;
            }
            else if (Character == "'")
            {
                Result = 30;
            }
            else if (Character == ",")
            {
                Result = 31;
            }
            else if (Character == "/")
            {
                Result = 32;
            }
            else if (Character == "-")
            {
                Result = 33;
            }
            else if (Character == "+")
            {
                Result = 34;
            }
            else if (Character == ",")
            {
                Result = 35;
            }
            else if (Character == "0")
            {
                Result = 36;
            }
            else if (Character == "1")
            {
                Result = 37;
            }
            else if (Character == "2")
            {
                Result = 38;
            }
            else if (Character == "3")
            {
                Result = 39;
            }
            else if (Character == "4")
            {
                Result = 40;
            }
            else if (Character == "5")
            {
                Result = 41;
            }
            else if (Character == "6")
            {
                Result = 42;
            }
            else if (Character == "7")
            {
                Result = 43;
            }
            else if (Character == "8")
            {
                Result = 44;
            }
            else if (Character == "9")
            {
                Result = 45;
            }
            else if (Character == "$")
            {
                Result = 46;
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("INVALID CHARACTER: '" + Character + "'");
                //Console.ReadKey();
            }
            Result = Result / 46.0;
            return Result;
        }

        public static string Convert_Numbers (double Number) {
            string Result = "";
            Number = 1.0 / (1 + Math.Pow(Math.E, -1 * Number)); //SIGMOID FUNCTION

            if (Number * 26.0 <= .5) {
                Result = " ";
            }else if (Number * 26.0 <= 1.5) {
                Result = "a";
            }else if (Number * 26.0 <= 2.5) {
                Result = "b";
            }else if (Number * 26.0 <= 3.5) {
                Result = "c";
            }else if (Number * 26.0 <= 4.5) {
                Result = "d";
            }else if (Number * 26.0 <= 5.5) {
                Result = "e";
            }else if (Number * 26.0 <= 6.5) {
                Result = "f";
            }else if (Number * 26.0 <= 7.5) {
                Result = "g";
            }else if (Number * 26.0 <= 8.5) {
                Result = "h";
            }else if (Number * 26.0 <= 9.5) {
                Result = "i";
            }else if (Number * 26.0 <= 10.5) {
                Result = "j";
            }else if (Number * 26.0 <= 11.5) {
                Result = "k";
            }else if (Number * 26.0 <= 12.5) {
                Result = "l";
            }else if (Number * 26.0 <= 13.5) {
                Result = "m";
            }else if (Number * 26.0 <= 14.5) {
                Result = "n";
            }else if (Number * 26.0 <= 15.5) {
                Result = "o";
            }else if (Number * 26.0 <= 16.5) {
                Result = "p";
            }else if (Number * 26.0 <= 17.5) {
                Result = "q";
            }else if (Number * 26.0 <= 18.5) {
                Result = "r";
            }else if (Number * 26.0 <= 19.5) {
                Result = "s";
            }else if (Number * 26.0 <= 20.5) {
                Result = "t";
            }else if (Number * 26.0 <= 21.5) {
                Result = "u";
            }else if (Number * 26.0 <= 22.5) {
                Result = "v";
            }else if (Number * 26.0 <= 23.5) {
                Result = "w";
            }else if (Number * 26.0 <= 24.5) {
                Result = "x";
            }else if (Number * 26.0 <= 25.5) {
                Result = "y";
            }
            else if (Number * 27.0 <= 26.5)
            {
                Result = ".";
            }
            else if (Number * 28.0 <= 27.5)
            {
                Result = "!";
            }
            else if (Number * 29.0 <= 28.5)
            {
                Result = "?";
            }
            else if (Number * 30.0 <= 29.5)
            {
                Result = "'";
            }
            else if (Number * 31.0 <= 30.5)
            {
                Result = ",";
            }
            else if (Number * 32.0 <= 31.5)
            {
                Result = "/";
            }
            else if (Number * 33.0 <= 32.5)
            {
                Result = "-";
            }
            else if (Number * 34.0 <= 33.5)
            {
                Result = "+";
            }
            else if (Number * 35.0 <= 34.5)
            {
                Result = ",";
            }
            else if (Number * 36.0 <= 35.5)
            {
                Result = "0";
            }
            else if (Number * 37.0 <= 36.5)
            {
                Result = "1";
            }
            else if (Number * 38.0 <= 37.5)
            {
                Result = "2";
            }
            else if (Number * 39.0 <= 38.5)
            {
                Result = "3";
            }
            else if (Number * 40.0 <= 39.5)
            {
                Result = "4";
            }
            else if (Number * 41.0 <= 40.5)
            {
                Result = "5";
            }
            else if (Number * 42.0 <= 41.5)
            {
                Result = "6";
            }
            else if (Number * 43.0 <= 42.5)
            {
                Result = "7";
            }
            else if (Number * 44.0 <= 43.5)
            {
                Result = "8";
            }
            else if (Number * 45.0 <= 44.5)
            {
                Result = "9";
            }
            else if (Number * 46.0 <= 45.5)
            {
                Result = "$";
            }
            else {
                Console.WriteLine("CRIT ERROR IN CONVERTING INT TO STRING");
                Result = "?";
            }
            
            return Result;
        }

        public static double[] Get_Weights (string FilePath) {
            double[] Result = new double[280 + 1];

            StreamReader Weights_Read = new StreamReader(FilePath);
            for (int i = 1; i <= 280; i++) {
                Result[i] = Convert.ToDouble(Weights_Read.ReadLine());
            }
            Weights_Read.Close();

            return Result;
        }
    }
}