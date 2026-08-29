using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;

    public int targetCount = 3;

    public AudioSource hitSound;

    void Start()
    {
        SpawnTargets();
    }

    void SpawnTargets()
    {
        for (int i = 0; i < targetCount; i++)
        {
            SpawnTarget();
        }
    }

    public void SpawnTarget()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-20f, 20f),
            Random.Range(1.5f, 4f),
            Random.Range(5f, 8f)
        );

        Instantiate(
            targetPrefab,
            spawnPosition,
            Quaternion.identity
        );
    }

    public void PlayHitSound()
    {
        if (hitSound != null)
        {
            hitSound.Play();
        }
    }
}