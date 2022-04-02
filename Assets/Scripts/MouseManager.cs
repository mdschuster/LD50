using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public GameObject innerGizmo;
    public GameObject outerGizmo;

    [Header("Mouse Weapons")]
    public GameObject rest;
    public GameObject lightning;
    public float lightningCooldown;
    private float lTime;


    // Start is called before the first frame update
    void Start()
    {
        lTime = lightningCooldown;
        //lightning.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        lTime -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && lTime<=0f) {
            
            Vector2 mousePos = GameManager.Instance().mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 vec = Utility.getNormVectorFromCenter(mousePos)*WorldManager.Instance().radius;
            GameObject go = Instantiate(lightning, vec, Utility.getQuaternionAlignment(vec));

            lTime = lightningCooldown;
            //TODO need to add graphics to show cooldown

            //lightning.transform.position = vec;
            //lightning.transform.rotation = Utility.getQuaternionAlignment(vec);
        }

        //Vector2 mousePos = GameManager.Instance().mainCamera.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 vec = Utility.getNormVectorFromCenter(mousePos);
        //innerGizmo.transform.position = vec*WorldManager.Instance().radius;
        //innerGizmo.transform.rotation = Utility.getQuaternionAlignment(vec);
        ////print(Utility.getAngleFromVector(new Vector2(mousePos.x,mousePos.y)));


        //outerGizmo.transform.position = vec * WorldManager.Instance().outerRadius;


    }
}
