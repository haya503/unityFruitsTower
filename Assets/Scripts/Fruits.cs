using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    // フルーツのリジッドボディ2Dの情報
    private Rigidbody2D fruitsRigidbody2D;

    // 落ちている状態かどうか
    private bool isDrop = false;

    // フルーツの移動できる最小X軸
    private const float FRUIT_IDODEKIRU_SAISHO_X_VALUE = 0f;

    // フルーツの移動できる最大X軸
    private const float FRUIT_IDODEKIRU_SAIDAI_X_VALUE = 23f;

    // フルーツのY軸
    private const float FRUIT_Y_VALUE = 8f;

    // 初期処理
    void Start()
    {
        fruitsRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDrop) {
            return;
        }
        // 左クリックされたらフルーツを落とす
        if (Input.GetMouseButton(0) && isDrop == false) {
            Drop();
        }
        // フルーツを動かせる範囲を指定
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.x = Mathf.Clamp(mousePos.x, FRUIT_IDODEKIRU_SAISHO_X_VALUE, FRUIT_IDODEKIRU_SAIDAI_X_VALUE);
        mousePos.y = FRUIT_Y_VALUE;
        transform.position = mousePos;
    }

    // フルーツを落とす
    private void Drop()
    {
        isDrop = true;
        fruitsRigidbody2D.simulated = true;
        Slot.Instance.isSlotStop = true;
    }
}
