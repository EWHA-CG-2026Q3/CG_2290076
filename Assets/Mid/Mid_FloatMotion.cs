using UnityEngine;

public class Mid_FloatMotion : MonoBehaviour
{
    [SerializeField] float Height = 0.05f;  // 위 아래 출렁임 크기
    [SerializeField] float Speed = 1.5f;
    [SerializeField] float spinSpeed = 20f; // 초당 회전 각도

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {

    }
}