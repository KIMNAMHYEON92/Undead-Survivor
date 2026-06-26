using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [Header("# Game Object")]
    public Player player;
    public PoolManager pool;
    
    [Header("# Game Controls")]
    // 흐르는 게임 시간 - 난이도 계산용도
    public float gameTime;
    // 최대 게임 시간 - 난이도 증가한도
    public float maxGameTime;

    
    [Header("# Player Data")]
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 3, 5, 10, 20, 150, 210, 280, 360, 450, 600 };
    public int health;
    public int maxHealth = 100;

    private void Awake()
    {
        instance = this; 
    }
    
    private void Start()
    {
        health = maxHealth; // 게임 시작 시 체력을 최대체력으로 초기화
    }

    void Update()
    {
        // 매 프레임마다 실제 흐른 시간을 누적
        gameTime += Time.deltaTime;
        // 
        if (gameTime >= maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }
    
    // 경험치 획득 및 레벨업 로직
    public void GetExp()
    {
        exp++;
        if (exp >= nextExp[level])
        {
            level++;
            exp = 0;
        }
    }
    
}
