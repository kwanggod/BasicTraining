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
            shootRpm = Time.time + 0.3f;
            bool activeBullet = false;
            foreach (GameObject obj in bulletShooters)
            {
                if (!obj.activeInHierarchy)
                {
                    activeBullet=true;
                    obj.SetActive(true);
                    obj.transform.localPosition = new Vector3(0, 0, 0);
                    break;
                }
            }
            if (!activeBullet)
            {
                GameObject obj = Instantiate(mapPrefabs, transform);
                obj.SetActive(true);
                bulletShooters.Add(obj);
            }
        }
    }
    // TODO : ObjectPool을 이용해 총알 생성을 구현해봅시다.
}
