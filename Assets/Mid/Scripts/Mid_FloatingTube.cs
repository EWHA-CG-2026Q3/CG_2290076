using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(MeshFilter))]
public class Mid_FloatingTube : MonoBehaviour
{
    const float bobHeight = 0.03f;
    const float bobSpeed = 1.5f;
    const float driftRadius = 0.15f;
    const float driftSpeed = 0.3f;
    const float spinSpeed = 30f;
    const float tiltAngle = 5f;

    [SerializeField, HideInInspector] Mesh sourceMesh;

    Mesh mesh;
    Vector3[] baseVertices;
    Vector3[] baseNormals;

    void Start()
    {
        MeshFilter mf = GetComponent<MeshFilter>();

        if (sourceMesh == null) sourceMesh = mf.sharedMesh;
        if (sourceMesh == null) return;
 
        mesh = Instantiate(sourceMesh);
        mesh.name = sourceMesh.name + "_Float";
        mesh.hideFlags = HideFlags.DontSave;
        mf.sharedMesh = mesh;
 
        baseVertices = sourceMesh.vertices;
        baseNormals = sourceMesh.normals;
 
        ApplyPose(0f);
    }

    void Update()
    {
        ApplyPose(Time.time);
    }

    void ApplyPose(float t)
    {
        if(mesh == null || baseVertices == null) return;
        
        float bob = Mathf.Sin(t * bobSpeed) * bobHeight;
        float driftX = Mathf.Cos(t * driftSpeed) * driftRadius;
        float driftZ = Mathf.Sin(t * driftSpeed) * driftRadius;
        float spin = t * spinSpeed;
        float tilt = Mathf.Sin(t * bobSpeed * 0.7f) * tiltAngle;

        Vector3 scale = transform.localScale;
        Matrix4x4 S = ScaleMatrix(scale);
        Matrix4x4 Sinv = ScaleMatrix(new Vector3(1f / scale.x, 1f / scale.y, 1f / scale.z));
        Matrix4x4 Rz = RotateZMatrix(tilt);
        Matrix4x4 Ry = RotateYMatrix(spin);
        Matrix4x4 T = TranslateMatrix(new Vector3(driftX, bob, driftZ));
        Matrix4x4 M = Sinv * T * Ry * Rz * S;

        Vector3[] verts = new Vector3[baseVertices.Length];
        Vector3[] normals = new Vector3[baseNormals.Length];
        Matrix4x4 R = S * Ry * Rz * Sinv;
        for(int i = 0; i < baseVertices.Length; i++)
        {
            verts[i] = M.MultiplyPoint3x4(baseVertices[i]);
            normals[i] = R.MultiplyVector(baseNormals[i]);
        }

        mesh.vertices = verts;
        mesh.normals = normals;
        mesh.RecalculateBounds();
    }

    Matrix4x4 TranslateMatrix(Vector3 p)
    {
        Matrix4x4 m = Matrix4x4.identity;
        m.m03 = p.x;
        m.m13 = p.y;
        m.m23 = p.z;
        return m;
    }

    Matrix4x4 ScaleMatrix(Vector3 s)
    {
        Matrix4x4 m = Matrix4x4.identity;
        m.m00 = s.x;
        m.m11 = s.y;
        m.m22 = s.z;
        return m;
    }

    Matrix4x4 RotateYMatrix(float degrees)
    {
        float r = degrees * Mathf.Deg2Rad;
        float c = Mathf.Cos(r), s = Mathf.Sin(r);
        Matrix4x4 m = Matrix4x4.identity;
        m.m00 = c; m.m02 = s;
        m.m20 = -s; m.m22 = c;
        return m;
    }

    Matrix4x4 RotateZMatrix(float degrees)
    {
        float r = degrees * Mathf.Deg2Rad;
        float c = Mathf.Cos(r), s = Mathf.Sin(r);
        Matrix4x4 m = Matrix4x4.identity;
        m.m00 = c; m.m01 = -s;
        m.m10 = s; m.m11 = c;
        return m;
    }
}