using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public CanvasGroup gameOverGroup;

    private bool isGameOver;

    private void Start() {
        gameOverGroup.gameObject.SetActive(false);
        isGameOver = false;
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
            //Time.timeScale = 0.1f;
        }
        WorldManager.Instance().updateWorldColor();
    }

    private void gameOver() {
        isGameOver = true;
        gameOverGroup.gameObject.SetActive(true);
        StartCoroutine(FadeTo(1f,2f));

    }

    public bool getGameOver() {
        return isGameOver;
    }

    public void onReturnToMenuClick() {
        SceneManager.LoadScene("Menu");
    }
    public void onRestartClick() {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    IEnumerator FadeTo(float aValue, float aTime) {
        float alpha = gameOverGroup.alpha;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime) {
            float newAlpha = Mathf.Lerp(alpha, aValue, t);
            gameOverGroup.alpha = newAlpha;
            yield return null;
        }
    }


}
