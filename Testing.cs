using System;
using System.Media;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Testing
    {
        /// <summary>
        /// Something testing?
        /// </summary>
        /// <returns> Something. </returns>
        public void CheckInventory()
        {
            Debug.Assert(Items.Count > 0, "Inventory should not be empty!");
        }
    }
}