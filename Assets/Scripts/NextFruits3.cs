
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// フルーツ3
public class NextFruits3 : MonoBehaviour
{
    // フルーツ3のイメージ
    private SpriteRenderer nextFruits3Image;
    
    // フルーツのゲームオブジェクトのリスト
    private List<GameObject> fruitsGameObjectList;

    // フルーツプレハブインデックス
    public int fruitsPrehabIndex { get; set; }

    // フルーツの今のプレハブインデックス
    private int fruitsNowPrehabIndex;

    // インスタンス
    public static NextFruits3 Instance { get; private set; }

    // 次の状態へ
    public bool isNext { get; set; }

    // 初期処理
    void Start()
    {
        Instance = this;
        isNext = false;
        // 初期表示時はランダムなフルーツを選択する
        nextFruits3Image = GetComponent<SpriteRenderer>();
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
        nextFruits3Image.sprite = fruitsGameObjectList[randomFruitValue].GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (isNext) {
            isNext = false;
            Invoke("nextFruits2ValueSet", 0.5f);
            Invoke("nextFruits3ImageSet", 0.5f);
        }
    }

    // 次の次のフルーツ(フルーツ2)の値設定
    private void nextFruits2ValueSet() {
        Debug.Log("nextFruits2ValueSetとおり");
        NextFruits2.Instance.isNext = true;
        NextFruits2.Instance.fruitsPrehabIndex = fruitsNowPrehabIndex;
    }

    // 次の次の次のフルーツ(フルーツ3)のイメージ設定
    private void nextFruits3ImageSet() {
        fruitsNowPrehabIndex = fruitsPrehabIndex;
        nextFruits3Image.sprite = fruitsGameObjectList[fruitsNowPrehabIndex].GetComponent<SpriteRenderer>().sprite;
    }
}