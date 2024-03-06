using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class SkillPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject _player;

    [SerializeField] Dissolvex _diss;


    bool _isRight;


    void Start()
    {
    }

    public void tele()
    {
        _isRight = _player.GetComponent<PlayerControlnler>().getIsRight();
        if(Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log(_isRight);
            if(_isRight)
            {
                Vector3 telep = _player.transform.position;
                telep.x += 15f;
                //Invoke("_diss.Vanis(false, true)", 2f);
                transform.position = telep;
                StartCoroutine(_diss.Appear(true, false));
                //Invoke("_diss.Vanis(true, false)", 1);
            }
            else
            {
                Vector3 telep = _player.transform.position;
                telep.x -= 15f;
                transform.position = telep;
                StartCoroutine(_diss.Appear(true, false));
            }
        }
    }
}
