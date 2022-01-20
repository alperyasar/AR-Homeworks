using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class RubikCubeLocation : MonoBehaviour
{
    private ARRaycastManager rayManager;
    private GameObject visual;
    public GameObject eagle;
    public GameObject rubiks;
    //  bool hit = true;

    private void Start()
    {
        // get the componets
        rayManager = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject;
        visual.SetActive(false);

    }

    private void Update()
    {
        // shoot a raycast from the center of the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);
        // if we hit an AR plane, update the position and rotation
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {        
            
            GameObject rubik1 = Instantiate(rubiks, transform.position, rubiks.transform.rotation);
            
            GameObject eagle1 = Instantiate(eagle, new Vector3(transform.position.x, transform.position.y + 0.0236f, transform.position.z), eagle.transform.rotation);
            
            rubik1.SetActive(true);
            eagle1.SetActive(true);
            GameObject.Find("ring").SetActive(false);
        }

        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
   //         transform.rotation = hits[0].pose.rotation;
            if (!visual.activeInHierarchy)
                visual.SetActive(true);
            visual.GetComponent<Animation>().Play("Take 001");


        }
    }
}
/*
    kartalý küp üzerine konumlandýrmak için
    
    küp konumu + küpün boyutu * 0,612
 */