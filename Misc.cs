using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Misc : Items
    {

        public Misc(string name, string description)
            : base(name, description, ItemType.Misc)
        {
        }
        /// <summary>
        /// You use the thing and it does nothing
        /// </summary>
        public override void Use()
        {
            Console.WriteLine("Bro its just an item.");
        }
    }

    public class Binoculars : Misc
    {
        /// <summary>
        /// Name: "Binoculars" 
        /// </summary>
        public Binoculars() : base("Binoculars", "You can see far i guess.") {}
    }
    public class UnendingBox : Misc
    {
        /// <summary>
        /// Name: "Unending Box" 
        /// </summary>
        public UnendingBox() : base("Unending Box", "The box seems... Bottomless.") {}
    }
    public class ResidenceKey : Misc
    {
        /// <summary>
        /// Name: "Residence Key" 
        /// </summary>
        public ResidenceKey() : base("Residence Key", "The redisence was evil.") {}
    }
    public class MysteryKey : Misc
    {
        /// <summary>
        /// Name: "Mystery Key" 
        /// </summary>
        public MysteryKey() : base("Mystery Key", "What does this key do? It must have some Greater meaning, well you will never know because im not implementing it.") {}
    }
}
