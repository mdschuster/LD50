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

    public static Vector2 getRandomPosOnCircle() {
        float randFloat = Random.Range(0f, 2 * Mathf.PI);
        float x = Mathf.Sin(randFloat);
        float y = Mathf.Cos(randFloat);
        return new Vector2(x, y);
    }

    public static Vector2 getPositionOnCircle(float angleDeg) {
        angleDeg *= Mathf.Deg2Rad;
        float x = Mathf.Sin(angleDeg);
        float y = Mathf.Cos(angleDeg);
        return new Vector2(x, y);
    }
}
