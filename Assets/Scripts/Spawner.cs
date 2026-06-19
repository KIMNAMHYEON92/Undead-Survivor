using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    // 적 생성 위치를 (스포너 + 스폰포인트를)
    public Transform[] spawnPoint;
    // 누적 시간 변수
    private float timer;

    void Awake()
    {
        // 스포너 자신+자식 트랜스폼을 한번에 가져옴
        // GetComponent's'InChildren 's' 복수형 이어야 자식 전부 가져옴
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        // 매 프레임마다 경과 시간 누적
        timer += Time.deltaTime;
        
        // 0.2초마다 스폰 호출
        if (timer >= 0.2f)
        {
            timer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        // 풀에서 적을 꺼냄
        GameObject enemy= GameManager.instance.pool.Get(0);
        
        // 스폰 포인트 중 하나에 배치 (랜덤으로, point들에서만 시작되도록 0제외)
        enemy.transform.position= spawnPoint[Random.Range(1, spawnPoint.Length)].position;

    }
}
