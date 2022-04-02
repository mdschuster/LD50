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
    public GameObject personPrefab;
    public Sprite[] people;

    [Header("Layers")]
    public LayerMask treeLayer;

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

    }

    public void initializeTrees(int initialTrees) {
        for (int i = 0; i < initialTrees; i++) {
            spawnTrees();
        }
    }

    public void initializePeople(int initialPeople) {
        for (int i = 0; i < initialPeople; i++) {
            spawnPerson();
        }
    }

    public void initializeCities(int initialCities) {
        for (int i = 0; i < initialCities; i++) {
            spawnCity();
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
        //trees need collider and cities need collider
        Collider2D[] results=Physics2D.OverlapCircleAll(go.transform.position, 1, treeLayer);
        foreach (Collider2D c in results) {
            Tree t = c.gameObject.GetComponent<Tree>();
            spawnedTrees.Remove(t.gameObject);
            t.destroyTree();
        }

    }

    public void spawnCity(Vector2 position) {
        int randIndex = Random.Range(0, cities.Length);
        //position = Utility.getNormVectorFromCenter(position)*WorldManager.Instance().radius;
        Quaternion rotation = Utility.getQuaternionAlignment(position);


        GameObject go = instantiateOnCircle(cityPrefab, position, rotation);
        go.GetComponent<SpriteRenderer>().sprite = cities[randIndex];
        spawnedCities.Add(go);

        //destroy anything nearby
        //trees need collider and cities need collider
        Collider2D[] results = Physics2D.OverlapCircleAll(go.transform.position, 1, treeLayer);
        foreach (Collider2D c in results) {
            Tree t = c.gameObject.GetComponent<Tree>();
            spawnedTrees.Remove(t.gameObject);
            t.destroyTree();
        }

    }

    public void spawnTrees() {
        int randIndex = Random.Range(0, cities.Length);
        Vector2 position = Utility.getRandomPosOnCircle();
        Quaternion rotation = Utility.getQuaternionAlignment(position);

        GameObject go = instantiateOnCircle(treePrefab,position, rotation);
        go.GetComponent<SpriteRenderer>().sprite = trees[randIndex];
        spawnedTrees.Add(go);
    }


    public void spawnPerson() {
        int randIndex = Random.Range(0, people.Length);
        Vector2 position = Utility.getRandomPosOnCircle();
        Quaternion rotation = Utility.getQuaternionAlignment(position);

        GameObject go = instantiateOnCircle(personPrefab,position, rotation);
        go.GetComponent<SpriteRenderer>().sprite = people[randIndex];
        go.GetComponent<Person>().setupRandomAngle();
        spawnedPeople.Add(go);
    }

    public void spawnPerson(float angle) {
        int randIndex = Random.Range(0, people.Length);
        Vector2 position = Utility.getPositionOnCircle(angle);
        Quaternion rotation = Utility.getQuaternionAlignment(position);

        GameObject go = instantiateOnCircle(personPrefab, position, rotation);
        go.GetComponent<SpriteRenderer>().sprite = people[randIndex];
        go.GetComponent<Person>().setupAngle(angle);
        spawnedPeople.Add(go);
    }

    public void spawnPerson(Vector2 position) {
        int randIndex = Random.Range(0, people.Length);
        Quaternion rotation = Utility.getQuaternionAlignment(position);

        GameObject go = instantiateOnCircle(personPrefab, position, rotation);
        go.GetComponent<SpriteRenderer>().sprite = people[randIndex];
        go.GetComponent<Person>().setupAngle(Utility.getAngleFromVector(position));
        spawnedPeople.Add(go);
    }

    public GameObject instantiateOnCircle(GameObject prefab,Vector2 position, Quaternion rotation) {
        return Instantiate(prefab, Utility.getNormVectorFromCenter(position) * WorldManager.Instance().radius, rotation);

    }

}
