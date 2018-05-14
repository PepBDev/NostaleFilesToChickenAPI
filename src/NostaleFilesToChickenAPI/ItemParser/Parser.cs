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
            string[] blocks = File.ReadAllText(path).Split(new string[] { "#========================================================" }, StringSplitOptions.None);
            return blocks;
        }

        public Dictionary<string, string[]> getValues(string block)
        {
            Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();
            var foos = new List<string>(Regex.Split(block, "\t"));
            foos.RemoveAt(0);
            string[] values = Regex.Split(String.Join("\t", foos.ToArray()), "\r");
            values = values.Take(values.Count() - 1).ToArray();
            foreach (string value in values)
            {
                if (value == "");
                string[] fieldName = Regex.Split(value, "\t");
                fieldName = fieldName.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                var newList = new List<string>(fieldName);
                if(newList.Count >= 1)
                {
                    newList.RemoveAt(0);
                    string[] valueList = newList.ToArray();
                    dictionary.Add(fieldName[0], valueList);
                }
            }
            return dictionary;
        }

        static bool numToBool(string x)
        {
            if(x == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void fillDto(Dictionary<string, string[]> dictionary)
        {
            new ChickenAPI.Data.TransferObjects.ItemDto()
            {
                //BasicUpgrade = 1,
                //CellonLvl = 1,
                Class = Convert.ToByte(dictionary["INDEX"][2]),
                //CloseDefence = 1,
                //Color = 1,
                //Concentrate = 1,
                //CriticalLuckRate = 1,
                CriticalRate = Convert.ToByte(dictionary["DATA"][5]),
                DamageMaximum = Convert.ToByte(dictionary["DATA"][2]),
                DamageMinimum = Convert.ToByte(dictionary["DATA"][1]),
                //DarkElement = 1,
                //DarkResistance = 1,
                //DefenceDodge = 1,
                //DistanceDefence = 1,
                //DistanceDefenceDodge = 1,
                Effect =  Convert.ToInt16(dictionary["INDEX"][5]),
                //EffectValue = 1,
                //Element = 1,
                //ElementRate = 1,
                //EquipmentSlot = ,
                //FireElement = 1,
                //FireResistance = 1,
                //Height = 1,
                HitRate = Convert.ToInt16(dictionary["DATA"][3]),
                //Hp = 1,
                //HpRegeneration = 1,
                //IsMinilandActionable = 1,
                //IsColored = 1,
                //Flag1 = 1,
                //Flag2 = 1,
                //Flag3 = 1,
                //Flag4 = 1,
                //Flag5 = 1,
                //Flag6 = 1,
                //Flag7 = 1,
                //Flag8 = 1,
                //IsConsumable = 1,
                IsDroppable = numToBool(dictionary["FLAG"][4]),
                //IsHeroic = 1,
                //Flag9 = 1,
                //IsWarehouse = 1,
                IsSoldable = numToBool(dictionary["FLAG"][3]),
                IsTradable = numToBool(dictionary["FLAG"][5]),
                //ItemSubType = 1,
                //ItemType = ,
                //ItemValidTime = 1,
                //LevelJobMinimum = 1,
                LevelMinimum = Convert.ToByte(dictionary["DATA"][0]),
                //LightElement = 1,
                //LightResistance = 1,
                //MagicDefence = 1,
                //MaxCellon = 1,
                //MaxCellonLvl = 1,
                //MaxElementRate = 1,
                //MaximumAmmo = 1,
                //MinilandObjectPoint = 1,
                //MoreHp = 1,
                //MoreMp = 1,
                //Morph = 1,
                //Mp = 1,
                //MpRegeneration = 1,
                Name = dictionary["NAME"][0],
                Price = Convert.ToInt64(dictionary["VNUM"][0]),
                //PvpDefence = 1,
                //PvpStrength = 1,
                //ReduceOposantResistance = 1,
                //ReputationMinimum = 1,
                //ReputPrice = 1,
                //SecondaryElement = 1,
                //Sex = 1,
                //Speed = 1,
                //SpType = 1,
                //Type = ,
                //WaitDelay = 1,
                //WaterElement = 1,
                //WaterResistance = 1,
                //Width = 1,
                Id = Convert.ToInt64(dictionary["VNUM"][0])
            };
    }
}
