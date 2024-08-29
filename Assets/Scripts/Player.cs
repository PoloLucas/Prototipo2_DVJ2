using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour{
    public int score;
    public int failures;
    [SerializeField]public int maxFailures;

    void Start(){
        score = 0;
        failures = 0;
        maxFailures = 10;
    }

    void Update(){
        CheckScore();
        CheckFailures();
    }

    void CheckScore(){
        if(score<0){
            score = 0;
        }
    }

    void CheckFailures(){
        if(failures>=maxFailures){
            SceneManager.LoadScene(2);
        }
    }
}