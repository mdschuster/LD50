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
    [Header("World Graphics")]
    public SpriteRenderer World;
    [Range(0f,1f)]
    public float mood; 
    public Gradient moodColor;


    private void Update() {
        updateWorldColor();
    }

    public void updateWorldColor() {
        Color currentColor = moodColor.Evaluate(mood);
        World.color = currentColor;
    }



}
