using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Diamond : MonoBehaviour
{
    void Start()
    {
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0f, 0f, 0f),
            new Vector3(1f, 0f, 0f),
            new Vector3(1f, 0f, 1f),
            new Vector3(0f, 0f, 1f),
            new Vector3(0.5f, 1f, 0.5f),
            new Vector3(0.5f, -1f, 0.5f)
        };

        int[] triangles = new int[]
        {
            4, 1, 0,
            4, 2, 1,
            4, 3, 2,
            4, 0, 3,

            5, 0, 1,
            5, 1, 2,
            5, 2, 3,
            5, 3, 0
        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
        if (GetComponent<MeshRenderer>().sharedMaterial == null)
            GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
    }
}