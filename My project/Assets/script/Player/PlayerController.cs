using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float[] lanesY = { -3f, 0f, 3f };
    public int currentLane = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && currentLane < lanesY.Length - 1)
        {
            currentLane++;
            UpdatePosition();
        }
        if (Input.GetKeyDown(KeyCode.S) && currentLane > 0)
        {
            currentLane--;
            UpdatePosition();
        }

        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(moveX, 0, 0);
    }

    void UpdatePosition()
    {
        Vector3 pos = transform.position;
        pos.y = lanesY[currentLane];
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // ResultScene‚ÉˆÚ“®
            SceneManager.LoadScene("ResultScene");
        }
    }
}
