using System;
using System.IO;

namespace Practice8.SentenceDiff
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter the name of the inital input file: ");
                Text initialText = new Text(File.ReadAllText(Console.ReadLine()));

                Console.Write("Enter the name of the transformed input file: ");
                Text transformedText = new Text(File.ReadAllText(Console.ReadLine()));

                Diff difference = transformedText.DifferenceComparedTo(initialText);
                
                Console.Write("Enter the name of the output file: ");
                File.WriteAllText(Console.ReadLine(), difference.ToString());
                
                Console.WriteLine($"Difference has been successfully written");
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to execute: " + e.Message);
            }
        }
    }
}
