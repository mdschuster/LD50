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
        float y = Mathf.Sin(randFloat);
        float x = Mathf.Cos(randFloat);
        return new Vector2(x, y);
    }

    public static Vector2 getPositionOnCircle(float angleDeg) {
        angleDeg *= Mathf.Deg2Rad;
        float y = Mathf.Sin(angleDeg);
        float x = Mathf.Cos(angleDeg);
        return new Vector2(x, y);
    }

    public static float getAngleFromVector(Vector2 position) {
        float angle= Mathf.Atan2(position.y,position.x)*Mathf.Rad2Deg;
        if (angle < 0) {
            angle += 360;
        }
        return angle;
    }
}
