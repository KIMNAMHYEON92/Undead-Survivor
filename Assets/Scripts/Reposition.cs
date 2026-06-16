using System;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    // OnTriggerExit2D : 트리거 콜라이더에서 벗어났을때 호출되는 함수
    private void OnTriggerExit2D(Collider2D collision)
    {
        // 플레이어 Area 콜라이더가 벗어난 경우에만 실행
        if (!collision.CompareTag("Area"))
        {
            return;
        }
        
        // 플레이어 위치와 내(타일맵)의 위치를 저장
        Vector2 playerPos = GameManager.instance.player.transform.position;
        Vector2 myPos = transform.position;
        
        // x축, y축 벌어진 거리 계산 (크기만 -> 절대값)
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);
        
        // 플레이어가 향하는 방향을 -1 또는 1로 정리
        Vector3 playerDir = GameManager.instance.player.inputVec;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;
        
        // 태그에 따라 재배치 방식을 분기
        switch (transform.tag)
        {
            case "Ground":
                // 더 많이 벌어진 축 방향으로 타일맵 이동 (타일 20 X 2칸 = 40 -> 타일맵 크기의 2배)
                if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * 40);
                }
                else
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                break;
            case "Enemy":
                break;
            default:
                break;
        }
        {
            
        }
    }
}
