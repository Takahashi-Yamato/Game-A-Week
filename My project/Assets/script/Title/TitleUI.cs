using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    // Startボタンに設定する関数
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); // MainScene に移動
    }

    // 終了ボタンに設定する関数
    public void QuitGame()
    {
        Application.Quit();
    }
}
