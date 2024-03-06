using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering;


public class PlayerControlnler : MonoBehaviour
{
    // Start is called before the first frame update


    float _horizontalInput;
    private Rigidbody2D rb;

    private Animator anim;
    private float jump = 3f;

    private float speed = 10f;

    private SkillPlayer Sk;

    static bool isRight = true;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 50f;
    private float dashingTime = 0.1f;
    private float dashingCooldown = 0f;




    [SerializeField] GameObject _player;
    [SerializeField] private TrailRenderer tr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Sk = GetComponent<SkillPlayer>();

        //_player.SetActive(true);
    }
     public bool getIsRight()
     {
        return isRight;
     }

    void Update(){

        if(isDashing)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
        Sk.tele();
        if(Input.GetKeyDown(KeyCode.M) && canDash)
        {
            StartCoroutine(Dash());
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }
        _horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(_horizontalInput, rb.velocity.y);
        rb.velocity.Normalize();
        transform.Translate(rb.velocity * Time.deltaTime * speed);
        flip();
        anim.SetFloat("Walk" ,Mathf.Abs(_horizontalInput));

    }

    void flip()
    {
        if(isRight && _horizontalInput < 0 || !isRight && _horizontalInput > 0)
        {
            isRight = !isRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;

        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;

    }

    
}
