using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    // Start�{�^���ɐݒ肷��֐�
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); // MainScene �Ɉړ�
    }

    // �I���{�^���ɐݒ肷��֐�
    public void QuitGame()
    {
        Application.Quit();
    }
}
