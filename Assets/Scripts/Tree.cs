using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    private SpawnManager spawnManager;
    public GameObject leaves;
    public GameObject wood;

    private void Awake() {
        spawnManager = GameManager.Instance().spawnManager;
    }

    public void destroyTree() {
        GameManager.Instance().updateTreeCount();
        spawnManager.getTreeList().Remove(this.gameObject);
        Instantiate(leaves, this.transform.position, Quaternion.identity);
        Instantiate(wood, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
