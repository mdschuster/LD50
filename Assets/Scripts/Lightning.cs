using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public float duration;
    public float damageRadius;
    public LayerMask Mask;
    private float time;

    private void OnEnable() {
        time = 0f;
        //overlap cast
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position,damageRadius,Mask);
        foreach(Collider2D collider in colliders) {
            if (collider.tag == "Tree") {
                collider.gameObject.GetComponent<Tree>().destroyTree();
            } else {
                GameManager.Instance().spawnManager.getPeopleList().Remove(collider.gameObject);
            }
            Destroy(collider.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time+=Time.deltaTime;
        if (time > duration) {
            Destroy(this.gameObject);
            time = 0f;
        }
        
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, damageRadius);

    }
}
