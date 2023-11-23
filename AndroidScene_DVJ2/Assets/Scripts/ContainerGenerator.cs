using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ContainerGenerator : MonoBehaviour{
    [SerializeField]private GameObject containers;
    [SerializeField]private GameObject garbageGenerator;
    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private bool isPlaced;

    void Start(){
        isPlaced = false;
        raycastManager = FindObjectOfType<ARRaycastManager>();
        containers.SetActive(false);
    }

    void Update(){
        PlaceInScene();
        if(Input.touchCount>0 && !isPlaced || Input.GetKeyDown("space") && !isPlaced){
            isPlaced = true;
            StartCoroutine(PlaceContainers());
        }
    }

    void PlaceInScene(){
        var ray = new Vector2(Screen.width/2, Screen.height/2);
        if(raycastManager.Raycast(ray, hits, TrackableType.Planes)){
            Pose hitPose = hits[0].pose;
            transform.position = hitPose.position;
            transform.rotation = hitPose.rotation;
            if(!containers.activeInHierarchy){
                containers.SetActive(true);
            }
        }
    }

    IEnumerator PlaceContainers(){
        containers.transform.parent = null;
        yield return new WaitForSeconds(0.5f);
        garbageGenerator.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }
}
