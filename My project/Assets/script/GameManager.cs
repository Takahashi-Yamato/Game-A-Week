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
            DontDestroyOnLoad(gameObject); // シーンを跨いで保持
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // ResultScene以外で時間をカウント
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
