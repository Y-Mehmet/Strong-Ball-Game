﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotateSpeed=10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateCam();
    }
   void RotateCam(){
    float horInput=Input.GetAxis("Horizontal");
    transform.Rotate(Vector3.up*horInput*rotateSpeed*Time.deltaTime);
   }
   }