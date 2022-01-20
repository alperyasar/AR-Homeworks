using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class RubikCubeLocation1 : MonoBehaviour
{
    private ARRaycastManager rayManager;
    public GameObject rubiks;
    bool hit = true;

    private void Start()
    {
     //   temp.transform.localScale = rubiks.transform.localScale;
        // get the componets
        rayManager = FindObjectOfType<ARRaycastManager>();

   //     StartCoroutine(HandleIt());

    }

    private void Update()
    {
        // shoot a raycast from the center of the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);
        // if we hit an AR plane, update the position and rotation


        if (hits.Count > 0 && hit)
        {
            rubiks.transform.position = hits[0].pose.position;
            rubiks.transform.rotation = hits[0].pose.rotation;
            if (!rubiks.activeInHierarchy)
                rubiks.SetActive(true);
            hit = false;
        }
    }

}
