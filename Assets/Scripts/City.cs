using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{

    public float probToCreatePerson; //every second
    private float time;
    private float cityAngle;
    private float totalTime;



    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        totalTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance().getGameOver()) return;
        time +=Time.deltaTime;
        totalTime+=Time.deltaTime;
        if(time >= 1f) {
            float rand = Random.Range(0f, 1f);
            if (rand <= probToCreatePerson) {
                GameManager.Instance().spawnManager.spawnPerson(this.transform.position);
            }
            time = 0f;
        }
        int intTime = Mathf.FloorToInt(totalTime);
        if (intTime%15 == 0 && intTime != 0){
            probToCreatePerson *= 2f;
        }
    }

}
