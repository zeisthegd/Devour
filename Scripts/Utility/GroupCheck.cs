using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    class GroupCheck
    {
        public static bool IsInTheHook(Node2D body)
        {
            if (body.IsInGroup("TheHook"))
                return true;
            else return false;
        }
        public static bool IsInHookable(Node2D body)
        {
            if (body.IsInGroup("Hookable"))
                return true;
            else return false;
        }
        public static bool IsInMobs(Node2D body)
        {
            if (body.IsInGroup("Mobs"))
                return true;
            else return false;
        }
        public static bool IsInStaticObjects(Node2D body)
        {
            if (body.IsInGroup("StaticObjects"))
                return true;
            else return false;
        }

        public static bool IsInWiz(Node2D body)
        {
            if (body.IsInGroup("Wiz"))
                return true;
            else return false;
        }
    }
}
