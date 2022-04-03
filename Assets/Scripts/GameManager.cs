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
    public int initialBushes;

    private void Start() {
        spawnManager.initializeTrees(initialTrees);
        spawnManager.initializePeople(initialPeople);
        spawnManager.initializeCities(initialCities);
        spawnManager.initializeBushes(initialBushes);

        //mood is directly linked to the number of trees
        int currentTrees=initialTrees= spawnManager.getTreeList().Count;
        WorldManager.Instance().mood = (float)currentTrees / initialTrees;
        WorldManager.Instance().updateWorldColor();

    }

    public void updateTreeCount(int amt=1) {
        WorldManager.Instance().mood -= (float)amt / initialTrees;
        if (WorldManager.Instance().mood <= 0.05f) {
            WorldManager.Instance().mood = 0f;
            WorldManager.Instance().updateWorldColor();
            gameOver();
        }
        WorldManager.Instance().updateWorldColor();
    }

    private void gameOver() {

    }


}
