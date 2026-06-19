using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 풀에 사용 될 프리팹 목록
    public GameObject[] prefabs;
    
    // 실제 재사용 오브젝트를 담는 풀
    private List<GameObject>[] pools;

    void Awake()
    {
        // 프리팹 개수만큼 풀 배열을 생성
        pools = new List<GameObject>[prefabs.Length];
        
        // 각 칸에 실제 빈 리스트를 초기ㅗ하
        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    // index번 프리팹 풀에서 재사용 오브젝트를 반환(없으면 생성)
    public GameObject Get(int index)
    {
        // 반환 오브젝트를 담을 변수
        GameObject select = null;

        // 해당 풀을 돌면서, 꺼져있는 오브젝트 탐색
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }
        
        // 풀의 오브젝트가 전부 사용중이라면, -> 새로 생성
        if (!select)
        {
            // 원본 프리팹을 복제 (풀매니저의 자식으로 둠)
            select = Instantiate(prefabs[index],transform);
            // 오브젝트를 풀에 등록해서 재사용
            pools[index].Add(select);
        }
        
        return select;
    }


}
