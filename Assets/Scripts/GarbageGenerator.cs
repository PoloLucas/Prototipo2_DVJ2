using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageGenerator : MonoBehaviour{
    [SerializeField]private GameObject[] garbage;
    private GameObject currentGarbage;
    private Rigidbody body;
    private bool isThrowing;
    private float throwForce = 5f;

    void Start(){
        isThrowing = false;
        currentGarbage = Instantiate(garbage[Random.Range(0,garbage.Length)], transform);
        currentGarbage.transform.localScale/=5;
        body = currentGarbage.GetComponent<Rigidbody>();
    }

    void Update(){
        if(Input.touchCount>0 && !isThrowing || Input.GetKeyDown("space") && !isThrowing){
            isThrowing = true;
            StartCoroutine(ThrowObject());
        }
    }

    IEnumerator ThrowObject(){
        currentGarbage.transform.localScale*=5;
        currentGarbage.transform.parent = null;
        body.isKinematic = false;
        body.AddForce(transform.up*throwForce/2, ForceMode.Impulse);
        body.AddForce(transform.forward*throwForce, ForceMode.Impulse);
        yield return new WaitForSeconds(0.5f);
        currentGarbage = Instantiate(garbage[Random.Range(0,garbage.Length)], transform);
        currentGarbage.transform.localScale/=5;
        body = currentGarbage.GetComponent<Rigidbody>();
        yield return new WaitForSeconds(0.2f);
        isThrowing = false;
    }
}