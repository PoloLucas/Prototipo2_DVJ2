using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour{
    private Player player;
    private UI ui;
    private bool isColliding;

    void Start(){
        isColliding = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Floor") && !isColliding){
            isColliding = true;
            player.failures++;
            ui.catState = 2;
        }
    }
}