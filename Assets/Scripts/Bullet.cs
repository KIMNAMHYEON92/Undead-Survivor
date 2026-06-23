using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 적에게 줄 데미지
    public float damage;
    // 관통 횟수 (근접 무기 = -1 , 무한으로 관통 하도록)
    public int penetration;

    public void Init(float damage, int penetration)
    {
        this.damage = damage;
        this.penetration = penetration;
    }
}
