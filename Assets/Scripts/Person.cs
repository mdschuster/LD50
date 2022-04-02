using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    [Header("Person Properties")]
    public float maxSpeed;
    public float minSpeed;
    public float directionChangeProbability;

    private int moveDirection; //positive=clockwise, negative=counterclockwise
    private Rigidbody2D rb;
    private Vector2 position;
    private float currentAngle;
    private float speed;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        //set initial direction
        float randNum = Random.Range(-1f, 1f);
        if (randNum <= 0) {
            moveDirection = 1;
        } else {
            moveDirection = -1;
        }
        //send initial speed
        speed=Random.Range(minSpeed,maxSpeed);

        

    }

    public void setupRandomAngle() {
        currentAngle = Random.Range(0f, 360f);
    }

    public void setupAngle(float angle) {
        currentAngle = angle;
    }

    private void FixedUpdate() {
        wander();
        currentAngle += moveDirection * speed * Time.deltaTime;

        Vector2 pos = Utility.getNormVectorFromCenter(Utility.getPositionOnCircle(currentAngle)) * WorldManager.Instance().radius;
        rb.MovePosition(pos);
        this.transform.rotation = Utility.getQuaternionAlignment(rb.position);
    }

    private void wander() {
        float randNum = Random.Range(0f, 1f);
        if (randNum <= directionChangeProbability) {
            moveDirection *= -1;
        }
    }
}
