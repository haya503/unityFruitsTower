using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    // StartSceneに遷移
    public void SwitchStartScene(int fruitPrefabsIndex)
    {
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }
}
