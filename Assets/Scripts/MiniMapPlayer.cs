using UnityEngine;
using System.Collections.Generic;

public class MiniMapPlayer : MonoBehaviour
{
    public Transform player;
    public RectTransform marker;

    public float mapSize = 50f;

    public GameObject targetMarkerPrefab;

    private List<GameObject> targetMarkers = new List<GameObject>();

    void Start()
    {
        UpdateTargetMarkers();
    }

    void Update()
    {
        // Playerの位置を更新
        UpdatePlayerMarker();

        // Targetの位置を更新
        UpdateTargetMarkers();
    }

    void UpdatePlayerMarker()
    {
        float x = player.position.x;
        float z = player.position.z;

        float normalizedX = x / mapSize;
        float normalizedZ = z / mapSize;

        marker.anchoredPosition = new Vector2(
            normalizedX * 125f,
            normalizedZ * 125f
        );
    }

    void UpdateTargetMarkers()
    {
        GameObject[] targets =
            GameObject.FindGameObjectsWithTag("Target");

        // TargetMarkerの数をTargetの数に合わせる
        while (targetMarkers.Count < targets.Length)
        {
            GameObject newMarker =
                Instantiate(targetMarkerPrefab, transform);

            newMarker.SetActive(true);

            targetMarkers.Add(newMarker);
        }

        // TargetMarkerが多すぎる場合は削除
        while (targetMarkers.Count > targets.Length)
        {
            GameObject oldMarker =
                targetMarkers[targetMarkers.Count - 1];

            targetMarkers.RemoveAt(targetMarkers.Count - 1);

            Destroy(oldMarker);
        }

        // Targetの位置をマーカーに反映
        for (int i = 0; i < targets.Length; i++)
        {
            Transform target =
                targets[i].transform;

            RectTransform targetMarker =
                targetMarkers[i].GetComponent<RectTransform>();

            float x = target.position.x;
            float z = target.position.z;

            float normalizedX = x / mapSize;
            float normalizedZ = z / mapSize;

            targetMarker.anchoredPosition =
                new Vector2(
                    normalizedX * 125f,
                    normalizedZ * 125f
                );
        }
    }
}