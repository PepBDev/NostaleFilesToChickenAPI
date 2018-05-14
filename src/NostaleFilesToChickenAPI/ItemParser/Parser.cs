using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace NostaleFilesToChickenAPI.ItemParser
{
    class Parser
    {
        public string[] getBlocks(string path)
        {
            string allText = File.ReadAllText(path);
            string[] blocks = allText.Split(new string[] { "#========================================================" }, StringSplitOptions.None);
            return blocks;
        }
        public Dictionary<string, string[]> getValues(string block)
        {
            Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();
            string[] fields = Regex.Split(block, "\t");
            var foos = new List<string>(fields);
            foos.RemoveAt(0);
            string text = String.Join("\t", foos.ToArray());
            string[] values = Regex.Split(text, "\r");
            values = values.Take(values.Count() - 1).ToArray();
            foreach (string value in values)
            {
                string[] fieldName = Regex.Split(value, "\t");
                fieldName = fieldName.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                var newList = new List<string>(fieldName);
                if(newList.Count >= 1)
                {
                    newList.RemoveAt(0);
                    string[] valueList = newList.ToArray();
                    dictionary.Add(fieldName[0], valueList);
                }
                else
                {
                }

            }
            return dictionary;
        }
        
    }
}
