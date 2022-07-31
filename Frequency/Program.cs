// -------------------------------------------------------------------
// Darie-Dragos Mitoiu
// Frequency Console App v1.0.0 30/07/2022
// A Console App designed to count characters frequency in a text file
// -------------------------------------------------------------------

using System;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Frequency
{
    public class Program
    {
        public static void Main(String[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please provide a file path argument, e.g: Frequency.exe ./resources/sample.txt");
                return;
            }
            try
            {
                string filePath = args[0];
                ArrayList dictionaries = new ArrayList();
                ArrayList content = getFileContent(filePath);
                string separator = string.Concat(Enumerable.Repeat("-", 60));
                for (int x = 0; x < content.Count; x++)
                {
                    string item = (string)content[x];
                    string characters = getCharacters(item);
                    Dictionary<char, int> dictionary = new Dictionary<char, int>();
                    while (characters.Length > 0)
                    {
                        int count = 0;
                        for (int i = 0; i < characters.Length; i++)
                        {
                            if (characters[0] == characters[i])
                            {
                                count++;
                            }
                        }
                        if (!dictionary.ContainsKey(characters[0]))
                        {
                            dictionary.Add(characters[0], count);
                        }
                        else
                        {
                            dictionary[characters[0]] = count;
                        }
                        characters = characters.Replace(characters[0].ToString(), string.Empty);
                    }
                    dictionaries.Add(dictionary);
                }

                int lineCounter = 1;
                Console.WriteLine(separator);
                Console.WriteLine("Darie-Dragos Mitoiu - Frequency v1.0.0 30/07/2022");
                for (int z = 0; z < dictionaries.Count; z++)
                {
                    Console.WriteLine(separator);
                    Console.WriteLine("Line: " + lineCounter);
                    Console.WriteLine(separator);
                    Dictionary<char, int> finalDictionary = (Dictionary<char, int>)dictionaries[z];
                    foreach (var keyValuePair in finalDictionary.OrderByDescending(key => key.Value))
                    {
                        Console.WriteLine("Key: {0}, Value: ({1})", keyValuePair.Key, keyValuePair.Value);
                    }
                    lineCounter++;
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Opps, something went wrong, please check your file path.");
            }
        }

        public static ArrayList getFileContent(string filePath)
        {
            ArrayList result = new ArrayList();
            string[] lines = System.IO.File.ReadAllLines(filePath);
            for(int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (line.Length > 0)
                {
                    result.Add(line);
                }
            }
            return result;
        }

        public static string getCharacters(string sample)
        {
            string result = sample.Replace(" ", "")
                                  .Replace("/t", "")
                                  .Replace("/n", "")
                                  .Replace("/r", "")
                                  .Replace(",", "")
                                  .Replace(".", "");
            return result;
        }
    }
}

