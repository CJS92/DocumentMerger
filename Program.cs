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
            Console.WriteLine("Document Merger");
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
            else if (string.IsNullOrEmpty(Path.GetExtension(secondFile)))
            {
                secondFile += ".txt";
            }
            else
            {
                // continue execution
            }
            Console.WriteLine("\n------------------");
            Console.WriteLine("Enter file contents: ");
            string fileContents = Console.ReadLine();
            string file2Contents = Console.ReadLine();

            // open the file
            FileStream document;
            FileStream MergedFile;
            StreamWriter writer = null;
            StreamReader reader = null;
            TextWriter oldOut = Console.Out;
            try
            {
                document = new FileStream(firstFile, FileMode.OpenOrCreate, FileAccess.Write);
                document = new FileStream(secondFile, FileMode.OpenOrCreate, FileAccess.Write);
                MergedFile = new FileStream(firstFile, FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(document);
                // write to the file
                int characterCount = fileContents.Length;
                Console.SetOut(writer);
                Console.WriteLine("{0}", fileContents);
                Console.SetOut(oldOut);
                writer.Close();
                document.Close();
                Console.WriteLine("{0} was successfully saved. The document contains {1} characters.", MergedFile, characterCount);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: Unable to access the file.");
                Console.WriteLine(e.Message);
                return;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (writer != null)
                {
                    writer.Close();
                }

                // exit the program
                Console.WriteLine("Press Enter to exit...");
                Console.ReadLine();
            }
        }
    }
}