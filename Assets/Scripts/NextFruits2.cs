
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// フルーツ2
public class NextFruits2 : MonoBehaviour
{
    // フルーツ2のイメージ
    private SpriteRenderer nextFruits2Image;
    
    // フルーツのゲームオブジェクトのリスト
    private List<GameObject> fruitsGameObjectList;

    // フルーツプレハブインデックス
    public int fruitsPrehabIndex { get; set; }

    // フルーツの今のプレハブインデックス
    private int fruitsNowPrehabIndex;

    // インスタンス
    public static NextFruits2 Instance { get; private set; }

    // 次の状態へ
    public bool isNext { get; set; }

    // 初期処理
    void Start()
    {
        Instance = this;
        isNext = false;
        // 初期表示時はランダムなフルーツを選択する
        nextFruits2Image = GetComponent<SpriteRenderer>();
        fruitsGameObjectList = new List<GameObject>();

        // フルーツのプレハブの名前のマップ(キー：フルーツの名前、値：プレハブ名)から各フルーツをGameObject型で取得
        foreach (KeyValuePair<string, string> fruits in FruitInfoConstant.FRUITS_PREHAB_NAMES_MAP)
        {
            GameObject fruitPrehab = (GameObject)Resources.Load(fruits.Value);
            fruitsGameObjectList.Add(fruitPrehab);
        }
        // 初期表示時にランダムに画像をセット
        int randomFruitValue = Random.Range(0, fruitsGameObjectList.Count);
        fruitsNowPrehabIndex = randomFruitValue;
        nextFruits2Image.sprite = fruitsGameObjectList[randomFruitValue].GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (isNext) {
            isNext = false;
            Invoke("nextFruits1ValueSet", 0.5f);
            Invoke("nextFruits2ImageSet", 0.5f);
        }
    }

    // 次のフルーツ(フルーツ1)の値設定
    private void nextFruits1ValueSet() {
        // Debug.Log("nextFruits1ValueSetとおり");
        NextFruits1.Instance.isNext = true;
        NextFruits1.Instance.fruitsPrehabIndex = fruitsNowPrehabIndex;
    }

    // 次の次のフルーツ(フルーツ2)のイメージ設定
    private void nextFruits2ImageSet() {
        fruitsNowPrehabIndex = fruitsPrehabIndex;
        nextFruits2Image.sprite = fruitsGameObjectList[fruitsNowPrehabIndex].GetComponent<SpriteRenderer>().sprite;
    }
}