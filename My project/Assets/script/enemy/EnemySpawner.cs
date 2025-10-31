using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("敵プレハブ")]
    public GameObject enemyPrefab;

    [Header("出現するレーンの高さ（プレイヤーと合わせる）")]
    public float[] spawnHeights = { -3f, 0f, 3f };

    [Header("初期スポーン間隔(秒)")]
    public float startSpawnInterval = 3f;

    [Header("最小スポーン間隔(秒)")]
    public float minSpawnInterval = 0.7f;

    [Header("難易度上昇スピード")]
    public float difficultyIncreaseRate = 0.05f;

    [Header("敵が出るX座標（カメラ外）")]
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

            // 難易度上昇：徐々に出現間隔を短くする
            currentSpawnInterval = Mathf.Max(minSpawnInterval, currentSpawnInterval - difficultyIncreaseRate);
        }
    }

    void SpawnEnemy()
    {
        bool fromLeft = Random.value < 0.5f;

        // レーンをランダム選択
        float spawnY = spawnHeights[Random.Range(0, spawnHeights.Length)];
        float spawnX = fromLeft ? leftSpawnX : rightSpawnX;

        // 敵生成
        GameObject enemy = Instantiate(enemyPrefab, new Vector2(spawnX, spawnY), Quaternion.identity);

        // 敵の進行方向を設定
        EnemyMover mover = enemy.GetComponent<EnemyMover>();
        mover.direction = fromLeft ? Vector2.right : Vector2.left;

        // 三角形の頂点を横に固定
        Vector3 scale = enemy.transform.localScale;
        scale.x = fromLeft ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
        enemy.transform.localScale = scale;
    }

}
