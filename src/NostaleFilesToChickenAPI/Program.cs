using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace NostaleFilesToChickenAPI
{
    class Program
    {
        static void Main()
        {
            string path = "c:\\Item.dat";

            if (!File.Exists(path))
            {
                Console.WriteLine("Item.dat path is not well!");
            }
            Console.Write("\n");
            ItemParser.Parser Parser = new ItemParser.Parser();
            string[] blocks = Parser.getBlocks(path);
            Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();
            foreach (string block in blocks)
            {
                dictionary = Parser.getValues(block);
                if (dictionary.ContainsKey("VNUM"))
                {
                    string[] test = dictionary["VNUM"];
                    Console.Write("VNUM: " + String.Join("  ", dictionary["VNUM"]) + "\n");
                }
                else
                {
                    Console.Write("All VNUMS parsed");
                }
            }

            Console.WriteLine("Item.dat loaded");
        }
    }
}
