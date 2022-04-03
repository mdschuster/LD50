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
    private bool playedDeathFX;
    public GameObject deathPFX;
    public float deathRadius;
    public LayerMask mask;


    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        stopped = false;
        timedDeath = false;
        playedDeathFX = false;

    }

    private void Update() {
        Vector2 vecFromCenter = Utility.getFullVectorFromCenter(rb.position);
        if (vecFromCenter.magnitude <= WorldManager.Instance().radius) {
            this.GetComponent<SpriteRenderer>().enabled = false;
            rb.velocity = Vector2.zero;
            stopped = true;
            timedDeath = true;
            if (playedDeathFX == false) {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, deathRadius, mask);
                foreach(Collider2D collider in colliders) {
                    if (collider.tag == "Tree") {
                        collider.gameObject.GetComponent<Tree>().destroyTree();
                    } else if (collider.tag == "Person") {
                        collider.gameObject.GetComponent<Person>().onDeath();
                    } else { 
                        Destroy(collider.gameObject);
                    }
                }
                Instantiate(deathPFX, this.transform.position, Quaternion.identity);
                playedDeathFX=true;
            }
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
