using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowShuriken : MonoBehaviour
{
    public GameObject Shuriken;
    private Knight player;
    private bool throwButton;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Knight>();

    }

    // Update is called once per frame
    void Update()
    {
        Throw();
    }

    void Throw() {
        switch (this.name){
            case "Player 1(Clone)":
                throwButton = Input.GetKeyDown(KeyCode.X);
                break;
            case "Player 2(Clone)":
                throwButton = Input.GetKeyDown(KeyCode.Joystick1Button2);
                break;
            case "Player 3(Clone)":
                throwButton = Input.GetKeyDown(KeyCode.Joystick2Button2);
                break;
            case "Player 4(Clone)":
                throwButton = Input.GetKeyDown(KeyCode.Joystick3Button2);
                break;                
        }

        if(throwButton && player.shurikens > 0){
            player.shurikens -= 1;
            GameObject star = Instantiate (Shuriken, transform.position, Quaternion.identity);
            star.GetComponent<Shuriken> ().Owner = this.name;
            star.GetComponent<Shuriken> ().Power = player.accuracy;
            star.GetComponent<Shuriken> ().Speed *= transform.localScale.x;
        }

    }

}
