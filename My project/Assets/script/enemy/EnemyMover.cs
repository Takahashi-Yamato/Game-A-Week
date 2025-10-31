using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float speed = 4f;
    public Vector2 direction = Vector2.left; // �ړ�����
    public float lifetime = 8f;

    void Start()
    {
        Destroy(gameObject, lifetime);
        // ��]�s�v�i�ۂ͌����Ɋ֌W�Ȃ��j
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�v���C���[�Ƀq�b�g�I");
            Destroy(gameObject);
        }
    }
}
