using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
// fileName : 새로 만들 때 기본 파일 이름
// menuName : Create 메뉴 내의 표시될 경로
public class ItemData : ScriptableObject
{
    // 아이템 종류
    public enum ItemType {Melee, Range, Glove, Shoe, Heal}
    
    [Header("# Main Info")]
    public ItemType type; // 아이템의 종류
    public int itemId; // 아이템 고유번호
    public string itemName; // 아이템 이름 (UI 표시용)
    public string itemDesc; // 아이템 설명 (UI 표시용)
    public Sprite itemIcon; // 아이템 아이톰 (UI 표시용)

    [Header("# Level Data")] 
    public float baseDamage; // 0레벨 기본 데미지
    public int baseCount; // 기본 갯수 (근접 : 칼날 수, 원거리: 관통 수)
    public float[] damages; // 레벨별 데미지 증가량
    public int[] counts; // 레벨별 갯수 증가량

    [Header("# Weapon")] 
    public GameObject projectile; // 무기가 사용할 투사체 프리팹
    
}
