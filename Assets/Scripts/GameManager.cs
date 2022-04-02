using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton
    private static GameManager instance = null;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }

    public static GameManager Instance() {
        return instance;
    }

    public Camera mainCamera;
    public SpawnManager spawnManager;
    [Header("Initial Parameters")]
    public int initialTrees;
    public int initialPeople;
    public int initialCities;

    private void Start() {
        spawnManager.initializeTrees(initialTrees);
        spawnManager.initializePeople(initialPeople);
        spawnManager.initializeCities(initialCities);
    }


}
