using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float speed = 4f;
    public Vector2 direction = Vector2.left; // 移動方向
    public float lifetime = 8f;

    void Start()
    {
        Destroy(gameObject, lifetime);
        // 回転不要（丸は向きに関係ない）
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("プレイヤーにヒット！");
            Destroy(gameObject);
        }
    }
}
