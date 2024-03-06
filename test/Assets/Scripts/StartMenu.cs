using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _startMenu;

    public static bool isStartMenu;


void Start(){
    Time.timeScale = 0;
}
public void _start(){
    _startMenu.SetActive(false);
    Time.timeScale = 1;
     
}
}
