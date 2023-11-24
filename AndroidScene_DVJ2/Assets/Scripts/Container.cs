using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour{
    [SerializeField]private int containerType=0;
    private string garbageType;
    private Player player;
    private UI ui;
    
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
        switch(containerType){
            case 1:{
                garbageType = "Orgánicos";
                break;
            }
            case 2:{
                garbageType = "Cartón";
                break;
            }
            case 3:{
                garbageType = "Metal";
                break;
            }
            case 4:{
                garbageType = "Vidrio";
                break;
            }
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag(garbageType)){
            player.score+=10;
            ui.catState = 1;
        }else{
            player.failures++;
            ui.catState = 2;
        }
        Destroy(other.gameObject);
    }
}
