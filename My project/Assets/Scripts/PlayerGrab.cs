using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    // プレイヤーが見ているカメラ
    public Camera playerCamera;

    // 箱を持つ位置
    public Transform holdPoint;

    // 持てる距離
    public float grabDistance = 3f;

    // 現在持っている箱
    private Cube heldCube;

    void Update()
    {
        // 左クリック
        if (Input.GetMouseButtonDown(0))
        {
            // まだ持っていない
            if (heldCube == null)
            {
                TryGrab();
            }
            else
            {
                // 持ってるなら離す
                Drop();
            }
        }
    }

    void TryGrab()
    {
        // マウス位置からRayを飛ばす
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        // Rayが当たったか確認
        if (Physics.Raycast(ray, out hit))
        {
            // Cube取得
            Cube cube = hit.collider.GetComponent<Cube>();

            // Cubeだったら
            if (cube != null)
            {
                // プレイヤーと箱の距離
                float distance = Vector3.Distance(
                    transform.position,
                    cube.transform.position
                );

                // 距離が近いなら持つ
                if (distance <= grabDistance)
                {
                    heldCube = cube;

                    Rigidbody rb = cube.GetComponent<Rigidbody>();

                    // 物理停止
                    rb.isKinematic = true;

                    // holdPointの子にする
                    cube.transform.SetParent(holdPoint);

                    // holdPointの位置へ移動
                    cube.transform.localPosition = Vector3.zero;
                }
            }
        }
    }

    void Drop()
    {
        Rigidbody rb = heldCube.GetComponent<Rigidbody>();

        // 親解除
        heldCube.transform.SetParent(null);

        // 物理再開
        rb.isKinematic = false;

        // 持ってる箱を空にする
        heldCube = null;
    }
}