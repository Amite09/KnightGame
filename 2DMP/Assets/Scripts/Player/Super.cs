using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Super : MonoBehaviour
{

    private Knight player;
    public GameObject Flame;    
    private bool flameButton;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.root.GetComponent<Knight>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.isSuper)
            GoSuper();
    }


    void GoSuper(){

        switch (this.name){
            case "Player 1(Clone)":
                flameButton = Input.GetKeyDown(KeyCode.S);
                break;
            case "Player 2(Clone)":
                flameButton = Input.GetKeyDown(KeyCode.Joystick1Button3);
                break;
            case "Player 3(Clone)":
                flameButton = Input.GetKeyDown(KeyCode.Joystick2Button3);
                break;
            case "Player 4(Clone)":
                flameButton = Input.GetKeyDown(KeyCode.Joystick2Button3);
                break;                
        }

        if (flameButton){
            Vector3 spawnLocation = new Vector3(transform.position.x - transform.localScale.x * 2f, transform.position.y, transform.position.z);
            GameObject superAttack = Instantiate (Flame, spawnLocation, Quaternion.identity);
            superAttack.transform.localScale = Vector3.Scale(superAttack.transform.localScale, transform.localScale);
            superAttack.GetComponent<Flame> ().Owner = this.name;
            superAttack.GetComponent<Flame> ().Power = player.accuracy;
            superAttack.GetComponent<Flame> ().Speed *= transform.localScale.x;
        }        
    }
}
