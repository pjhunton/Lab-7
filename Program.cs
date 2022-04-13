using System;
using System.IO;


namespace Lab_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            string menuInput = "";
            while(menuInput != "4")
            {
                DisplayMenuOptions();
                menuInput = Console.ReadLine();
                Route(menuInput);
            } 
        }

        static void DisplayMenuOptions()
        {
            Console.WriteLine($"Enter a 1 to Encode");
            Console.WriteLine($"Enter a 2 to Decode");
            Console.WriteLine($"Enter a 3 to Word Count");
            Console.WriteLine($"Enter a 4 to Exit");
            
        }

        static void Route(string menuInput)
        {
            switch(menuInput)
            {
            case "1":
                GoForward();
                break;

            case "2":
                GoBackwards();
                break;

            case "3":
                WordCount();
                break;

            case "4":
                Console.WriteLine($"bye");
                break;

                default:
                Console.WriteLine($"Invalid");  
                break;
            }
        }

        static void Encode()
        {

            Console.WriteLine($"Please enter an input file");
            string inputFile = Console.ReadLine();

            Console.WriteLine($"Please enter a file to save to ");
            string outputFile = Console.ReadLine();

            EncodeIt(inputFile, outputFile);
        }

        static void GoForward()
        {
            Console.WriteLine($"welcome to out encode methode");
            Encode();
        }

        static void GoBackwards()
        {
            Console.WriteLine($"Welcome to our decode method");
            Encode();
            
        }

        static void EncodeIt(string inputFile, string outputFile)
        {
            StreamReader inFile = new StreamReader(inputFile);
            StreamWriter outFile = new StreamWriter(outputFile);

            string line = inFile.ReadLine();
            
            while(line != null)
            {
                outFile.WriteLine(TransformIt(line));

                line = inFile.ReadLine();
            }
            inFile.Close();
            outFile.Close();
        }

        static string TransformIt(string line)
        {
            string letteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string newLine = "";
            line = line.ToUpper();
            for(int i = 0; i < line.Length; i++)
            {
                int found = -1;
                for (int j = 0; j < letteres.Length; j++)
                {
                    if (line[i] == letteres[j])
                    {
                        found = j;
                    }
                }

                    if (found == -1)
                    {
                        newLine += line[i];
                    }
                    else{
                        newLine += letteres[(found + 13)%26];
                    }
                
            }
            return newLine;
        }


        static void WordCount()
        {
            Console.WriteLine($"WHats the name of the file"); 
            string fileName = Console.ReadLine();

            StreamReader inFile = new StreamReader(fileName);

            string line = inFile.ReadLine();
            int count = 0;
            while(line != null)
            {
                string[] temp = line.Split(" ");
                count += temp.Length;

                line = inFile.ReadLine();

            }
            Console.WriteLine($"File contains {count} words");

            inFile.Close();

            
        }

    }

}
