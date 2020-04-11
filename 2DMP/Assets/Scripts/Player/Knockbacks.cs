using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockbacks : MonoBehaviour
{

    private Rigidbody2D myBody;

    public bool knockedBack;
    public float knockedBackFactor;
    public int sign = 0;
    public Vector2 currentKnockback;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(knockedBack)
            Knockback(currentKnockback, sign);   
        
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
