using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMain : MonoBehaviour
 {
    // フルーツのプレハブの情報
    [SerializeField] private GameObject[] fruitPrefabs;

    // フルーツの位置情報
    [SerializeField] private Transform fruitPosition;

    // 表示されているフルーツのゲームオブジェクトのリスト
    private List<GameObject> dispFruitsGameObjectList;

    // インスタンス情報
    public static GameMain Instance { get; private set; }

    // 次のフルーツにするかどうか
    public bool isNext { get; set; }

    // フルーツが皿から落ちたかどうかにするかどうか
    public bool isDropFruitsPlate { get; set; }

    // 次のフルーツのindex
    public int fruitsPrehabIndex { get; set; }

    // ゲームが終了状態か
    private bool isGameFinish = false;

    
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        isNext = false;
        isDropFruitsPlate = false;
        dispFruitsGameObjectList = new List<GameObject>();
        int i = Random.Range(0, fruitPrefabs.Length - 1);
        CreateFruit(i);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameFinish) {
            return;
        }
        // 次のフルーツのパラメーターがわたってきたときインスタンス生成
        if (isNext)
        {
            isNext = false;
            CreateFruit(fruitsPrehabIndex);
        } else {
            if (dispFruitsGameObjectList?.Count > 0) {
                foreach (var fruitsGameObject in dispFruitsGameObjectList)
                {
                    int fruitsYSeisu = (int)fruitsGameObject.transform.position.y;
                    // フルーツが落ちたらゲーム終了
                    if (fruitsYSeisu <= -10) {
                        isGameFinish = true;
                        SceneManager.LoadScene("Finish", LoadSceneMode.Single);
                        break;
                    }
                }
            }
        }
    }

    // フルーツのインスタンスを作成
    private void CreateFruit(int fruitPrefabsIndex)
    {
        GameObject fruits = Instantiate(fruitPrefabs[fruitPrefabsIndex], fruitPosition) as GameObject;
        dispFruitsGameObjectList.Add(fruits);
    }
}