
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// フルーツ1
public class NextFruits1 : MonoBehaviour
{
    // フルーツ1のイメージ
    private SpriteRenderer nextFruits1Image;
    
    // フルーツのゲームオブジェクトのリスト
    private List<GameObject> fruitsGameObjectList;

    // フルーツプレハブインデックス
    public int fruitsPrehabIndex { get; set; }

    // フルーツの今のプレハブインデックス
    private int fruitsNowPrehabIndex;

    // インスタンス
    public static NextFruits1 Instance { get; private set; }

    // 次の状態へ
    public bool isNext { get; set; }

    // 初期処理
    void Start()
    {
        Instance = this;
        isNext = false;
        // 初期表示時はランダムなフルーツを選択する
        nextFruits1Image = GetComponent<SpriteRenderer>();
        fruitsGameObjectList = new List<GameObject>();

        // フルーツのプレハブの名前のマップ(キー：フルーツの名前、値：プレハブ名)から各フルーツをGameObject型で取得
        foreach (KeyValuePair<string, string> fruits in FruitInfoConstant.FRUITS_PREHAB_NAMES_MAP)
        {
            GameObject fruitPrehab = (GameObject)Resources.Load(fruits.Value);
            fruitsGameObjectList.Add(fruitPrehab);
        }
        // ランダムに画像をセット
        int randomFruitValue = Random.Range(0, fruitsGameObjectList.Count);
        fruitsNowPrehabIndex = randomFruitValue;
        nextFruits1Image.sprite = fruitsGameObjectList[randomFruitValue].GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (isNext) {
            isNext = false;
            Invoke("GameMainValueSet", 0.5f);
            Invoke("nextFruits1ImageSet", 0.5f);
        }
    }

    // ゲーム内のフルーツの値設定
    private void GameMainValueSet() {
        // Debug.Log("gameMainValueSetとおり");
        GameMain.Instance.fruitsPrehabIndex = fruitsNowPrehabIndex;
        GameMain.Instance.isNext = true;
    }

    // 次のフルーツ(フルーツ1)のイメージ設定
    private void nextFruits1ImageSet() {
        fruitsNowPrehabIndex = fruitsPrehabIndex;
        nextFruits1Image.sprite = fruitsGameObjectList[fruitsNowPrehabIndex].GetComponent<SpriteRenderer>().sprite;
    }
}