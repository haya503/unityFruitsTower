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

    // ゲームがクリアか
    private bool isGameClear = false;

    // スコア
    private int score = 0;

    // 最大高さ
    private int saidaiTakasa = 1;

    // フルーツカウント
    private int fruitsCount = 0;

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
        if (isGameFinish || isGameClear) {
            return;
        }
        // 次のフルーツのパラメーターがわたってきたときインスタンス生成
        if (isNext)
        {
            isNext = false;
            CreateFruit(fruitsPrehabIndex);
        } else {
            if (dispFruitsGameObjectList?.Count > 0) {
                // Debug.Log(dispFruitsGameObjectList[0].transform.position.y);
                foreach (var fruitsGameObject in dispFruitsGameObjectList)
                {
                    Fruits fruits = fruitsGameObject.GetComponent<Fruits>();
                    Rigidbody2D rigidbody2DFruits = fruitsGameObject.GetComponent<Rigidbody2D>();
                    SpriteRenderer spriteRendererFruits = fruitsGameObject.GetComponent<SpriteRenderer>();
                    int fruitsYSeisu = (int)(fruitsGameObject.transform.position.y + (spriteRendererFruits.size.y / 2));
                    if (fruits.isDrop && rigidbody2DFruits.IsSleeping() && saidaiTakasa < fruitsYSeisu) {
                        saidaiTakasa = fruitsYSeisu;
                    }
                }
                fruitsCount = dispFruitsGameObjectList.Count;
                score = saidaiTakasa * fruitsCount;
                Score.Instance.scoreValue = score * 100;

                foreach (var fruitsGameObject in dispFruitsGameObjectList)
                {
                    Fruits fruits = fruitsGameObject.GetComponent<Fruits>();
                    Rigidbody2D rigidbody2DFruits = fruitsGameObject.GetComponent<Rigidbody2D>();
                    SpriteRenderer spriteRendererFruits = fruitsGameObject.GetComponent<SpriteRenderer>();
                    int fruitsYSeisu = (int)(fruitsGameObject.transform.position.y + (spriteRendererFruits.size.y / 2));
                    // Debug.Log(fruits.name);
                    // Debug.Log("fruits.isDrop:" + fruits.isDrop);
                    // Debug.Log("rigidbody2DFruits.IsSleeping():" + rigidbody2DFruits.IsSleeping());
                    // Debug.Log("fruitsYSeisu:" + fruitsYSeisu);

                    // フルーツが落ちているかつ、オブジェクトが停止しているかつ、クリアラインより高い場合、クリア判定
                    if (fruits.isDrop && rigidbody2DFruits.IsSleeping() && fruitsYSeisu >= FruitInfoConstant.CLEAR_LINE_HEIGHT) {
                        isGameClear = true;
                        isGameFinish = true;
                        Score.Instance.scoreValue = score * 100 + 3000;
                        PlayerPrefs.SetInt("score", Score.Instance.scoreValue);
                        PlayerPrefs.Save();
                        Debug.Log("スコア:" + Score.Instance.scoreValue);
                        Debug.Log("クリア");
                        SceneManager.LoadScene("Finish", LoadSceneMode.Single);
                        break;
                    }
                    // フルーツが落ちたらゲーム終了
                    if (fruitsYSeisu <= -10) {
                        isGameFinish = true;
                        PlayerPrefs.SetInt("score", Score.Instance.scoreValue);
                        PlayerPrefs.Save();
                        Debug.Log("スコア:" + Score.Instance.scoreValue);
                        Debug.Log("終了");
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