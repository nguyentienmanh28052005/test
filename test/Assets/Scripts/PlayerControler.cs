using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    private Rigidbody2D rb;
    private Animator anim;

    private float _horizontalInput;
    private float _verticalInput;
    private Vector2 _mousePosi;

    private bool isfacingRight = true;
    [SerializeField] private GameObject _bulletPrefab;

    [SerializeField] Dissolve _dissolve;


    
void Start(){
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    transform.position = new Vector3(-30, -5.9f, 0);
    StartCoroutine(_dissolve.Appear(true, false));
}





public int _speed(){
    return speed;
}
private void Update()
    {
        //Mỗi khi nhấn chuột trái\
        // if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1) Time.timeScale = 0;
        // else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0) Time.timeScale = 1;
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
void FixedUpdate(){
    _horizontalInput = Input.GetAxis("Horizontal");
    //_verticalInput = Input.GetAxis("Vertical");
    // if(Input.GetKeyDown(KeyCode.Space))
    // {
    //     transform.Translate(new Vector2(0, 10f)*Time.deltaTime);
    // }
    rb.velocity = new Vector2(_horizontalInput, rb.velocity.y);
    rb.velocity.Normalize();
    transform.Translate(rb.velocity * Time.deltaTime * speed);

    // Vector2 direction = new Vector2(_horizontalInput, _verticalInput);
    //     direction.Normalize();
        
    //     transform.Translate(direction * Time.deltaTime * _speed);

    flip();
    anim.SetFloat("move", Mathf.Abs(_horizontalInput));
    anim.SetFloat("jump", rb.velocity.y);


}

void flip(){
    if(isfacingRight && _horizontalInput < 0 || !isfacingRight && _horizontalInput > 0){
        isfacingRight = !isfacingRight;
        Vector3 kich_thuoc = transform.localScale;
        kich_thuoc.x = -1 * kich_thuoc.x;
        transform.localScale = kich_thuoc;
        
    }
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
 
