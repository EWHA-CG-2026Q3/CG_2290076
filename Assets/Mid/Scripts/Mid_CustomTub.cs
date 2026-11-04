using UnityEngine;
using System.Collections.Generic;

[ExecuteAlways]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Mid_CustomTub : MonoBehaviour
{
    [SerializeField] float width = 1.8f;   // x
    [SerializeField] float depth = 1.4f; // z
    [SerializeField] float height = 0.6f;  // y

    List<Vector3> verts = new List<Vector3>();
    List<int> tris = new List<int>();
    
    void Start()
    {  
        verts.Clear();
        tris.Clear();

        float w = width / 2f;
        float d = depth / 2f;
        float h = height;

        // 바닥 네 점
        Vector3 p0 = new Vector3(-w, 0, -d);
        Vector3 p1 = new Vector3(w, 0, -d);
        Vector3 p2 = new Vector3(w, 0, d);
        Vector3 p3 = new Vector3(-w, 0, d);

        // 윗 면 네 점
        Vector3 p4 = new Vector3(-w, h, -d);
        Vector3 p5 = new Vector3(w, h, -d);
        Vector3 p6 = new Vector3(w, h, d);
        Vector3 p7 = new Vector3(-w, h, d);

        AddQuad(p0, p4, p5, p1); // 앞
        AddQuad(p2, p6, p7, p3); // 뒤
        AddQuad(p3, p7, p4, p0); // 왼쪽
        AddQuad(p1, p5, p6, p2); // 오른쪽
        AddQuad(p0, p1, p2, p3); // 바닥

        Mesh mesh = new Mesh();
        mesh.vertices = verts.ToArray();
        mesh.triangles = tris.ToArray();
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
        if (GetComponent<MeshRenderer>().sharedMaterial == null)
            GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
    }

    void AddQuad(Vector3 v0, Vector3 v1, Vector3 v2, Vector3 v3)
    {
        int i = verts.Count;
        verts.Add(v0); verts.Add(v1); verts.Add(v2); verts.Add(v3);
        tris.Add(i); tris.Add(i + 1); tris.Add(i + 2);
        tris.Add(i); tris.Add(i + 2); tris.Add(i + 3);
    
        i = verts.Count;
        verts.Add(v0); verts.Add(v1); verts.Add(v2); verts.Add(v3);
        tris.Add(i); tris.Add(i + 2); tris.Add(i + 1);
        tris.Add(i); tris.Add(i + 3); tris.Add(i + 2);
    }
}
