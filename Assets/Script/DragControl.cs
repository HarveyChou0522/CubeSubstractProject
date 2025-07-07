using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragControl : MonoBehaviour
{
    private Plane dragPlane;
    private Vector3 offset;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void OnMouseDown()
    {
        dragPlane = new Plane(Vector3.up, transform.position);

        
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        float distance;

        if (dragPlane.Raycast(ray, out distance))
        {
            offset = transform.position - ray.GetPoint(distance);
        }

        
    }

    private void OnMouseDrag()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        float distance;

        if (dragPlane.Raycast(ray, out distance))
        {
            Vector3 point = ray.GetPoint(distance);
            transform.position = point + offset;
        }
    }

    
}
