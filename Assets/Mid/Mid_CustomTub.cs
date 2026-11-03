using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Mid_CustomTub : MonoBehaviour
{
    [SerializeField] float width = 3f;   // x
    [SerializeField] float height = 2f;  // y
    [SerializeField] float depth = 0.8f; // z
    
    void Start()
    {
        Vector3[] vertices = new Vector3[]
        {

        };

        int[] triangles = new int[]
        {

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
