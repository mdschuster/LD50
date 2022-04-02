using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    private SpawnManager spawnManager;

    private void Awake() {
        spawnManager = GameManager.Instance().spawnManager;
    }

    public void destroyTree() {
        spawnManager.getTreeList().Remove(this.gameObject);
        Destroy(this.gameObject);
    }
}
