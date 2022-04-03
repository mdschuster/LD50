using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{

    private Rigidbody2D rb;
    private Vector2 target;
    public float maxSpeed;
    private bool stopped;
    private bool timedDeath;


    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        stopped = false;
        timedDeath = false;

    }

    private void Update() {
        Vector2 vecFromCenter = Utility.getFullVectorFromCenter(rb.position);
        if (vecFromCenter.magnitude <= WorldManager.Instance().radius) {
            this.GetComponent<SpriteRenderer>().enabled = false;
            rb.velocity = Vector2.zero;
            stopped = true;
            timedDeath = true;
        }
        if (timedDeath) {
            Destroy(this.gameObject, 2f);
        }
    }

    private void FixedUpdate() {
        if (target != null && !stopped) {
            rb.velocity = -target.normalized*maxSpeed;
        }
    }

    public void setTarget(Vector2 target) {
        this.target = target;
    }
}
