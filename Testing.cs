using System;
using System.Media;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Testing
    {
        /// <summary>
        /// Checks if the inventory is empty.
        /// </summary>
        public void CheckInventory()
        {
            Debug.Assert(Items.Count > 0, "inventory should not be empty right after picking up items.");
        }
        /// <summary>
        /// Checks if the RoomIndex is smaller than CurrentRoom.Count
        /// </summary>
        public void CheckRoomIndex()
        {
            Debug.Assert(RoomIndex < CurrentRoom.Count, "Room Index should be lower than the room count at all times.");
        }
    }
}