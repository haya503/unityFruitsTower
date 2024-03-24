using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // MainSceneに遷移
    public void SwitchMainScene(int fruitPrefabsIndex)
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
