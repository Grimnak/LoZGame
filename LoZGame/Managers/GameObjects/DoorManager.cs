namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class DoorManager : IManager
    {
        private List<IDoor> doors;

        public List<IDoor> DoorList { get { return doors; } }

        public DoorManager()
        {
            doors = new List<IDoor>();
        }

        public void Add(Door door)
        {
            doors.Add(door);
        }

        public void Clear()
        {
            doors.Clear();
        }

        public void Update()
        {
            foreach (Door door in doors)
            {
                door.Update();
            }
        }

        public void Draw()
        {
            foreach (Door door in doors)
            {
                door.Draw();
            }
        }
    }
}