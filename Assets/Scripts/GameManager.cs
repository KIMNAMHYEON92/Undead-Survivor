using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    public PoolManager pool;
    // 흐르는 게임 시간 - 난이도 계산용도
    public float gameTime;
    // 최대 게임 시간 - 난이도 증가한도
    public float maxGameTime;

    private void Awake()
    {
        instance = this; 
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
    
}
