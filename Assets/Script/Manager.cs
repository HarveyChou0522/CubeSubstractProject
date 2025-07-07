using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    bool isRotating;
    bool isScaleing;

    GameObject selectedObject;

    [SerializeField]
    private List<GameObject> objs;

    Vector3 mouseOriginal = Vector3.zero;
    float mousePos = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(isRotating || isScaleing)
            {
                isRotating = false;
                isScaleing = false;
            }
            else
            {
                foreach (GameObject obj in objs)
                {
                    obj.GetComponent<Outline>().enabled = false;
                }
            }
                
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("yes" + hit.collider.gameObject.name);

                selectedObject = hit.collider.gameObject;

                selectedObject.GetComponent<Outline>().enabled = true;

            }
            else
            {
                selectedObject = null;
            }
        }

        if (selectedObject != null)
        {
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                isRotating = true;
                isScaleing = false;

                mousePos = 0f;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                isRotating = false;
                isScaleing = true;

                mousePos = 1f;
            }

            //Debug.Log(Vector3.Distance(mouseOriginal, Input.mousePosition));

            if (isRotating)
            {
                float value = Input.GetAxisRaw("Mouse X") * Time.deltaTime * 600f;
                mousePos += value;

                selectedObject.transform.rotation = Quaternion.Euler(0, selectedObject.transform.rotation.y + mousePos, 0);
            }
            if (isScaleing)
            {
                float value = Input.GetAxisRaw("Mouse X") * Time.deltaTime * 300f;
                mousePos += value;

                selectedObject.transform.localScale = Mathf.Max(0.1f , mousePos) * Vector3.one ;
            }

            //Input.mousePosition.
        } 
    }
}
