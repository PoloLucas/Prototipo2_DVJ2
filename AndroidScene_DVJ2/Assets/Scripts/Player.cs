using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    public int score;
    public int failures;
    [SerializeField]public int maxFailures;

    void Start(){
        score = 0;
        failures = 0;
        maxFailures = 3;
    }

    void Update(){
        CheckFailures();
    }

    void CheckFailures(){
        if(failures>=maxFailures){
            //cambio escena
        }
    }
}