using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{

    private int i = 0;
    void OnTriggerEnter2D(Collider2D col){
        if(i == 0){
            if(col.transform.root.TryGetComponent(out Knight taker)){
                i = 1;
                taker.hp += 50;
                taker.hp = (taker.hp > taker.maxHP ? taker.maxHP : taker.hp);  
                this.gameObject.SetActive(false);
            }
        }
    }

}
