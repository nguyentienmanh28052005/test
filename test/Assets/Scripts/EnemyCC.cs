using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyCC : MonoBehaviour
{
    // Start is called before the first frame update
    int cnt = 0;
    Rigidbody2D rb;

    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D order){
        if(order.gameObject.tag == "Player") Destroy(gameObject);
        if(order.gameObject.tag == "Bullet")
        {
            // cnt++;
            anim.SetTrigger("death");
            Invoke("Death", 0.5f);
            
        } 
        
    }
    private void OnTriggerEnter2D(Collider2D order){
        if(order.gameObject.tag == "Player") Destroy(gameObject);
        if(order.gameObject.tag == "Bullet")
        {
           // cnt++;
           anim.SetTrigger("death");
           Invoke("Death", 0.3f);
        } 
        if(order.gameObject.tag == "map")
            {
                rb.velocity = new Vector2(rb.velocity.x, 6f);
            }
    } 


    void Death(){
        Destroy(gameObject);
    }
}
