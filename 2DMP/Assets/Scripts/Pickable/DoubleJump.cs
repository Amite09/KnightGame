using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    private int i = 0;
    void OnTriggerEnter2D(Collider2D col){
        if (i == 0){
            if(col.transform.root.TryGetComponent(out Knight taker)){
                i = 1;
                taker.maxJumps += 1;
                taker.jumpsLeft += 1;
                this.gameObject.SetActive(false);
            }
        }

    }
}
