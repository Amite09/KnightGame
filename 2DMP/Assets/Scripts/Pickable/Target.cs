using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private int i = 0;

    void OnTriggerEnter2D(Collider2D col){
        if(i == 0){
            if(col.transform.root.TryGetComponent(out Knight taker)){
                i = 1;
                taker.accuracy += 0.5f;
                this.gameObject.SetActive(false);
            }
        }
    }
}
