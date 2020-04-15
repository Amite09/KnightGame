using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    private float speed = 10f;
    private bool canMove = true;
    public float power;
    private string owner;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisableFlame(5f));
    }


    void FixedUpdate(){
        if (canMove)
            Move();
    }


    void Move() {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
    }

    public float Speed {
        get {
            return speed;
        }
        set {
            speed = value;
        }
    }

    public float Power {
        get {
            return power;
        }
        set {
            power = value;
        }
    }

    public string Owner {
        get {
            return owner;
        }
        set {
            owner = value;
        }
    }

    IEnumerator DisableFlame(float timer) {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive (false);
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "Ground" || col.tag == "Block"){
            gameObject.SetActive(false);
            return;
        } else if (col.transform.root.TryGetComponent(out Shuriken s) && s.Owner != this.owner){
            s.gameObject.SetActive(false);
        }
        string colName = col.transform.root.name;
        float damage = Random.Range(5,6) * this.power;
        if(col.transform.root.TryGetComponent(out Knight enemy) && colName != this.owner){
            enemy.GetComponent<PlayerHealth>().applyDamage(damage);
            gameObject.SetActive(false);
        }        

    }

}
