﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Rigidbody2D myBody;
    private Animator anim;
    private Knight player;
    private int i = 0;

    void Awake() {
        anim = this.transform.Find("model").GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        player = GetComponent<Knight>();
    }


    void OnTriggerEnter2D(Collider2D col){
        
        //Checks if the player is alive after getting hit.
        if((col.transform.root.TryGetComponent(out Shuriken star) && star.Owner != player.name) || 
            (col.transform.root.TryGetComponent(out Flame fireAttack) && fireAttack.Owner != player.name)){
                StartCoroutine(checkIfAlive());
        } else if ((col.transform.root.TryGetComponent(out Knight enemy) && enemy.attacking)) {
            anim.Play("Hit");
            StartCoroutine(checkIfAlive());
        } 

    }
    //Chech if the player is alive
    IEnumerator checkIfAlive(){
        if(player.hp == 0 && i == 0){
            i = 1;
            this.GetComponent<BoxCollider2D>().enabled = false;
            player.lives = (player.lives > 0 ? player.lives - 1 : 0);
            player.isAlive = false;
            anim.Play("Die");
            yield return new WaitForSeconds(0.7f);
            this.GetComponent<Knight>().invisible = false;
            i = 0;
        } else {
            yield return new WaitForSeconds(0.2f);
            this.GetComponent<Knight>().invisible = false;
        }
        
    }

    //apply damage to a player
    public void applyDamage(float damage){
        player.hp = (player.hp - damage < 0 ? 0 : player.hp - damage);
        if (player.gameObject.activeInHierarchy){
            StartCoroutine(checkIfAlive());
        }
    }
}
