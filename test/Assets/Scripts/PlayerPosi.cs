using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerPosi : MonoBehaviour
{
    // Start is called before the first frame update
    float PlayerPositionx;
    float PlayerPositiony;
    List<GameObject> killers;
    [SerializeField] private GameObject killerPrefab;


    void Start(){
        this.killers = new List<GameObject>();
    
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPositionx = transform.position.x;
        PlayerPositiony = transform.position.y;
        //float checkpointx = 6;
        // int checkpointy = 6;
        //if(PlayerPositionx >= checkpointx) this.check1();
        this.check1();
        //else this.check2();
        this.checkKillerDead();
    }

    void check1(){
        Debug.Log("da luu");
        if(this.killers.Count >= 1) return;
        // int order = this.killers.Count + 1;
         GameObject killer = Instantiate(this.killerPrefab);
        //  new GameObject("killer" + order);
         //killer.AddComponent<Enemy>();
        killer.name = "killer" ;
        //killer.transform.position = transform.position; 
        killer.gameObject.SetActive(true);
        this.killers.Add(killer);
        

    }
    void checkKillerDead(){
        GameObject killer;
        for(int i=0; i<this.killers.Count ; i++){
            killer = this.killers[i];
            if(killer == null) this.killers.RemoveAt(i);
        }
    }
    
    void check2(){
        Debug.Log("chu luu");
    }
}

