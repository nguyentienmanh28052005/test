using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _item;
    


    private void OnCollisionEnter2D(Collision2D order){
        if(order.gameObject.tag == "Player")
        {
           _item.gameObject.SetActive(true);
           _item.transform.position = _player.transform.position; 
           gameObject.SetActive(false);
        }


    }
}
