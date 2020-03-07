namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class DoorManager
    {
        private List<IDoor> doors;

        public List<IDoor> DoorList { get { return doors; } }

        public DoorManager()
        {
            this.doors = new List<IDoor>();
        }

        public void Add(Door door)
        {
            this.doors.Add(door);
        }

        public void Clear()
        {
            this.doors.Clear();
        }

        public void Update()
        {
            foreach (Door door in this.doors)
            {
                door.Update();
            }
        }

        public void Draw()
        {
            foreach (Door door in this.doors)
            {
                door.Draw();
            }
        }
    }
}