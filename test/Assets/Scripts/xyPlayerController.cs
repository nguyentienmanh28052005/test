using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class xyPlayerController : MonoBehaviour
{
    private float _horizontalInput, _verticalInput;
    private float _speed = 8f;
    private Vector2 _mousePosi;


    [SerializeField] private GameObject _bulletPrefab;

    // Update is called once per frame
    //Screen Space, World Space

    private void Update()
    {
        //Mỗi khi nhấn chuột trái
        if (Input.GetMouseButtonDown(1))
        {
            //Bắn ra 1 viên đạn
            GameObject bullet =  Instantiate(this._bulletPrefab, transform.position, transform.rotation);
             bullet.gameObject.SetActive(true);
            
            //Input.mousePosition: trả về vị trí của chuột trong Screen Space
            //ScreenToWorldPoint: chuyển tọa độ từ Screen Space sang World Space
            _mousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }

    }

    public Vector2 GetMousePosition()
    {
        return _mousePosi;
    }

    void FixedUpdate()
    {
        _horizontalInput = Input.GetAxis("Horizontal"); 
        _verticalInput = Input.GetAxis("Vertical");
        
        Vector2 direction = new Vector2(_horizontalInput, _verticalInput);
        direction.Normalize();
        
        transform.Translate(direction * Time.deltaTime * _speed);
        
        
    }
}
    
    
    
//     public void Movement1()
//     {
//         if (Input.GetKeyDown(KeyCode.RightArrow))
//         {
//             //player di chuyen sang bên phải 1 đoạn 4 đơn vị
//             transform.Translate(new Vector2(4f, 0f));
//         }
//         else if (Input.GetKeyDown(KeyCode.LeftArrow))
//         {
            
//             transform.Translate(new Vector2(-4f, 0f));
//         }
//         else if (Input.GetKeyDown(KeyCode.UpArrow))
//         {
//             transform.Translate(new Vector2(0f, 3f));
//         }
//         else if (Input.GetKeyDown(KeyCode.DownArrow))
//         {
//             transform.Translate(new Vector2(0f, -3f));
//         }
//     }

//     public void Movement2()
//     {
//         if (Input.GetKey(KeyCode.RightArrow))
//         {
//             //player di chuyen sang bên phải 1 đoạn 4 đơn vị
//             transform.Translate(new Vector2(4f, 0f) * Time.deltaTime);
        
//         }
//         else if (Input.GetKey(KeyCode.LeftArrow))
//         {
            
//             transform.Translate(new Vector2(-4f, 0f) * Time.deltaTime);
            
//         }
        
//         if (Input.GetKey(KeyCode.UpArrow))
//         {
//             transform.Translate(new Vector2(0f, 3f) * Time.deltaTime);
        
//         }
//         else if (Input.GetKey(KeyCode.DownArrow))
//         {
//             transform.Translate(new Vector2(0f, -3f) * Time.deltaTime);
//         }
//     }
// }
