using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(Helper.numOfPlayers >= 3){
            this.transform.root.Find("Spawner3").GetComponent<Spawn>().enabled = true;
        }
        if(Helper.numOfPlayers == 4){
            this.transform.root.Find("Spawner4").GetComponent<Spawn>().enabled = true;
        }
    }


}
