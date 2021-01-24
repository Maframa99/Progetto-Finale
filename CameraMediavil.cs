using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMediavil : MonoBehaviour
{
    private float speed = 2.0f;
    private Cinemachine.CinemachineVirtualCamera camera;
    private Cinemachine.CinemachineTrackedDolly trackedDolly;
    private float speedZoom = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        camera = this.GetComponent<Cinemachine.CinemachineVirtualCamera>();
        trackedDolly = camera.GetCinemachineComponent<Cinemachine.CinemachineTrackedDolly>();
    }

    // Update is called once per frame
    void Update()
    {
        //premendo tasto destro
        if (Input.GetButton("Fire2"))
        {
            //movimento camera su binario
            if (Input.GetAxis("Mouse X") != 0)
            {
                trackedDolly.m_PathPosition += speed *Input.GetAxis("Mouse X");               
            }

            //zoom camera con rotella
            if (Input.mouseScrollDelta.y != 0)
            {               
                camera.m_Lens.FieldOfView += speedZoom * Input.mouseScrollDelta.y * -1;
            }
        }

        
    }

    /*void OnGui()
    {
        float max, min;
        max = 150.0f;
        min = 20.0f;
        //This Slider changes the field of view of the Camera between the minimum and maximum values
        fieldOfView = GUI.HorizontalSlider(new Rect(20, 20, 100, 40), fieldOfView, min, max);
    }*/
}
