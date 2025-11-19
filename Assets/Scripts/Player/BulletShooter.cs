using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 총알 발사용 스크립트. 
/// </summary>
public class BulletShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject mapPrefabs;
    private List<GameObject> bulletShooters = new List<GameObject>();
    private float shootRpm;
    private void Start()
    {
        InitBullet(10);
    }
    private void InitBullet(int count)
    {
        for (int i = 0; i < count; i++)
        {
            CreatBullet();
        }
    }
    private void Update()
    {
        Shooting();
    }
    private void CreatBullet()
    {
        GameObject obj = Instantiate(mapPrefabs, transform);
        obj.SetActive(false);
        bulletShooters.Add(obj);
    }
    private void Shooting()
    {
        if (Time.time >= shootRpm)
        {
            shootRpm = Time.time + 1f;
            foreach (GameObject obj in bulletShooters)
            {
                if (!obj.activeInHierarchy)
                {
                    obj.SetActive(true);
                    break;
                }
                CreatBullet();
            }
        }

    }
    // TODO : ObjectPool을 이용해 총알 생성을 구현해봅시다.
}
