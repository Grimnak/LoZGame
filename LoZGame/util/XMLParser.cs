using LoZClone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace LoZGame.util
{
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
            XDocument dungeon = XDocument.Load(filePath);
            XElement root = dungeon.Root;
            XNamespace ns = root.GetDefaultNamespace();

            /* Creates a list of enemies */
            IEnumerable<XElement> enemies = from e in dungeon.Descendants(ns + "enemy") select e; // grabs all <enemies> in <dungeon>
            
            // call AddEnemy in Room and pass Enemy InnerText and necessary Attributes

            foreach (XElement enemy in enemies)
            {
                Console.WriteLine(enemy.Value); // name of each enemy
            }
            
            return null; // tmp
        }
    }
}
