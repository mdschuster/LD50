using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public GameObject innerGizmo;
    public GameObject outerGizmo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = GameManager.Instance().mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 vec = Utility.getNormVectorFromCenter(mousePos);
        innerGizmo.transform.position = vec*WorldManager.Instance().radius;
        innerGizmo.transform.rotation = Utility.getQuaternionAlignment(vec);
        //print(Utility.getAngleFromVector(new Vector2(mousePos.x,mousePos.y)));


        outerGizmo.transform.position = vec * WorldManager.Instance().outerRadius;


    }
}
