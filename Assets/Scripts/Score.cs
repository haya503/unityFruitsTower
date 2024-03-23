using TMPro;
using UnityEngine;

// スコア
public class Score : MonoBehaviour
{
    // インスタンス情報
    public static Score Instance { get; private set; }

    // スコア
    public int scoreValue = 0;

    // テキスト
    private TextMeshPro text;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        text = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = scoreValue.ToString();
    }
}

