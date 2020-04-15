using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Rigidbody2D body;
    private SpriteRenderer sr;
    public Vector2 currentAngle;

    public float power;
    public int sign;
    public bool hit;
    public string hitter;

    public Color neutralColor;

    void Awake(){
        Physics2D.IgnoreCollision(GetComponent<CapsuleCollider2D>(), GameObject.Find("Block").GetComponent<BoxCollider2D>());
        body = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        hitter = "Nobody";
    }

    void Start(){
        neutralColor = sr.color;
    }

    // Update is called once per frame
    void Update(){
        ballHit();
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
        if (col.tag == "Ground"){
            if (this.transform.position.x < 0 && hitter == "Right"){
                    Helper.RightSidePoints += 1;
                    hitter = "Nobody";
                    sr.color = neutralColor;
            } else if (this.transform.position.x > 0 && hitter == "Left") {
                    Helper.LeftSidePoints += 1;
                    hitter = "Nobody";
                    sr.color = neutralColor;
            }
                       
        }
    } 

    //Called when the bomb is hit with a sword
    void ballHit(){
        if(hit){
            body.velocity = new Vector2(currentAngle.x * sign, currentAngle.y);
            StartCoroutine(stopBall());
        }
    }

    IEnumerator stopBall(){
         yield return new WaitForSeconds(0.1f);
         hit = false;
    }

}

