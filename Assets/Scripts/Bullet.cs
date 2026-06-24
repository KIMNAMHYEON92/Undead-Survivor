using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 적에게 줄 데미지
    public float damage;
    // 관통 횟수 (근접 무기 = -1 , 무한으로 관통 하도록)
    public int penetration;
    // 원거리 총알이 날아가게 할 물리 컴포넌트
    private Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    
    public void Init(float damage, int penetration, Vector3 dir)
    {
        this.damage = damage;
        this.penetration = penetration;
        if (penetration > -1)
        {
            rigid.linearVelocity = dir * 15;
        }
    }
    
    // 총알 콜라이더에 무언가 닿으면 호출할 함수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 적이 아니거나, 근접(-1)인 경우 관통을 소비 안함
        if (collision.tag != "Enemy" || penetration == -1)
        {
            return;
        }

        penetration--; // 관통 횟수 감소
        
        // 관통을 모두 소모하고 -1이 되면 총알 소멸
        if (penetration == -1)
        {
            rigid.linearVelocity = Vector2.zero; // 재사용 대비해서 속도 초기화
            gameObject.SetActive(false); // 비활성화
        }
    }
}
