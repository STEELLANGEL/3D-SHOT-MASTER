using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] public GameObject _bulletPrefab;  //пребаф пули (в пребаф ДОЛЖЕН быть скрипт Bullet, в котором прописано :
                                                       //transform.Translate(Vector3.forward * _speed * Time.deltaTime) для движения пули (задано постоянное движение префабу

    [SerializeField] public Transform _firePoint;  // точка огт куда вылетает снаряд (заранее созданный на поле обьект или точка)
   
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Shot();
        }

    }

    private void Shot()
    {
        Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation); // создать обьект(префаб пули, позиция точки выстрела, ротация точки выстрела)

        Debug.Log("обьект");
    }
}
