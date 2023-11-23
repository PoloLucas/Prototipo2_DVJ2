using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour{
    [SerializeField]private int containerType=0;
    private string garbageType;
    private Player player;
    
    void Start(){
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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
        }else{
            player.score-=10;
        }
        Destroy(other.gameObject);
    }
}
