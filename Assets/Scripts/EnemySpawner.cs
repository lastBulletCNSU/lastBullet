using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject capsulePrefab; // Enemy ������
    public float spawnInterval = 2f; // Enemy ���� ����
    public float xForRange1;
    public float yForRange1;
    public float xForRange2;
    public float yForRange2;

    private void Start()
    {
        // ���� �������� Enemy ������ �����մϴ�.
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    private void SpawnEnemy()
    {
        // ������ ��ġ ���
        Vector3 spawnPosition = new Vector3(Random.Range(-xForRange1, yForRange1), 0f, Random.Range(-xForRange2, yForRange2));

        // Enemy ����
        GameObject enemy = Instantiate(capsulePrefab, spawnPosition, Quaternion.identity);
    }
}