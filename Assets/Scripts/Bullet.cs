using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 3f;

    public GameObject hitEffectPrefab;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            // 爆発エフェクトを出す
            if (hitEffectPrefab != null)
            {
                Instantiate(
                    hitEffectPrefab,
                    collision.transform.position,
                    Quaternion.identity
                );
            }

            // スコアを増やす
            ScoreManager scoreManager =
                FindFirstObjectByType<ScoreManager>();

            if (scoreManager != null)
            {
                scoreManager.AddScore();
            }

            // 効果音を鳴らす
            TargetSpawner spawner =
                FindFirstObjectByType<TargetSpawner>();

            if (spawner != null)
            {
                spawner.PlayHitSound();

                // 新しいTargetを出す
                spawner.SpawnTarget();
            }

            // Targetを消す
            Destroy(collision.gameObject);

            // 弾を消す
            Destroy(gameObject);
        }
    }
}