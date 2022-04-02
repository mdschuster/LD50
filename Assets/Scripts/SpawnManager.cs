using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [Header("Spawnable Objects")]
    public GameObject cityPrefab;
    public Sprite[] cities;
    public GameObject treePrefab;
    public Sprite[] trees;
    public GameObject peoplePrefab;
    public Sprite[] people;

    private List<GameObject> spawnedCities;
    private List<GameObject> spawnedTrees;
    private List<GameObject> spawnedPeople;


    private void Awake() {
        spawnedCities = new List<GameObject>();
        spawnedTrees = new List<GameObject>();
        spawnedPeople = new List<GameObject>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            spawnCity();
        }
    }

    public void initializeTrees(int initialTrees) {
        for (int i = 0; i < initialTrees; i++) {
            spawnTrees();
        }
    }

    public void spawnCity() {
        int randIndex = Random.Range(0, cities.Length);
        Vector2 position = Utility.getRandomPosOnCircle();
        Quaternion rotation = Utility.getQuaternionAlignment(position);

        GameObject go = Instantiate(cityPrefab, Utility.getNormVectorFromCenter(position)*WorldManager.Instance().radius, rotation);
        go.GetComponent<SpriteRenderer>().sprite = cities[randIndex];
        spawnedCities.Add(go);

        //destroy anything nearby

    }

    public void spawnTrees() {
        int randIndex = Random.Range(0, cities.Length);
        Vector2 position = Utility.getRandomPosOnCircle();
        Quaternion rotation = Utility.getQuaternionAlignment(position);

        GameObject go = instantiateOnCircle(position, rotation);
        go.GetComponent<SpriteRenderer>().sprite = trees[randIndex];
        spawnedTrees.Add(go);
    }

    public void destroyTree(GameObject tree) {
        spawnedTrees.Remove(tree);
        Destroy(tree);
    }

    public GameObject instantiateOnCircle(Vector2 position, Quaternion rotation) {
        return Instantiate(treePrefab, Utility.getNormVectorFromCenter(position) * WorldManager.Instance().radius, rotation);

    }

}
