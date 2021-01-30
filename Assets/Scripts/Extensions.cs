using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static bool IsActiveFloorTag(this string tag)
    {
        if (tag == "Floor")
            return true;

        if (Perspective.Current == PerspectiveOption.Mario)
            return tag == "Floor_MarioOnly";

        if (Perspective.Current == PerspectiveOption.Goomba)
            return tag == "Floor_GoombaOnly";

        return false;
    }

    public static bool IsFloorTag(this string tag)
    {
        return tag == "Floor" || tag == "Floor_MarioOnly" || tag == "Floor_GoombaOnly";

    }
}

