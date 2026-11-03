using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Mid_CustomStair : MonoBehaviour
{
    [SerializeField] int stepCount = 3;
    [SerializeField] float stepWidth = 1f;    // x
    [SerializeField] float stepHeight = 0.2f; // y
    [SerializeField] float stepDepth = 0.3f;  // z
    
    void Start()
    {
        Vector3[] vertices = new Vector3[]
        {

        };

        int[] triangles = new int[]
        {

        };

        for(int i = 0; i < stepCount; i++)
        {

        }

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
        if (GetComponent<MeshRenderer>().sharedMaterial == null)
            GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
    }
}
