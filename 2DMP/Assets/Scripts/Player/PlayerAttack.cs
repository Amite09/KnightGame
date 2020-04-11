using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private Knight player;
    private bool meleeButton;
    private bool meleeButton2;
    private bool meleeButton3;
    public int attackType;

    // Awake is called before the first frame
    void Awake() {
        anim = this.transform.Find("model").GetComponent<Animator>();
        player = GetComponent<Knight>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMelee();
        
    }

    void PlayerMelee(){
        switch (this.name){
            case "Player 1(Clone)":
                meleeButton = Input.GetKeyDown(KeyCode.Z);
                meleeButton2 = Input.GetKeyDown(KeyCode.A);
                meleeButton3 = Input.GetKeyDown(KeyCode.LeftShift);
                break;
            case "Player 2(Clone)":
                meleeButton = Input.GetKeyDown(KeyCode.Joystick1Button0);
                meleeButton2 = Input.GetKeyDown(KeyCode.Joystick1Button5);
                meleeButton3 = Input.GetKeyDown(KeyCode.Joystick1Button7);
                break;
            case "Player 3(Clone)":
                meleeButton = Input.GetKeyDown(KeyCode.Joystick2Button0);
                meleeButton2 = Input.GetKeyDown(KeyCode.Joystick2Button5);
                meleeButton3 = Input.GetKeyDown(KeyCode.Joystick2Button7);
                break;
            case "Player 4(Clone)":
                meleeButton = Input.GetKeyDown(KeyCode.Joystick3Button0);
                meleeButton2 = Input.GetKeyDown(KeyCode.Joystick3Button5);
                meleeButton3 = Input.GetKeyDown(KeyCode.Joystick3Button7);
                break;                
        }

        if ((meleeButton || meleeButton2 || meleeButton3) && !player.GetComponent<PlayerControl>().rolled){
            if (meleeButton3){
                player.attacking = true;
                attackType = 3;     
                anim.Play("Attack3");
            } else if(meleeButton2){
                player.attacking = true;
                attackType = 2;          
                anim.Play("Attack2");
            } else if(meleeButton){
                player.attacking = true;
                attackType = 1;
                anim.Play("Attack");
            }

            StartCoroutine(StopMelee(0.3f));
        }        

    }

    IEnumerator StopMelee(float timer) {
        yield return new WaitForSeconds(timer);
        player.attacking = false; 
        yield return new WaitForSeconds(timer);
    } 




}
