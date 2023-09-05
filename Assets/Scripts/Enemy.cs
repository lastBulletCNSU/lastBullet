using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float moveSpeed; // Enemy의 이동 속도
    public int maxCollisions = 2; // 최대 충돌 횟수

    private Rigidbody enemyRigidbody;
    private int collisionCount = 0; // 현재 충돌 횟수
    private int CountBullet = 0; // 현재 충돌 횟수

    private void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float randomValue = Random.Range(1, 5);
        moveSpeed = randomValue;
        target = FindObjectOfType<PlayerController>().transform;
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            enemyRigidbody.MoveRotation(lookRotation);

            Vector3 moveDirection = direction * moveSpeed * Time.deltaTime;
            enemyRigidbody.MovePosition(transform.position + moveDirection);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (other.tag == "Player")
        {
            collisionCount++; // 충돌 횟수 증가

            if (collisionCount >= maxCollisions)
            {
                playerController.Die();
            }
        }
        if (other.tag == "Bullet")
        {
            CountBullet++; // 충돌 횟수 증가

            if (CountBullet >= maxCollisions)
            {
                Destroy(gameObject);
            }
        }
    }
}