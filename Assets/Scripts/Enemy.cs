using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 적 이동 속도
    public float speed;
    
    // 추적할 대상 물리 컴포넌트 target
    public Rigidbody2D target;
    
    // 적의 생존 여부
    public bool isLive;
    
    // Enemy 본인 물리 컴포넌트
    Rigidbody2D rigid;
    
    // flipX를 통한 적 좌우 반전용
    SpriteRenderer spriter;
    
    void Awake()
    {
        // 미리 컴포넌트들을 로드하여 메모리에 캐싱
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    // OnEnable: 객체가 활성화 될 때마다 호출
    private void OnEnable()
    {
        // 프리팹은 Player를 참조(할당) 하지 못하므로, GameManager를 통해 매번 플레이어를 target으로 할당한다.
        target= GameManager.instance.player.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // 1. 방향 구하기 (목표위치 - 내 위치) -> 플레이어쪽을 바라보는 벡터
        Vector2 dirVec = target.position - rigid.position;
        
        // 2. 이동량 구하기 (방향 * 속도 * 프레임시간)
        // 정규화를 통해 거리랑 상관없이 일정한 속도를 위함
        Vector2 nextVec = dirVec.normalized * (speed * Time.fixedDeltaTime);
        
        // 3. 객체 이동 (현재 위치 + 이동량)
        rigid.MovePosition(rigid.position + nextVec);
        
        // 4. 잔여 속도 제거 - 플레이어랑 충돌하면, 물리 속도를 0으로
        rigid.linearVelocity = Vector2.zero;
    }

    void LateUpdate()
    {
        spriter.flipX= target.position.x < rigid.position.x;
    }
    
}
