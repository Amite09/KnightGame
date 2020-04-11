using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoCollide : MonoBehaviour
{   
    //Ignore collision with other players
    void OnTriggerEnter2D(Collider2D col){
        if (col.transform.root.TryGetComponent(out Knight otherPlayer) && !otherPlayer.attacking){
            Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), col.GetComponent<BoxCollider2D>());
        }
    }

}
