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

    private Vector3 dragOrigin;

    [SerializeField] private Camera cam;
    [SerializeField] private SpriteRenderer mapRender;

    private float mapMinX, mapMaxX,mapMinY,mapMaxY;

    void Awake()
    {
        mapMinX= mapRender.transform.position.x-mapRender.bounds.size.x /2f;
        mapMaxX= mapRender.transform.position.x+mapRender.bounds.size.x /2f;

        mapMinY= mapRender.transform.position.y-mapRender.bounds.size.y /2f;
        mapMaxY= mapRender.transform.position.y+mapRender.bounds.size.y /2f;

    }

    void Start()
    {
        zoom=cam.orthographicSize;     
    }


    void Update()
    {
        if(gameController.instance.TimerOn){
            MoveCamera();
            zoom=Mathf.Clamp(zoom, minZoom, maxZoom);
            cam.orthographicSize=Mathf.SmoothDamp(cam.orthographicSize,zoom, ref velocity, smoothTime);
        }
        
    }

    private void MoveCamera()
    {
        if(Input.GetMouseButtonDown(1))
            dragOrigin=cam.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetMouseButton(1))
        {
            Vector3 difference=dragOrigin-cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position=ClampCamera(cam.transform.position+difference);
        }
    }

    public void ZoomIn(){
        zoom-=scroll*zoomMultiplier;
        cam.transform.position=ClampCamera(cam.transform.position);
    }

    public void ZoomOut(){
        zoom+=scroll*zoomMultiplier;
        cam.transform.position=ClampCamera(cam.transform.position);
    }

    private Vector3 ClampCamera(Vector3 targetPos)
    {
        float camHeight=cam.orthographicSize;
        float camWidth=cam.orthographicSize*cam.aspect;

        float minX= mapMinX+camWidth;
        float maxX= mapMaxX-camWidth; 
        float minY= mapMinY+camHeight; 
        float maxY= mapMaxY-camHeight;

        float newX=Mathf.Clamp(targetPos.x,minX,maxX);
        float newY=Mathf.Clamp(targetPos.y,minY,maxY);

        return new Vector3(newX,newY,targetPos.z);
    }
}
