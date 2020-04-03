using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sword : MonoBehaviour
{
    private Knight player;
    private string owner;
    private bool alreadyHit = false;
    public Vector2[] knockbacks = new Vector2[3];

    void Start(){
        player = this.transform.root.GetComponent<Knight>();
        owner = player.name;
    }

    void OnTriggerEnter2D(Collider2D col){
        // if (col.tag != "Player"){
        //     return;
        // }
        string colName = col.transform.root.name;
        if(col.transform.root.TryGetComponent(out Knight enemy) && colName != this.owner && player.attacking && !alreadyHit){
            float damage = UnityEngine.Random.Range(3,6) * player.power;
            alreadyHit = true;
            enemy.GetComponent<PlayerHealth>().applyDamage(damage);
            enemy.GetComponent<PlayerControl>().currentKnockback = knockbacks[player.GetComponent<PlayerAttack>().attackType - 1];
            enemy.GetComponent<PlayerControl>().sign = Math.Sign(player.transform.localScale.x) * (-1);
            enemy.GetComponent<PlayerControl>().knockedBack = true;
            StartCoroutine(hit(0.5f));
        } else if (col.transform.root.TryGetComponent(out Bomb bomb) && player.attacking && !alreadyHit)  {
            alreadyHit = true;
            bomb.currentAngle = knockbacks[player.GetComponent<PlayerAttack>().attackType - 1];
            bomb.power = player.power;
            bomb.hitter = player.name;
            bomb.sign = Math.Sign(player.transform.localScale.x) * (-1);
            bomb.hit = true;
            bomb.GetComponent<SpriteRenderer>().color = player.transform.Find("model").Find("body").Find("Head").Find("Hat-Helmet").GetComponent<SpriteRenderer>().color;
            StartCoroutine(hit(0.5f));
        }    
    }


    IEnumerator hit(float timer){
        yield return new WaitForSeconds(timer);
        alreadyHit = false;
    }



}
