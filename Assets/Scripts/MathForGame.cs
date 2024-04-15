using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathForGame
{
    
    public static float angle(float x1, float y1, float x2, float y2)
    {
        return Mathf.Atan2(y2 - y1, x2 - x1) * Mathf.Rad2Deg;
    }
}
