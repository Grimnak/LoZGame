namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    public static class XMLHandler
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
                    bool ex = bool.Parse(room.Attribute("exists").Value);
                    string border = string.Empty + ns;
                    if (room.Descendants(ns + "border").Elements().Count<XElement>() > 0)
                    {
                        border = string.Empty + room.Descendants(ns + "border").Elements().First<XElement>().Value;
                    }
                    Room droom = new Room(string.Empty + border, ex);
                    if (ex)
                    {
                        IEnumerable<XElement> doors = (from d in room.Descendants(ns + "doors") select d).Elements(); // all <door> tags in <room>
                        IEnumerable<XElement> items = (from it in room.Descendants(ns + "items") select it).Elements(); // all <items> tags in <room>
                        IEnumerable<XElement> enemies = (from en in room.Descendants(ns + "enemies") select en).Elements(); // all <enemy> tags in <room>
                        IEnumerable<XElement> rrow = from rr in room.Descendants(ns + "rrow") select rr; // all <rrow> tags in <room>
                        IEnumerable<XElement> text = from txt in room.Descendants(ns + "text") select txt; // all <text> tags in <room>
                        //Console.Write("------"); // xml debug
                        //Console.Write("\nRow " + i + ", Room " + j + "\n"); // xml debug
                        foreach (XElement door in doors)
                        {
                            Console.WriteLine();
                            string doorLoc = door.Attribute("loc").Value, doorKind = door.Value;
                            droom.AddDoor(doorLoc, doorKind);
                            //Console.Write("door: " + doorLoc + " " + doorKind + " "); // xml debug
                        }

                        foreach (XElement item in items) 
                        {
                            Console.WriteLine(); // xml debug
                            float x = float.Parse(item.Attribute("X").Value), y = float.Parse(item.Attribute("Y").Value);
                            droom.AddItem(x, y, item.Value);
                            //Console.Write("item: " + item.Attribute("X").Value + " " + item.Attribute("Y").Value + " " + item.Value); // xml debug 
                        }

                        foreach (XElement enemy in enemies)
                        {
                            Console.WriteLine(); // xml debug
                            //Console.Write("enemy: " + enemy.Attribute("X").Value + " " + enemy.Attribute("Y").Value + " " + enemy.Value); // xml debug 
                            float x = float.Parse(enemy.Attribute("X").Value), y = float.Parse(enemy.Attribute("Y").Value);
                            droom.AddEnemy(x, y, enemy.Value);
                        }
                        Console.WriteLine("\n-");
                        foreach (XElement trow in rrow)
                        {
                            int tcount = 0; // xml debug
                            foreach (XElement block in trow.Elements()) // .Elements() here b/c object references a parent with list of children and we just want the children.
                            {
                                string x = block.Attribute("idx").Value, y = trow.Attribute("idx").Value;
                                tcount++; // xml debug
                                string[] types = block.Attribute("type").Value.Split(',');
                                if (block.Attribute("dir") != null)
                                {
                                    string direction = block.Attribute("dir").Value;
                                    droom.AddBlock(x, y, types[0], block.Value, direction);
                                }
                                else
                                {
                                    droom.AddBlock(x, y, types[0], block.Value);
                                }
                            }
                            Console.WriteLine("tcount: " + tcount + "\n");
                        }
                        Console.WriteLine(); // xml debug
                        foreach (XElement node in text)
                        {
                            droom.SetText(node.Value);
                            //Console.WriteLine("Room Text Here: " + node.Value); // xml debug
                        }
                    }
                    j++;
                    drow.Add(droom);
                }
                dungeon.Add(drow);
                i++;
            }
            return dungeon;
        }
    }
}