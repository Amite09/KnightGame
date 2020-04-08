using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPower : MonoBehaviour
{
    private int i = 0;
    public GameObject Super;

    void OnTriggerEnter2D(Collider2D col){
        if(i == 0){
            if (col.transform.root.TryGetComponent(out Knight taker)){
                if(!taker.isSuper){
                    i = 1;
                    taker.isSuper = true;
                    this.gameObject.SetActive(false);
                    Vector3 auraPosition = new Vector3(3.14f, 0.77f, 0);
                    GameObject aura = Instantiate(Super, taker.transform.position + auraPosition, Quaternion.identity);
                    aura.transform.SetParent(taker.transform.Find("SuperPower"));
                    Destroy(aura, 10);
                } else if(taker.isSuper){
                Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), col);
                }
            }    
        }
    }
}
