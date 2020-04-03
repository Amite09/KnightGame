using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public Teleport local;
    public GameObject exit;
    public Teleport target;


    //When someone is entering the portal he will get out of the target portal's exit
    void OnTriggerEnter2D(Collider2D col){
        col.transform.position = target.transform.Find("Exit").transform.position;
        col.transform.root.TryGetComponent(out Rigidbody2D colBody);
        colBody.velocity *= new Vector2(1.05f, 1.05f);
    }
}
