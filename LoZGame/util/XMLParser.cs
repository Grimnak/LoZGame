namespace LoZGame.util
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using LoZClone;

    public static class XMLParser
    {
        /*
         * this method will parse a given XML document and return 
         * an object describing the layout of a particular dungeon
         * 
         * args:
         * filePath => relative path to XML doc
         */
        public static List<List<Room>> Parse(string filePath)
        {
            List<List<Room>> dungeon = null;
            XDocument xmlDungeon = XDocument.Load(filePath);
            XElement root = xmlDungeon.Root;
            XNamespace ns = root.GetDefaultNamespace();

            /* Creates a list of enemies */
            IEnumerable<XElement> enemies = from e in xmlDungeon.Descendants(ns + "enemy") select e; // grabs all <enemies> in <dungeon>
            
            // call AddEnemy in Room and pass Enemy InnerText and necessary Attributes

            foreach (XElement enemy in enemies)
            {
                Console.WriteLine(enemy.Value); // name of each enemy
            }
            
            return dungeon; // tmp
        }
    }
}
