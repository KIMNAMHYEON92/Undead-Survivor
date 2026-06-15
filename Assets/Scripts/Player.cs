using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // 방향 키 입력 받는 벡터 (x= 좌우, y= 상하)
    public Vector2 inputVec;
    
    // 이동 속도
    public float speed;

    // 객체가 가진 물리 컴포넌트
    Rigidbody2D rigid;
    // 스프라이트 렌더러 컴포넌트
    SpriteRenderer spriter;
    // 애니메이션 상태 제어 컴포넌트
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    
    // FixedUpdate
    private void FixedUpdate()
    {
        // 다음 이동량 = 방향 * (속도 * 프레임시간)
        Vector2 nextVec = inputVec.normalized * (speed * Time.fixedDeltaTime);
        // 현재 위치 + 이동량
        rigid.MovePosition(rigid.position + nextVec);
    }
    
    // LateUpdate : 모든 업데이트가 끝난 뒤 실행. 후처리에 적합
    private void LateUpdate()
    {
        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }
        
        anim.SetFloat("Speed", inputVec.magnitude);
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 20), inputVec.ToString());
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
