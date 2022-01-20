using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class EagleOnClick : MonoBehaviour
{

    private int controlNumber = 0;
    private Animator animator;
    public TMP_Text text;


    // Update is called once per frame
    private void Start()
    {
        animator = GetComponent<Animator>();
        
        

    }
    void Update()
    {
        animator.SetBool("RiseOn", false);
        animator.SetBool("Hit", false);


        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                int temp = controlNumber;
                controlNumber++;
                switch (temp)
                {
                    case 0: animator.SetBool("RiseOn", true);
                        transform.GetChild(1).localPosition = new Vector3(-1.293515e-09f, 1.31f, 0.04790619f);
                        break;
                    case 6:
                        animator.SetBool("Die", true);
                        text.text = "Eagle Died!";
                        StartCoroutine(ExampleCoroutine());
                        
                        break;
                    default:
                        animator.SetBool("Hit", true);
                        text.text = "Eagle Hit! " + (controlNumber-1);
                        StartCoroutine(Wait2Seconds());
                        break;
                }
            }
            
        }
    }
    IEnumerator ExampleCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MainScene");
    }
    IEnumerator Wait2Seconds()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);
    }
}
