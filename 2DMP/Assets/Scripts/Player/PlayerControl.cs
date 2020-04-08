using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerControl: MonoBehaviour
{
    private Knight player;
    private Rigidbody2D myBody;
    private Animator anim;

    public Transform groundCheckPosition;
    public LayerMask  groundLayer;

    private bool isGrounded;
    private bool jumped;
    private float h = 0f;
    private bool jumpButton;
    private bool rollButton;
    public bool rolled;
    private int direction;

    public bool knockedBack;
    public float knockedBackFactor;
    public int sign = 0;
    public Vector2 currentKnockback;
    
    void Awake() {
        player = GetComponent<Knight>();
        myBody = GetComponent<Rigidbody2D>();
        anim = this.transform.Find("model").GetComponent<Animator>(); 
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlayerWalk();
        Roll();
        CheckIfGrounded();
        PlayerJump(); 
        if(knockedBack)
            Knockback(currentKnockback, sign);   
        
    }

    void PlayerWalk() {

        switch (this.name){
            case "Player 1(Clone)":
                h = Input.GetAxis("P1_H");
                break;
            case "Player 2(Clone)":
                h = Input.GetAxis("P2_H");
                break;
            case "Player 3(Clone)":
                h = Input.GetAxis("P3_H");
                break;
            case "Player 4(Clone)":
                h = Input.GetAxis("P4_H");
                break;                
        }
        
        if(!player.attacking && player.isAlive && !rolled) {
            if (h > 0){
                myBody.velocity = new Vector2(player.speed, myBody.velocity.y);
                direction = -1;
                ChangeDirection();
		    }
            else if (h < 0){
                myBody.velocity = new Vector2(-player.speed, myBody.velocity.y);
                direction = 1;
                ChangeDirection();
            }
            else{
                myBody.velocity = new Vector2 (0f, myBody.velocity.y);          
            }

            anim.SetInteger ("Speed", Mathf.Abs((int)myBody.velocity.x));
        }

    }

    void ChangeDirection (){
        Vector3 tempScale = transform.localScale;
        tempScale.x = Math.Abs(tempScale.x) * direction;
        transform.localScale = tempScale;

    }

    void CheckIfGrounded(){
        isGrounded = Physics2D.Raycast(groundCheckPosition.position, Vector2.down, 0.1f, groundLayer);
        if (isGrounded){
            if (jumped && myBody.velocity.y == 0){
                anim.SetBool("Jump", false);
                jumped = false;
                player.jumpsLeft = player.maxJumps;
            }         
        }
    }

    void PlayerJump(){

        switch (this.name){
            case "Player 1(Clone)":
                jumpButton = Input.GetKeyDown(KeyCode.Space);
                break;
            case "Player 2(Clone)":
                jumpButton = Input.GetKeyDown(KeyCode.Joystick1Button1);
                break;
            case "Player 3(Clone)":
                jumpButton = Input.GetKeyDown(KeyCode.Joystick2Button1);
                break;
            case "Player 4(Clone)":
                jumpButton = Input.GetKeyDown(KeyCode.Joystick3Button1);
                break;                
        }

        if(player.jumpsLeft > 0 && player.isAlive) {           
            if (jumpButton){
                jumped = true;
                player.jumpsLeft -= 1;
                myBody.velocity = new Vector2 (myBody.velocity.x, player.jumpPower);
                anim.SetBool("Jump", true);
            }           
        }
    }

    void Roll(){

        switch (this.name){
            case "Player 1(Clone)":
                rollButton = Input.GetKeyDown(KeyCode.LeftControl);
                break;
            case "Player 2(Clone)":
                rollButton = Input.GetKeyDown(KeyCode.Joystick1Button4);
                break;
            case "Player 3(Clone)":
                rollButton = Input.GetKeyDown(KeyCode.Joystick2Button4);
                break;
            case "Player 4(Clone)":
                rollButton = Input.GetKeyDown(KeyCode.Joystick3Button4);
                break;                
        }

        if(rollButton && !rolled && isGrounded && !player.attacking){
            player.GetComponent<CapsuleCollider2D>().enabled = false;
            rolled = true;
            anim.Play("Roll");
            StartCoroutine(StopRoll());
        }
        if (rolled){
            myBody.velocity = new Vector2 (-direction * 20f, myBody.velocity.y);
            isGrounded = true;
        }
    }

    IEnumerator StopRoll(){
        yield return new WaitForSeconds(0.4f);
        rolled = false;
        player.GetComponent<CapsuleCollider2D>().enabled = true;

    }




    public void Knockback(Vector2 kno, int sign){
        myBody.velocity = new Vector2(kno.x * sign, kno.y) * knockedBackFactor;
         knockedBackFactor *= 0.95f;
        StartCoroutine(KnockbackPause());
    }

    IEnumerator KnockbackPause(){
        yield return new WaitForSeconds(0.3f);
        knockedBack = false;
    }


    




}
