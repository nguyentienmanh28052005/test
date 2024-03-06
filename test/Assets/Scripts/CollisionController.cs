using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public PlayerHealth _playerheart;



    private Animator anim;
    bool check;






    void Start(){
        anim = GetComponent<Animator>();
        anim.SetBool("start", true);
        Invoke("_falseStart", 1);

    }

    private void OnCollisionEnter2D(Collision2D other){
    // check = true;
        if(other.gameObject.tag == "Enemy"){
            anim.SetBool("bleed", true);
            Invoke("_falseBleed", 0.5f);
            _playerheart.TakeDamage(1);        
        }
    }

void _falseBleed(){
    anim.SetBool("bleed", false);
}
void _falseStart(){
    anim.SetBool("start", false);
}


}
