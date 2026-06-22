using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    // 적 생성 위치를 (스포너 + 스폰포인트를)
    public Transform[] spawnPoint;
    // 난이도별 스폰 설저 데이터
    public SpawnData[] spawnData;
    // 누적 시간 변수
    private float timer;
    // 현재 난이도 (게임 시간에 따라 변화)
    private int difficulty;

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
        
        // 난이도 상승 연산
        difficulty= (int)(GameManager.instance.gameTime / 10f);
        
        // 난이도가 데이터 개수를 넘지 않도록 제한(배열 범위를 초과 방지)
        if (difficulty >= spawnData.Length)
        {
            difficulty = spawnData.Length - 1;
        }
        
        // 현재 난이도의 스폰 간격을 넘으면 스폰 호출
        if (timer >= spawnData[difficulty].spawnTime)
        {
            timer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        // 현재 난이도 데이터가 지정한 종류(spriteType)의 프리펩을 풀에서 적을 꺼냄
        GameObject enemy= GameManager.instance.pool.Get(0);
        
        // 스폰 포인트 중 하나에 배치 (랜덤으로, point들에서만 시작되도록 0제외)
        enemy.transform.position= spawnPoint[Random.Range(1, spawnPoint.Length)].position;

        // 현재 난이도 데이터로 enemy 능력치 초기화 (체력, 속도)
        enemy.GetComponent<Enemy>().Init(spawnData[difficulty]);
    }
}
