using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovTest : MonoBehaviour
{
    public float baseFov = 120f;
    public int baseRayCount = 50;
    public float baseViewDistance = 5f;
    public float baseAngle = 45f;
    private Mesh mesh;
    public LayerMask obstructionLayer;
    public LayerMask targetMask;
    private Vector3 origin;
    public Material baseMaterial;
    public Material triggeredMaterial;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }
    
    void LateUpdate()
    {
        float fov = baseFov;
        int rayCount = baseRayCount;
        float angle = baseAngle;
        float angleIncrease = fov / rayCount;
        float viewDistance = baseViewDistance;
        bool playerIsFound = false;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, obstructionLayer);
            RaycastHit2D raycastHit2DPlayer = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, targetMask);
            if (raycastHit2D.rigidbody == null)
            {
                if (raycastHit2DPlayer.rigidbody)
                    playerIsFound = true;
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                vertex = raycastHit2D.point;
            }
            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }
            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        if (playerIsFound)
            gameObject.GetComponent<MeshRenderer>().material = triggeredMaterial;
        else
            gameObject.GetComponent<MeshRenderer>().material = baseMaterial;
    }
    // Update is called once per frame


    private static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI/180f);
        Vector3 ret = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));

        return ret;
    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }
}
