using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static Vector2 getNormVectorFromCenter(Vector2 position) {
        Vector2 center = Vector2.zero;
        Vector2 vectorToTarget = position - center;
        return vectorToTarget.normalized;

    }

    public static Vector2 getFullVectorFromCenter(Vector2 position) {
        Vector2 center = Vector2.zero;
        return position - center;

    }

    public static Quaternion getQuaternionAlignment(Vector2 vecToAlign) {
        return Quaternion.LookRotation(Vector3.forward, vecToAlign);
    }
}
