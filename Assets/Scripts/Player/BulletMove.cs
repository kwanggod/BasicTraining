using UnityEngine;
using UnityEngine.Pool;
/// <summary>
/// 총알을 움직이는 스크립트.
/// </summary>
public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    private IObjectPool<GameObject> bulletPool = null;

    private void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        Invoke("Despawn", 1f);
    }
    private void Despawn()
    {
        bulletPool.Release(gameObject);
    }
    public void SetBulletPool(IObjectPool<GameObject> bulletPool)
    {
        this.bulletPool = bulletPool;
    }
    // TODO: 총알이 화면 밖으로 나가면 Pool에 돌아가게끔 만들어보자
}
