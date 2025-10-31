using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("�G�v���n�u")]
    public GameObject enemyPrefab;

    [Header("�o�����郌�[���̍����i�v���C���[�ƍ��킹��j")]
    public float[] spawnHeights = { -3f, 0f, 3f };

    [Header("�����X�|�[���Ԋu(�b)")]
    public float startSpawnInterval = 3f;

    [Header("�ŏ��X�|�[���Ԋu(�b)")]
    public float minSpawnInterval = 0.7f;

    [Header("��Փx�㏸�X�s�[�h")]
    public float difficultyIncreaseRate = 0.05f;

    [Header("�G���o��X���W�i�J�����O�j")]
    public float leftSpawnX = -9f;
    public float rightSpawnX = 9f;

    private float currentSpawnInterval;
    private float timer = 0f;
    private float elapsedTime = 0f;

    void Start()
    {
        currentSpawnInterval = startSpawnInterval;
    }

    void Update()
    {
        timer += Time.deltaTime;
        elapsedTime += Time.deltaTime;

        if (timer >= currentSpawnInterval)
        {
            SpawnEnemy();
            timer = 0f;

            // ��Փx�㏸�F���X�ɏo���Ԋu��Z������
            currentSpawnInterval = Mathf.Max(minSpawnInterval, currentSpawnInterval - difficultyIncreaseRate);
        }
    }

    void SpawnEnemy()
    {
        bool fromLeft = Random.value < 0.5f;

        // ���[���������_���I��
        float spawnY = spawnHeights[Random.Range(0, spawnHeights.Length)];
        float spawnX = fromLeft ? leftSpawnX : rightSpawnX;

        // �G����
        GameObject enemy = Instantiate(enemyPrefab, new Vector2(spawnX, spawnY), Quaternion.identity);

        // �G�̐i�s������ݒ�
        EnemyMover mover = enemy.GetComponent<EnemyMover>();
        mover.direction = fromLeft ? Vector2.right : Vector2.left;

        // �O�p�`�̒��_�����ɌŒ�
        Vector3 scale = enemy.transform.localScale;
        scale.x = fromLeft ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
        enemy.transform.localScale = scale;
    }

}
