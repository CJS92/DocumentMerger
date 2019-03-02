// Project for IT 2040
// Written by Cody Sloan
// 03/01/2019

using System;
using System.IO;

namespace DocumentMerger
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // initialize the program
            void check()
            {
            Console.WriteLine("\nDocument Merger");
            Console.WriteLine("------------------");
            Console.ReadLine();

            // gather user input
            Console.WriteLine("Enter first file name: ");
            string firstFile = Console.ReadLine();
            Console.WriteLine("Enter second file name: ");
            string secondFile = Console.ReadLine();
               
            // add .txt extension if one isn't given
            if (string.IsNullOrEmpty(Path.GetExtension(firstFile)))
            {
                firstFile += ".txt";
            }
            if (string.IsNullOrEmpty(Path.GetExtension(secondFile)))
                {
                    secondFile += ".txt";
                }
            else
                {
                    // continue execution
                }

            bool check1 = true;

                do
                {
                    if (check1)
                    {
                        check1 = false;
                    }
                    else
                    {
                        Console.WriteLine("Error: Could not locate the file. Was it a typo?");
                    }
                } while (firstFile.Length == 0 || !File.Exists(firstFile));
                check1 = true;
                do
                {
                    if (check1)
                    {
                        check1 = false;
                    }
                    else
                    {
                        Console.WriteLine("Could not locate this file. Was it a typo?");
                    }
                } while (secondFile.Length == 0 || !File.Exists(secondFile));

                String mergedFile = firstFile.Substring(0, firstFile.Length - 4) + secondFile;

                // open the file
                StreamWriter writer = null;
                StreamReader reader = null;
                StreamReader reader2 = null;

                // add .txt extension if one isn't given
                if (string.IsNullOrEmpty(Path.GetExtension(firstFile)))
            {
                firstFile += ".txt";
            }
            else if (string.IsNullOrEmpty(Path.GetExtension(secondFile)))
            {
                secondFile += ".txt";
            }
            else
            {
                // continue execution
            }

            int count = 0;

            try
            {
              writer = new StreamWriter(mergedFile);
              reader = new StreamReader(firstFile);
              reader2 = new StreamReader(secondFile);

            string line = null;
             while ((line = reader.ReadLine()) != null)
                    {

                        count += line.Length;
                        writer.WriteLine(line);
                    }

                    while ((line = reader2.ReadLine()) != null)
                    {

                        count += line.Length;
                        writer.WriteLine(line);
                    }
                }
            catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            finally
                {
                    if (writer != null)
                        writer.Close();
                    if (reader != null)
                        reader.Close();
                    if (reader2 != null)
                        reader2.Close();
                    Console.WriteLine(mergedFile + " was successfully saved. The document contains " + count + " characters.");
                }
            }

            do
            {
                check();
                Console.Write("\nWould you like to start over? (y/n): ");
            } while (Console.ReadLine().ToLower().Equals("y"));

            // exit the program
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}