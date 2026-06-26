using System;
using UnityEngine;

public class Follow : MonoBehaviour
{
    RectTransform rect; // UI 오브젝트 전용 위치, 크기 컴포넌트 (Transform의 UI 버전)
    
    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // UI의 Canvas 스크린 좌표계를 사용함, 따라서 변환이 필요
        // Camera.main.WorldToScreenPoint가 월드좌표->스크린좌표로 변환
        // 헬스바 체력 UI가 플레이어 위치를 따라다니게 함
        rect.position = Camera.main.WorldToScreenPoint(
            GameManager.instance.player.transform.position);
    }
}