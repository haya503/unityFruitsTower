
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextFruits : MonoBehaviour
{

    private SpriteRenderer nextFruitsImage;
    
    // フルーツのゲームオブジェクトのリスト
    private List<GameObject> fruitsGameObjectList;

    // フルーツを表示している連番
    // private int fruitsDisplayRenban = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 初期表示時はランダムなフルーツを選択する
        nextFruitsImage = GetComponent<SpriteRenderer>();
        fruitsGameObjectList = new List<GameObject>();

        // フルーツのプレハブの名前のマップ(キー：フルーツの名前、値：プレハブ名)から各フルーツをGameObject型で取得
        foreach (KeyValuePair<string, string> fruits in FruitInfoConstant.FRUITS_PREHAB_NAMES_MAP)
        {
            GameObject fruitPrehab = (GameObject)Resources.Load(fruits.Value);
            fruitsGameObjectList.Add(fruitPrehab);
        }
        
        int randomFruitValue = Random.Range(0, fruitsGameObjectList.Count);
        nextFruitsImage.sprite = fruitsGameObjectList[randomFruitValue].GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}