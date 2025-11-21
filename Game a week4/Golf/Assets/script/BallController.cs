using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 startPos;
    private Vector3 dragVector;
    private bool isDragging;

    public float power = 10f;
    public LineRenderer lineRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // LineRenderer 初期化
        if (lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.enabled = false; // 最初は非表示
    }

    void Update()
    {
        // マウスを押した瞬間
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            isDragging = true;
            lineRenderer.enabled = true;
        }

        // マウスドラッグ中
        if (Input.GetMouseButton(0) && isDragging)
        {
            Vector3 currentPos = Input.mousePosition;
            dragVector = (startPos - currentPos);

            // マウスの動きをワールド座標に変換して線を描画
            Vector3 dir = new Vector3(dragVector.x, 0, dragVector.y) * 0.01f;
            Vector3 startPoint = transform.position;
            Vector3 endPoint = transform.position + dir;

            lineRenderer.SetPosition(0, startPoint);
            lineRenderer.SetPosition(1, endPoint);
        }

        // マウスを離した時
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            Vector3 endPos = Input.mousePosition;
            dragVector = (startPos - endPos);
            Vector3 force = new Vector3(dragVector.x, 0, dragVector.y) * power * Time.deltaTime;

            rb.AddForce(force, ForceMode.Impulse);

            isDragging = false;
            lineRenderer.enabled = false; // 打ったら線を消す
        }
    }
}

