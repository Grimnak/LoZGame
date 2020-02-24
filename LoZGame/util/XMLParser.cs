namespace LoZGame.util
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

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
            List<List<Room>> dungeon = new List<List<Room>>();
            
            XDocument xmlDungeon = XDocument.Load(filePath);
            XElement root = xmlDungeon.Root;
            XNamespace ns = root.GetDefaultNamespace();
         
            IEnumerable<XElement> rows = from r in xmlDungeon.Descendants(ns + "drow") select r; // all <drow> tags
            int i = 0; // row debug
            foreach (XElement row in rows)
            {
                List<Room> drow = new List<Room>();
                int j = 0; // column debug
                IEnumerable<XElement> rooms = from r in row.Descendants(ns + "room") select r; // all <room> tags within row
                foreach (XElement room in rooms)
                {
                    bool ex;
                    if (ex = bool.Parse(room.Attribute("exists").Value))
                    {
                        Room droom = new Room(string.Empty + ns, ex);
                        IEnumerable<XElement> doors = from d in room.Descendants(ns + "doors") select d; // all <door> tags in <room>
                        IEnumerable<XElement> items = from it in room.Descendants(ns + "items") select it; // all <items> tags in <room>
                        IEnumerable<XElement> enemies = from en in room.Descendants(ns + "enemies") select en; // all <enemy> tags in <room>
                        IEnumerable<XElement> rrow = from rr in room.Descendants(ns + "rrow") select rr; // all <rrow> tags in <room>
                        Console.Write("------"); // xml debug
                        Console.Write("\nRow " + i + ", Room " + j + "\n"); // xml debug
                        foreach (XElement doorGroup in doors.Elements()) // it's this way because my xml format is shit and i'm dumb. pretend it's not here.
                        {
                            Console.WriteLine();
                            string doorLoc = doorGroup.Attribute("loc").Value, doorKind = doorGroup.Value;
                            droom.AddDoor(doorLoc, doorKind);
                            Console.Write("door: " + doorLoc + " " + doorKind + " "); // xml debug

                        }
                        
                        foreach (XElement item in items.Elements()) // same as above. my code is poop.
                        {
                            Console.WriteLine(); // xml debug
                            int x = int.Parse(item.Attribute("X").Value), y = int.Parse(item.Attribute("Y").Value);
                            droom.AddItem(x, y, item.Value);
                            Console.Write("item: " + item.Attribute("X").Value + " " + item.Attribute("Y").Value + " " + item.Value); // xml debug 
                        }
                        
                        foreach (XElement enemy in enemies.Elements()) // xml bad
                        {
                            Console.WriteLine(); // xml debug
                            Console.Write("enemy: " + enemy.Attribute("X").Value + " " + enemy.Attribute("Y").Value + " " + enemy.Value); // xml debug 
                            int x = int.Parse(enemy.Attribute("X").Value), y = int.Parse(enemy.Attribute("Y").Value);
                            droom.AddEnemy(x, y, enemy.Value);
                        }
                        Console.WriteLine("\n-");
                        foreach (XElement trow in rrow)
                        {
                            int tcount = 0; // xml debug
                            foreach (XElement tile in trow.Elements())
                            {
                                string x = tile.Attribute("idx").Value, y = trow.Attribute("idx").Value, type = tile.Attribute("type").Value;
                                tcount++; // xml debug
                                Console.Write("tile: " + tile.Value + " type: " + tile.Attribute("type").Value + " Y: " + trow.Attribute("idx").Value + " X: " + tile.Attribute("idx").Value + " \n"); // xml debug
                                droom.AddTile(x, y, type, tile.Value);
                            }
                            Console.WriteLine("tcount: " + tcount + "\n");
                        }
                        Console.WriteLine(); // xml debug
                    }
                    j++;
                    dungeon.Add(drow);
                }
                i++;
            }

            return dungeon; // tmp?
        }
    }
}
