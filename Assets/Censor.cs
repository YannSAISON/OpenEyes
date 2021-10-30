using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Censor : MonoBehaviour
{
    public float distance;
    public float angle;
    public Material meshMaterial;
    public Material meshMaterialTriggered;
    public LayerMask layer;

    private FieldOfView fov;

    Mesh mesh;
    // Start is called before the first frame update
    void Start()
    {
        fov = gameObject.GetComponent<FieldOfView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mesh)
        {
            Material activeMat;

            if (fov.canSeePlayer)
                activeMat = meshMaterialTriggered;
            else
                activeMat = meshMaterial;
            //Graphics.color = meshColor;
            Graphics.DrawMesh(mesh, transform.position, transform.rotation, activeMat, layer);
        }
    }

    Mesh createMesh()
    {
        Mesh mesh = new Mesh();

        int numTriangles = 2;
        int numVertices = numTriangles * 3;

        Vector3[] vertices = new Vector3[numVertices];
        int[] triangles = new int[numVertices];

        Vector3 center = Vector3.zero;
        Vector3 bottom = Quaternion.Euler(0, 0, -angle / 2) * Vector3.right * distance;
        Vector3 top = Quaternion.Euler(0, 0, angle / 2) * Vector3.right * distance;
        Vector3 right = Vector3.right * distance;

        int vert = 0;

        vertices[vert++] = center;
        vertices[vert++] = top;
        vertices[vert++] = bottom;

        vertices[vert++] = top;
        vertices[vert++] = right;
        vertices[vert++] = bottom;

        for (int i = 0; i < numVertices; i++)
            triangles[i] = i;

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }

    private void OnValidate()
    {
        mesh = createMesh();
    }

    private void OnDrawGizmos()
    {

    }
}
