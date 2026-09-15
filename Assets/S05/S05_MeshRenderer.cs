using UnityEngine;
using UnityEngine.UI;

public class S05_MyMeshRenderer : MonoBehaviour
{
    [SerializeField] private int canvasWidth = 256;
    [SerializeField] private int canvasHeight = 256;
    [SerializeField] private Color backgroundColor = new Color(0f, 0f, 0f, 1f);

    [Header("무늬 실습 (줄무늬·체스판 공용)")]
    [SerializeField] private int patternSize = 16;
    [SerializeField] private Color colorA = new Color(1f, 1f, 1f, 1f);
    [SerializeField] private Color colorB = new Color(0.3f, 0.5f, 0.8f, 1f);

    private Texture2D canvasTexture;
    private RawImage targetImage;

    void Start()
    {
        targetImage = GetComponent<RawImage>();

        // 1. 빈 캔버스(Texture2D) 생성
        canvasTexture = new Texture2D(canvasWidth, canvasHeight);

        // 2. 픽셀 경계를 흐리지 않게
        canvasTexture.filterMode = FilterMode.Point;

        // 3. 픽셀 채우기 
        FillVerticalStripes(patternSize, colorA, colorB); // 실습①
        // FillCheckerboard(patternSize, colorA, colorB); // 실습②

        // 4. 변경 사항 반영
        canvasTexture.Apply();

        // 5. 화면에 표시
        targetImage.texture = canvasTexture;
    }

    // 실습① — 세로 줄무늬. 반복문 구조는 주어져 있습니다. 조건식 한 줄만 채우세요.
    private void FillVerticalStripes(int width, Color colorA, Color colorB)
    {
        for (int x = 0; x < canvasWidth; x++)
        {
            // TODO: x를 width로 나눈 몫이 짝수면 colorA, 홀수면 colorB가 되도록
            // isColorA를 올바른 조건식으로 바꾸세요.
            // 힌트: (x / width) % 2 == 0
            bool isColorA = true; // ← 이 줄을 수정하세요

            Color stripeColor = isColorA ? colorA : colorB;
            for (int y = 0; y < canvasHeight; y++)
                canvasTexture.SetPixel(x, y, stripeColor);
        }
    }

    // 실습② — 체스판 무늬. 이번에는 반복문 뼈대만 주어집니다.
    // 위에서 만든 줄무늬 조건을 x, y 둘 다에 적용하는 방식으로 직접 확장해보세요.
    private void FillCheckerboard(int size, Color colorA, Color colorB)
    {
        for (int x = 0; x < canvasWidth; x++)
        {
            for (int y = 0; y < canvasHeight; y++)
            {
                // TODO: 줄무늬는 x만 봤지만, 체스판은 x와 y를 함께 고려해야 합니다.
                // 힌트: (x / size) + (y / size) 의 결과를 활용해보세요.

                // 여기에 SetPixel 호출까지 직접 작성하세요.
            }
        }
    }
}