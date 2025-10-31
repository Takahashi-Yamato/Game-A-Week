using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector]
    public float survivalTime = 0f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // �V�[�����ׂ��ŕێ�
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // ResultScene�ȊO�Ŏ��Ԃ��J�E���g
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "ResultScene")
        {
            survivalTime += Time.deltaTime;
        }
    }

    public void ResetGame()
    {
        survivalTime = 0f;
    }
}
