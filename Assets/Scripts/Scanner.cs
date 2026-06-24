using UnityEngine;

public class Scanner : MonoBehaviour
{
    public float scanRange; // 스캔 범위
    public LayerMask targetLayer; // 스캔 대상 레이어
    public RaycastHit2D[] targets; // 범위 내 검색된 대상들
    public Transform nearestTarget; // 대상들 중 가장 가까운 타겟

    void FixedUpdate()
    {
        // CircleCastAll : 원(반지름)을 쏘면서 경로에 닿는 콜라이더를 전부 배열로 반환
        targets= Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);
        // 
        nearestTarget= GetNearestTarget();
    }

    // 검색된 대상들(targets) 중 가장 가까운 Transform을 반환
    Transform GetNearestTarget()
    {
        Transform result = null; // 최근접대상.
        float diff = 100; // 현재까지 최소 거리(큰값 시작)

        foreach (RaycastHit2D target in targets)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float currDiff = Vector3.Distance(myPos, targetPos);
            
            if (currDiff < diff)
            {
                diff = currDiff;
                result = target.transform;
            }
        }
        
        return result;
    }
}