using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject capsulePrefab; // Enemy 프리팹
    public float spawnInterval = 2f; // Enemy 생성 간격
    public float xForRange1;
    public float yForRange1;
    public float xForRange2;
    public float yForRange2;

    private void Start()
    {
        // 일정 간격으로 Enemy 생성을 시작합니다.
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    private void SpawnEnemy()
    {
        // 랜덤한 위치 계산
        Vector3 spawnPosition = new Vector3(Random.Range(-xForRange1, yForRange1), 0f, Random.Range(-xForRange2, yForRange2));

        // Enemy 생성
        GameObject enemy = Instantiate(capsulePrefab, spawnPosition, Quaternion.identity);
    }
}