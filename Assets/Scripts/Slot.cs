
using System.Collections.Generic;
using UnityEngine;

// スロット
public class Slot : MonoBehaviour
{
    // フルーツのゲームオブジェクトのリスト
    private List<GameObject> fruitsGameObjectList;

    // スロットの画像
    private SpriteRenderer slotImage;

    // フルーツを表示している連番
    private int fruitsDisplayRenban = 0;

    // インスンス
    public static Slot Instance { get; private set; }

    // スロットが止まっているか
    public bool isSlotStop { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        isSlotStop = false;
        slotImage = GetComponent<SpriteRenderer>();
        fruitsGameObjectList = new List<GameObject>();

        // フルーツのプレハブの名前のマップ(キー：フルーツの名前、値：プレハブ名)から各フルーツをGameObject型で取得
        foreach (KeyValuePair<string, string> fruits in FruitInfoConstant.FRUITS_PREHAB_NAMES_MAP)
        {
            GameObject fruitPrehab = (GameObject)Resources.Load(fruits.Value);
            fruitsGameObjectList.Add(fruitPrehab);
        }
        // 初期表示時にランダムに画像をセット
        int randomFruitValue = Random.Range(0, fruitsGameObjectList.Count);
        slotImage.sprite = fruitsGameObjectList[randomFruitValue].GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSlotStop)
        {
            isSlotStop = false;
            Invoke("nextFruits3ValueSet", 0.5f);
        } else {
            slotImageChange();
        }
    }

    // 次の次の次のフルーツ(フルーツ3)の値設定
    private void nextFruits3ValueSet() {
        Debug.Log("nextFruits3ValueSetとおり");
        NextFruits3.Instance.isNext = true;
        NextFruits3.Instance.fruitsPrehabIndex = fruitsDisplayRenban;
    }

    // スロットのイメージ変更
    private void slotImageChange() {
        slotImage.sprite = fruitsGameObjectList[fruitsDisplayRenban].GetComponent<SpriteRenderer>().sprite;
        fruitsDisplayRenban++;
        if (fruitsDisplayRenban >= fruitsGameObjectList.Count)
        {
            fruitsDisplayRenban = 0;
        }
    }
}
