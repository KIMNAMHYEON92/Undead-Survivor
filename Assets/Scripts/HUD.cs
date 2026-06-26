using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType {Exp, Level, Kill, Time, Health}
    public InfoType type; // 인스펙터에서 HUD 스크립트 컴포넌트가 어떤 정보를 처리할지 지정하기 위한 용도

    Text myText;
    Slider mySlider;
    
    void Awake()
    {
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
    }

    void lassUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                // 슬라이더 값 : 현재 경험치 / 현재 레벨의 목표 경험치 (0~1)
                float curExp = GameManager.instance.exp;
                // 무한 레벨업으로 level이 배열 길이를 넘는 경우, 인덱스 초과 예외가 메모리에 누적되는 상황 방지.
                // Mathf.Min으로 마지막 인덱스를 고정하기 위함
                int expIndex = Mathf.Min(GameManager.instance.level, GameManager.instance.nextExp.Length - 1);
                float maxExp = GameManager.instance.nextExp[expIndex];
                mySlider.value = curExp / maxExp;
                break;
            case InfoType.Level:
                // string.Format : {0:F0} -> 변수의 값을 0인자에 소수점없는 숫자로 대입
                myText.text = string.Format("Lv. {0:F0}", GameManager.instance.level);
                break;
            case InfoType.Kill:
                myText.text = string.Format("{0:F0}", GameManager.instance.kill);
                break;
            case InfoType.Time:
                // 남은 시간 = 최대 시간 - 경과 시간
                float remainTime = GameManager.instance.maxGameTime - GameManager.instance.gameTime;
                // 소수점 버림(정수화) MathF.FloorToInt
                int min = Mathf.FloorToInt(remainTime/60);
                int sec = Mathf.FloorToInt(remainTime % 60);
                // D2 -> 최소 2자리, 부족하면 0을 채움 "00:00"
                myText.text = string.Format("{0:D2}:{1:D2}", min,sec);
                break;
            case InfoType.Health:
                float curHp = GameManager.instance.health;
                float maxHp = GameManager.instance.maxHealth;
                mySlider.value = curHp / maxHp;
                break;
            default:
                break;
        }
    }
}
