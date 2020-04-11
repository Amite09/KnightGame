using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{   public int lives; 
    public float maxHP;
    public float hp;
    public float speed;
    public float jumpPower;
    public float power = 0;
    public float accuracy;
    public bool attacking;
    public int maxJumps;
    public int jumpsLeft;
    public bool isSuper;
    public bool isAlive;
    public int maxShurikens;
    public int shurikens;
    public bool vb;

    public int invisible = 0;
    private int i = 0;
    public int j = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("rechargeShurikens", 0, 1.5f);      
    }

    // Update is called once per frame
    void Update()
    {
        checkSuper();

    }

    //When player falls from map (down) he gets a boost back up
    void OnBecameInvisible () {
        if(this.transform.root.localPosition.y < -3 && isAlive && invisible == 0 && !vb){
            invisible = 1;
            this.transform.root.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 25, 0);
            this.transform.root.GetComponent<PlayerHealth>().applyDamage(25f);
        }

    }

    void rechargeShurikens(){
        if(shurikens < maxShurikens){
            shurikens += 1;
        }

    }

    //Buffs the player when he gets a super power up
    void checkSuper(){
        if(isSuper && i == 0){
            i = 1;
            Buff();
            StartCoroutine(DisableSuper());
        }
    }

    //Disable super after 10sec
    IEnumerator DisableSuper(){
        yield return new WaitForSeconds(10f);
        isSuper = false;
        Debuff();
        i = 0;
    }

    //Add buffs when player is super
    void Buff(){
        this.power += 3f;
        this.speed += 3f;
        this.hp += this.maxHP * 0.5f;
        this.hp = (this.hp < this.maxHP ? this.hp : this.maxHP);
    }

    //Disable buffs;
    void Debuff(){
        this.power -= 3f;
        this.speed -= 3f;
    }


}
