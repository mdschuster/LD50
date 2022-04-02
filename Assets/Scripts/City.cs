using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{

    public float probToCreatePerson; //every second
    private float time;
    private float cityAngle;



    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time+=Time.deltaTime;
        if(time >= 1f) {
            float rand = Random.Range(0f, 1f);
            if (rand <= probToCreatePerson) {
                GameManager.Instance().spawnManager.spawnPerson(this.transform.position);
            }
            time = 0f;
        }
    }

}
