using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovTest : MonoBehaviour {
    public float baseFov = 120f;
    public int baseRayCount = 50;
    public float baseViewDistance = 5f;
    public float baseAngle = 45f;
    private Mesh m_Mesh;
    public LayerMask obstructionLayer;
    public LayerMask targetMask;
    private Vector3 m_Origin;
    public Material baseMaterial;
    public Material triggeredMaterial;

    private bool isPlayerSeen = false;

    // Start is called before the first frame update
    private void Start() {
        m_Mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = m_Mesh;
    }

    private void LateUpdate() {
        float fov = baseFov;
        int rayCount = baseRayCount;
        float angle = baseAngle;
        float angleIncrease = fov / rayCount;
        float viewDistance = baseViewDistance;
        isPlayerSeen = false;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];
        var draw_Origin = this.transform.parent.transform.position;

        vertices[0] = m_Origin - draw_Origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++) {
            Vector3 vertex;
            RaycastHit2D raycastHit2D =
                Physics2D.Raycast(m_Origin, GetVectorFromAngle(angle), viewDistance, obstructionLayer);
            RaycastHit2D raycastHit2DPlayer =
                Physics2D.Raycast(m_Origin, GetVectorFromAngle(angle), viewDistance, targetMask);
            if (raycastHit2D.rigidbody == null) {
                if (raycastHit2DPlayer.rigidbody)
                    isPlayerSeen = true;
                vertex = m_Origin + GetVectorFromAngle(angle) * viewDistance - draw_Origin;
            } else {
                if (raycastHit2DPlayer.rigidbody && (Vector3.Distance(m_Origin, raycastHit2D.point) > Vector3.Distance(m_Origin, raycastHit2DPlayer.point)))
                    isPlayerSeen = true;
                else if (!isPlayerSeen)
                    isPlayerSeen = false;
                vertex = raycastHit2D.point - new Vector2(draw_Origin.x, draw_Origin.y);
            }

            vertices[vertexIndex] = vertex;

            if (i > 0) {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }

        m_Mesh.vertices = vertices;
        m_Mesh.uv = uv;
        m_Mesh.triangles = triangles;
        m_Mesh.RecalculateBounds();
        if (isPlayerSeen)
            gameObject.GetComponent<MeshRenderer>().material = triggeredMaterial;
        else
            gameObject.GetComponent<MeshRenderer>().material = baseMaterial;
    }
    // Update is called once per frame

    public bool IsPlayerSeen()
    {
        return isPlayerSeen;
    }

    private static Vector3 GetVectorFromAngle(float angle) {
        float angleRad = angle * (Mathf.PI / 180f);
        Vector3 ret = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));

        return ret;
    }

    public void SetOrigin(Vector3 origin) {
        this.m_Origin = origin;
    }
}
