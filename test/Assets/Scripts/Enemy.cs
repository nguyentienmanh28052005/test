using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private float _speed = 4f;
    // Update is called once per frame
    void Update()
    {
        //Lấy tọa độ của player theo thời gian thực 
        Vector3 playerPosi = _player.transform.position;
        
        // Vector hướng từ vị trí enemy tới vị trí player
        Vector3 direction = playerPosi - transform.position;
        
        direction.Normalize();
        
        transform.Translate(direction * _speed * Time.deltaTime);
        // cout << "Hello World";
    }
}

