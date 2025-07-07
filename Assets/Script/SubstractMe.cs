using Parabox.CSG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SubstractMe : MonoBehaviour
{
    MeshFilter showMesh;

    [SerializeField]
    private GameObject substractCube1;
    [SerializeField]
    private GameObject substractCube2;

    Mesh originalMesh;

    // Start is called before the first frame update
    void Start()
    {
        Model result = CSG.Subtract(this.gameObject, substractCube1);       //compute original cube mesh
        GetComponent<MeshFilter>().sharedMesh = result.mesh;
        RestPivotOffset();
        this.gameObject.transform.localScale = Vector3.one;
        
        originalMesh = GetComponent<MeshFilter>().sharedMesh;
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<MeshFilter>().sharedMesh = originalMesh;       //initialize the cube mesh

        Model result = CSG.Subtract(this.gameObject, substractCube2);       //compute the first substract
        GetComponent<MeshFilter>().sharedMesh = result.mesh;
        
        
        RestPivotOffset();
        this.gameObject.transform.localScale = Vector3.one;

        //return;
        result = CSG.Subtract(this.gameObject, substractCube1);         //compute the second substract
        GetComponent<MeshFilter>().sharedMesh = result.mesh;
        RestPivotOffset();
        this.gameObject.transform.localScale = Vector3.one;

    }

    void RestPivotOffset()      //Recalculate Pivot Position
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();

        Mesh mesh = meshFilter.mesh;
        Vector3[] vertices = mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] -= this.gameObject.transform.position;
        }
        mesh.vertices = vertices;
    }

}
