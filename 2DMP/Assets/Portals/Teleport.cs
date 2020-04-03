using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public Teleport local;
    public GameObject exit;
    public Teleport target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        col.transform.position = target.transform.Find("Exit").transform.position;
        col.transform.root.TryGetComponent(out Rigidbody2D colBody);
        colBody.velocity *= new Vector2(1.5f, 1.2f);
    }
}
