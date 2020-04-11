using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col){
        Debug.Log(col);
        //Ignore collision with bombs
        if (col.tag == "Bomb" || col.tag == "Ball"){
            Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), col.GetComponent<CapsuleCollider2D>());
        }
    }
}
