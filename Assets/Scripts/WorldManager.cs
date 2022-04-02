using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    //Singleton
    private static WorldManager instance = null;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }

    public static WorldManager Instance() {
        return instance;
    }

    [Header("World Properties")]
    public float radius;
    public float outerRadius;
    [Range(0f,1f)]
    public float mood; 
    public Gradient moodColor;




}
