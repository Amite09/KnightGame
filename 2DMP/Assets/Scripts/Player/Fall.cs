using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    private Knight player;

    void Awake(){
        player = transform.root.GetComponent<Knight>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //When player falls from map (down) he gets damaged and a boost back up
    void OnBecameInvisible () {
        if(player.isAlive && !player.invisible && !player.vb){
            player.invisible = true;
            this.transform.root.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 25, 0);
            this.transform.root.GetComponent<PlayerHealth>().applyDamage(25f);
        }

    }
}
