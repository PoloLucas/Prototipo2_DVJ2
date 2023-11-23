using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour{
    private Player player;
    private bool isColliding;

    void Start(){
        isColliding = false;
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Floor") && !isColliding){
            isColliding = true;
            player.failures+=1;
        }
    }
}