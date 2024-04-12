using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private float zoom;
    private float zoomMultiplier=4f;
    private float minZoom=4f;
    private float maxZoom=8f;
    private float velocity=0f;
    private float smoothTime=0.25f; 
    float scroll=1f;  

    [SerializeField] private Camera cam;

    void Start()
    {
        zoom=cam.orthographicSize;     
    }


    void Update()
    {
        zoom=Mathf.Clamp(zoom, minZoom, maxZoom);
        cam.orthographicSize=Mathf.SmoothDamp(cam.orthographicSize,zoom, ref velocity, smoothTime);
        
    }

    public void ZoomIn(){
        zoom-=scroll*zoomMultiplier;
    }

    public void ZoomOut(){
        zoom+=scroll*zoomMultiplier;
    }
}
