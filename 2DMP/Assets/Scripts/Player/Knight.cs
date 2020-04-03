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

    void OnBecameInvisible () {
        if(this.transform.root.localPosition.y < -12 && this.transform.root.GetComponent<Knight>().isAlive){
            this.transform.root.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 25, 0);
            this.transform.root.GetComponent<PlayerHealth>().applyDamage(25f);
        }

    }

    void rechargeShurikens(){
        if(shurikens < maxShurikens){
            shurikens += 1;
        }

    }

    void checkSuper(){
        if(isSuper && i == 0){
            i = 1;
            Buff();
            StartCoroutine(DisableSuper(10f));
        }
    }

    IEnumerator DisableSuper(float timer){
        yield return new WaitForSeconds(timer);
        isSuper = false;
        Debuff();
        i = 0;
    }


    void Buff(){
        this.power += 3f;
        this.speed += 3f;
        this.hp = this.maxHP;
    }

    void Debuff(){
        this.power -= 3f;
        this.speed -= 3f;
    }


}
