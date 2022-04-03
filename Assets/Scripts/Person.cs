using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    [Header("Person Properties")]
    public float maxSpeed;
    public float minSpeed;
    public float directionChangeProbability;
    public GameObject deathFX;
    public GameObject deathSound;


    [Header("City Creation Properties")]
    public float citySpawnProbability;
    public LayerMask cityMask;
    private float time;

    private int moveDirection; //positive=clockwise, negative=counterclockwise
    private Rigidbody2D rb;
    private Vector2 position;
    private float currentAngle;
    private float speed;
    private SpriteRenderer sr;
    private int totalTime;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        sr=GetComponent<SpriteRenderer>();
        //set initial direction
        float randNum = Random.Range(-1f, 1f);
        if (randNum <= 0) {
            moveDirection = 1;
            sr.flipX = true;
        } else {
            moveDirection = -1;
            sr.flipX = false;
        }
        //send initial speed
        speed = Random.Range(minSpeed, maxSpeed);
        totalTime = 0;



    }

    private void Update() {
        if (GameManager.Instance().getGameOver()) return;
        time += Time.deltaTime;
        if (time >= 2f) {
            float rand = Random.Range(0f, 1f);
            if (rand <= citySpawnProbability) {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, 0.2f, cityMask);
                if (colliders.Length == 0) {
                    //spawn city or factory
                    if (rand <= citySpawnProbability/3f) {
                        GameManager.Instance().spawnManager.spawnFactory(this.transform.position);
                    } else {
                        GameManager.Instance().spawnManager.spawnCity(this.transform.position);
                    }
                }
            }

            time = 0f;
            int intTime = Mathf.FloorToInt(totalTime);
            if (intTime % 6 == 0 && intTime != 0) {
                citySpawnProbability *= 3f;
            }
        }
    }


    private void FixedUpdate() {
        wander();
        currentAngle += moveDirection * speed * Time.deltaTime;

        Vector2 pos = Utility.getNormVectorFromCenter(Utility.getPositionOnCircle(currentAngle)) * WorldManager.Instance().radius;
        rb.MovePosition(pos);
        this.transform.rotation = Utility.getQuaternionAlignment(rb.position);
    }

    public void onDeath() {
        Instantiate(deathFX,this.transform.position,this.transform.rotation);
        Instantiate(deathSound, this.transform.position, this.transform.rotation);
        GameManager.Instance().spawnManager.getPeopleList().Remove(this.gameObject);
        Destroy(this.gameObject);
    }


    public void setupRandomAngle() {
        currentAngle = Random.Range(0f, 360f);
    }

    public void setupAngle(float angle) {
        currentAngle = angle;
    }

    private void wander() {
        float randNum = Random.Range(0f, 1f);
        if (randNum <= directionChangeProbability) {
            moveDirection *= -1;
            sr.flipX = !sr.flipX;
        }
    }
}
