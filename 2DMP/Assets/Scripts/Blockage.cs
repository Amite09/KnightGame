using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col){
        //Ignore collision with bombs
        if (col.tag == "Bomb"){
            Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), col.GetComponent<CapsuleCollider2D>());
        }
    }
}
