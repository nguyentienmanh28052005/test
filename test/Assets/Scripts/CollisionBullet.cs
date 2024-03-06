using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBullet : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D order){
        if(order.gameObject.tag == "Enemy") Destroy(gameObject);
        if(order.gameObject.tag == "GameController") Destroy(gameObject);
        if(order.gameObject.tag == "map") Destroy(gameObject);

    }
}
