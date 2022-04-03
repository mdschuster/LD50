using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPerson : MonoBehaviour
{

    public float maxSpeed;
    public float minSpeed;
    public float directionChangeProbability;

    private int moveDirection; //positive=clockwise, negative=counterclockwise
    private Vector2 position;
    private float currentAngle;
    private float speed;
    private SpriteRenderer sr;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
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
        currentAngle = Utility.getAngleFromVector(this.transform.position);
    }

    private void FixedUpdate() {
        wander();
        currentAngle += moveDirection * speed * Time.deltaTime;

        Vector2 pos = Utility.getNormVectorFromCenter(Utility.getPositionOnCircle(currentAngle)) * 10.13f;
        rb.MovePosition(pos);
        this.transform.rotation = Utility.getQuaternionAlignment(rb.position);
    }


    private void wander() {
        float randNum = Random.Range(0f, 1f);
        if (randNum <= directionChangeProbability) {
            moveDirection *= -1;
            sr.flipX = !sr.flipX;
        }
    }
}
