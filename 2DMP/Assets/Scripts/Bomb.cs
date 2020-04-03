using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    private Rigidbody2D body;
    private SpriteRenderer sr;
    public Vector2 currentAngle;
    public float power;
    public int sign;
    public bool hit;
    public string hitter;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        hitter = "Nobody";
    }

    // Update is called once per frame
    void Update()
    {
        bombHit();
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.transform.root.TryGetComponent(out Knight toucher) && !toucher.attacking && toucher.name != hitter){
            float damage = (body.velocity.magnitude  * this.power) * 0.2f;
            toucher.GetComponent<PlayerHealth>().applyDamage(damage);
        }
    } 

    void bombHit() {
        if(hit){
            body.velocity = new Vector2(currentAngle.x * sign, currentAngle.y);
            StartCoroutine(stopBomb());
        }
    }

     IEnumerator stopBomb(){
         yield return new WaitForSeconds(0.1f);
         hit = false;
     }

     void OnBecameInvisible() {
         if (body.position.y < -14){
             sr.color = new Color(1,1,1,1); 
             hitter = "Nobody";
             body.velocity = new Vector2(0,0);
             body.position = new Vector2((body.position.x < 0 ? Random.Range(-20,-10) : Random.Range(10,20)), 14);
         }
     }
}

