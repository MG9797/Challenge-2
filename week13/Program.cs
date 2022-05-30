using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace DiceRole
{
    class Program
    {
        static List<int> rolls = new List<int>();
        static void Main()
        {
            string filePath ="./rolls.txt";
            if (File.Exists(filePath))
            {
                string[] arr = File.ReadAllLines(filePath);
                foreach (String s in arr)
                {
                    rolls.Add(int.Parse(s));
                }
            }
        
            while (true)
            {
             int inputNum;
                while (true)
                {
                 Console.WriteLine("1. Roll Dice\n2. Calculate Key Values\n3. List Rolls\n4. Delete All Rolls\n5. Exit\nEnter the number for the action ou widh to take");
                 string input = Console.ReadLine().Trim();
                
                    if (char.IsDigit(input,0))
                    {
                        inputNum = (int)char.GetNumericValue(input[0]);
                        if(1<inputNum && inputNum<=5)
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("Incorrect Input");
                    //Checks if input data between 1 and 5 if not it loops again
                }
                switch (inputNum)
                {
                    case 1: Roll();
                    break;
                    case 2: calcKeyVal();
                    break;
                    case 3: listAllRolls();
                    break;
                    case 4: Console.Clear();
                    using(StreamWriter writer =new StreamWriter("./rolls.txt.false"))
                    {
                        writer.Write("");
                    }
                    break;
                    case 5: Environment.Exit(0);
                    break;
                }
            }
                        
        }
        static  void Roll()
        {
            int inputNum;
            Console.Clear();
            while (true)
            {
                Console.WriteLine("How any dices would you like to roll");
                string input= Console.ReadLine().Trim();
                if (int.TryParse(input, out inputNum))
                break;
                Console.Clear();
                Console.WriteLine("Incorrect Input please try again");
            }
            Console.Clear();
            Random rnd=new Random();
            List<int> tempRolls = new List<int>();
            Console.WriteLine(inputNum);
            for (int i = 0; i <inputNum; i++)
            {
                int roll =rnd.Next(1,6);
                rolls.Add(roll);
            }
            while (true)
            {
                using (StreamWriter writer= new StreamWriter("./rolls.txt", true))
                {
                    foreach (int roll in tempRolls)
                    {
                        Console.WriteLine(roll);
                        writer.WriteLine(roll);
                    }
                }
                Console.WriteLine("Would you like return (Y/N)");
                string yesNo= Console.ReadLine().Trim().ToUpper();
                if (yesNo[0]=='Y')
                {
                    Console.Clear();
                    break;
                }
            }
        } 
        static void calcKeyVal()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"The Rolls average was: {rolls.Average()}");
                Console.WriteLine($"Total was {rolls.Sum()}");
                Console.WriteLine("Would you like to go back? (Y/N)");
                string yesNo = Console.ReadLine().Trim().ToUpper();
                if (yesNo[0]== 'y')
                {
                    Console.Clear();
                    break;
                }
            }
        }
        static void listAllRolls()
        {
            while (true)
            {
                Console.Clear();
                foreach (int roll in rolls)
                {
                    Console.WriteLine(roll);
                }
                Console.WriteLine ("Would you like to go back? (Y/N)");
                string yesNo = Console.ReadLine().Trim().ToUpper();
                if (yesNo[0]== 'y')
                {
                    Console.Clear();
                    break;
                }
            }
        }    
    }
}
