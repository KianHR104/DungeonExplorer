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
            Debug.Assert(Items.Count > 0, "Inventory should not be empty!");
        }
    }
}