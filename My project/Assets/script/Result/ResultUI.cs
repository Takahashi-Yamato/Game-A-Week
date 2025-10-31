using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultUI : MonoBehaviour
{
    public Text scoreText;
    public Button retryButton;

    void Start()
    {
        // �X�R�A�\��
        if (GameManager.instance != null)
        {
            scoreText.text = "��������: " + Mathf.FloorToInt(GameManager.instance.survivalTime) + "�b";
        }

        // ���g���C�{�^���o�^
        retryButton.onClick.AddListener(RetryGame);
    }

    public void RetryGame()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ResetGame();
        }
        SceneManager.LoadScene("SampleScene"); // MainScene�ɖ߂�
    }
}
