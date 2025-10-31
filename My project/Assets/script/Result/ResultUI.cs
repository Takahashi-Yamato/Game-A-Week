using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultUI : MonoBehaviour
{
    public Text scoreText;
    public Button retryButton;

    void Start()
    {
        // スコア表示
        if (GameManager.instance != null)
        {
            scoreText.text = "生存時間: " + Mathf.FloorToInt(GameManager.instance.survivalTime) + "秒";
        }

        // リトライボタン登録
        retryButton.onClick.AddListener(RetryGame);
    }

    public void RetryGame()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ResetGame();
        }
        SceneManager.LoadScene("SampleScene"); // MainSceneに戻る
    }
}
