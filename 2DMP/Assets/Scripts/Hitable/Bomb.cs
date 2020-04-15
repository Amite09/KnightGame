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

    //Damages a player that was hit
    void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "Pickable"){
            Physics2D.IgnoreCollision(GetComponent<CapsuleCollider2D>(), col);
        }
        if (col.transform.root.TryGetComponent(out Knight roller) && roller.GetComponent<PlayerControl>().rolled){
            Physics2D.IgnoreCollision(GetComponent<CapsuleCollider2D>(), roller.GetComponent<BoxCollider2D>());
        }
        else if (col.transform.root.TryGetComponent(out Knight nonRoller) && !nonRoller.GetComponent<PlayerControl>().rolled){
            Physics2D.IgnoreCollision(GetComponent<CapsuleCollider2D>(), roller.GetComponent<BoxCollider2D>(), false);
        }

        if (col.transform.root.TryGetComponent(out Knight toucher) && !toucher.attacking && toucher.name != hitter && hitter != "Nobody" ){
            float damage = (body.velocity.magnitude  * this.power) * 0.1f;
            toucher.GetComponent<PlayerHealth>().applyDamage(damage);
        }
    } 

    //Called when the bomb is hit with a sword
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

    //Relocationing the bomb if it fell of the map
     void OnBecameInvisible() {
         if (body.position.y < -14 || body.position.x < -27 || body.position.x > 27){
             sr.color = new Color(1,1,1,1); 
             hitter = "Nobody";
             body.velocity = new Vector2(0,0);
             body.angularVelocity = 0;
             body.position = GameObject.Find("GameStart").GetComponent<GameManager>().PlayersPositions[Random.Range(0,Helper.numOfPlayers)];
         }
     }
}

