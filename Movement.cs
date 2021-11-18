using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;
    AudioSource audS;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotateSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }


    void ProcessInput()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessRotation(){
        if((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            &&
            (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))){
                //Debug.Log("Do nothing");
            }else 
            if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //Debug.Log("Turning left");
            ApplyRotation(rotateSpeed);
        }
        else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
            //Debug.Log("Turning right");
            ApplyRotation(-rotateSpeed);
        }
    }

    void ApplyRotation(float direction)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * direction * Time.deltaTime);
        rb.freezeRotation = false;
    }

    void ProcessThrust(){
        if(Input.GetKey(KeyCode.Space)){
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if(!audS.isPlaying){
                audS.Play();
            }
        } else {
            audS.Pause();
        }

        // if(Input.GetKey(KeyCode.Space)){
        //     rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        // }
        // if(Input.GetKeyDown(KeyCode.Space)){
        //     audS.Play();
        // }
        // if(Input.GetKeyUp(KeyCode.Space)){
        //     audS.Pause();
        // }
    }
}