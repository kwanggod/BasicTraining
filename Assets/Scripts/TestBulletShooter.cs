using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.InputSystem;

public class TestBulletShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletObject;

    private IObjectPool<GameObject> bulletPool = null;

    public IObjectPool<GameObject> BulletPool
    {
        get
        {
            if (bulletPool == null)
            {
                bulletPool = new ObjectPool<GameObject>(CreateBullet, OnTakeFromPool, OnReturnedToPool, null, true, 10,100);
            }
            return bulletPool;
        }
    }
    private GameObject CreateBullet()
    {
        GameObject bullet = ResetBullet(Instantiate(bulletObject));
        return bullet;
    }
    private void OnTakeFromPool(GameObject bullet)
    {
        ResetBullet(bullet);
    }
    private void OnReturnedToPool(GameObject bullet)
    {
        bullet.SetActive(false);
    }
    private GameObject ResetBullet(GameObject bullet)
    {
        BulletMove bulletMove = bullet.GetComponent<BulletMove>();
        bulletMove.SetBulletPool(bulletPool);
        bullet.transform.position = transform.position;
        bullet.SetActive(true);
        return bullet;
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            BulletPool.Get();
        }
        
    }
}