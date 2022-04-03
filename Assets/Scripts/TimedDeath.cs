using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDeath : MonoBehaviour
{

    public float timeToDie;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = timeToDie;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0) {
            Destroy(this.gameObject);
        }
    }
}
