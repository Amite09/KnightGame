﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sword : MonoBehaviour
{
    private Knight player;
    private string owner;
    public Vector2[] knockbacks = new Vector2[3];

    void Start(){
        player = this.transform.root.GetComponent<Knight>();
        owner = player.name;
    }

    //Called when the sword is hitting something
    void OnTriggerEnter2D(Collider2D col){
        string colName = col.transform.root.name;
        if(col.transform.root.TryGetComponent(out Knight enemy) && colName != this.owner && player.attacking){
            float damage = UnityEngine.Random.Range(1,3) * player.power;
            enemy.GetComponent<PlayerHealth>().applyDamage(damage);
            enemy.GetComponent<Knockbacks>().currentKnockback = knockbacks[player.GetComponent<PlayerAttack>().attackType - 1];
            enemy.GetComponent<Knockbacks>().knockedBackFactor = 1;
            enemy.GetComponent<Knockbacks>().sign = Math.Sign(player.transform.localScale.x) * (-1);
            enemy.GetComponent<Knockbacks>().knockedBack = true;
        } else if (col.transform.root.TryGetComponent(out Bomb bomb) && player.attacking)  {
            bomb.currentAngle = knockbacks[player.GetComponent<PlayerAttack>().attackType - 1];
            bomb.power = player.power;
            bomb.hitter = player.name;
            bomb.sign = Math.Sign(player.transform.localScale.x) * (-1);
            bomb.hit = true;
            bomb.GetComponent<SpriteRenderer>().color = player.transform.Find("model").Find("body").Find("Head").Find("Hat-Helmet").GetComponent<SpriteRenderer>().color;
        } else if (col.transform.root.TryGetComponent(out Ball ball) && player.attacking)  {
            ball.currentAngle = knockbacks[player.GetComponent<PlayerAttack>().attackType - 1];
            ball.power = player.power;
            ball.hitter = (player.GetComponent<Transform>().position.x < 0 ? "Left" : "Right");
            ball.sign = Math.Sign(player.transform.localScale.x) * (-1);
            ball.hit = true;
            ball.GetComponent<SpriteRenderer>().color = player.transform.Find("model").Find("body").Find("Head").Find("Hat-Helmet").GetComponent<SpriteRenderer>().color;
        }
    }
}
