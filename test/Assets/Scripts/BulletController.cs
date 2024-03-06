using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField] private GameObject _player;
    //[SerializeField] PlayerController playerController;
    private float _speed = 150f;
    private Vector2 _diretion;
    void Start()
    {
        //_player = GameObject.FindWithTag("Player");
        //lấy hàm GetMousePosition từ script PlayerController từ Player
        Vector2 mousePosi = this._player.GetComponent<PlayerController>().GetMousePosition();
        
        //Debug.Log(mousePosi);
        
        // _diretion = mousePosi - (Vector2)Camera.main.ScreenToWorldPoint(_player.transform.position);
        _diretion = mousePosi - (Vector2)this._player.transform.position;
        
        _diretion.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_diretion * Time.deltaTime*_speed);
    }
}
