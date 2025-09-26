using UnityEngine;
using UnityEngine.UIElements;

namespace Enemy
{
    public class EnemyLook : MonoBehaviour
    {
        [SerializeField] private float _obstacleRange = 5.0f;  // расстояние до препятствия  , и если расстояние до препятствием меньше, чем эта переменная, враг развернётся.

        [SerializeField] public float _targetDistance = 15f;   // растсояние до игрока (обьекта атаки)

        [SerializeField] private float _rotationAngle = 110f;                       // Переменная с максимальным и минимальным углом поворота врага
                                                                                    // при обнаружении препятствия.

        [SerializeField] bool _enabled = false;

        bool _IsHitPlayer = false;

        [SerializeField] public GameObject _bulletPrefab;  //пребаф пули (в пребаф ДОЛЖЕН быть скрипт Bullet, в котором прописано :
                                                           //transform.Translate(Vector3.forward * _speed * Time.deltaTime) для движения пули (задано постоянное движение префабу

        [SerializeField] public Transform _firePoint;  // точка огт куда вылетает снаряд (заранее созданный на поле обьект или точка)

        float _shootTimer;

        [SerializeField] float _delayShoot = 60f;

        [SerializeField] GameObject _rotation;

        float _huntTime = 1f;

        [SerializeField] float _huntTimer = 60f;

        private void Start()
        {
            transform.eulerAngles = new Vector3(0, RandomAngle(), 0);               // Поворачиваем врага в случайном направлении при появлении его на сцене.
                                                                                    // transform.eulerAngles = vector (0 horiz, random в игрек, 0 vertical)
                                                                                    // transform.eulerAngles - поворачивает в сторону вектора

            _shootTimer = _delayShoot;

            _rotation.SetActive(false);

            Debug.Log("ROTATION OFF");
        }
        private void FixedUpdate()
        {
            GetRayHit();    // для обнаружения препятствий
        }

        private void FollowTarget()
        {
            _rotation.SetActive(true);
        }

        private void LeaveTarget()
        {
            _rotation.SetActive(false);

            _huntTime = 1f;

            Debug.Log("HUNT STOP");

            //ObstacleDetection();
        }

        private void GetRayHit()
        {
            Ray ray = new Ray(transform.position, transform.forward); // - так надо обьявлять, ВНИЗУ ДЛЯ НАГЛЯДНОСТИ)

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    Hunt();

                    Debug.Log("HUNT RUN");
                }

                if (!hit.collider.gameObject.CompareTag("Player"))
                {
                    _huntTime += 1f;
                }

                if (hit.collider.gameObject.CompareTag("Wall") && _huntTime >= _huntTimer)
                {
                    LeaveTarget();
                }

            }

            //RaycastHit[] hitColliders = Physics.RaycastAll(ray, _targetDistance);

            //foreach (RaycastHit hit in hitColliders)
            //{
            //    if (hit.collider.gameObject.CompareTag("Player"))
            //    {
            //        Hunt();

            //        Debug.Log("Столкнуся с Игроком - " + hit.distance);
            //    }

            //    if (!hit.collider.gameObject.CompareTag("Player"))
            //    {
            //        _huntTime += 1;
            //    }

            //    if (_huntTime == _huntTimer)
            //    {
            //        LeaveTarget();
            //    }

            //}
            //Debug.DrawRay(transform.position, transform.forward * _targetDistance, Color.red); // Рисуем в редакторе луч, наглядно показывающий направление взгляда "Врага"
            // transorm.position (позиция нашего игрока),
            // создаем луч впереди нашего обьекта на 100f вперед,и окрашиваем его в красный цвет.

            Debug.DrawRay(transform.position, transform.forward * _targetDistance, Color.red);

        }

        private void Hunt()
        {
            _huntTime = 1f;

            FollowTarget();

            if (_shootTimer >= _delayShoot)
            {
                Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation); // создать обьект(префаб пули, позиция точки выстрела, ротация точки выстрела)

                _shootTimer = 1f;
            }
            _shootTimer += 1f;

        }

        private float RandomAngle()
        {
            float randomAngle = Random.Range(-_rotationAngle, _rotationAngle);      // Создаём переменную с случайным числом из диапазона: от -_rotationAngle до +_rotationAngle.

            return randomAngle;                                                     // возвращаем самое рандомное число поворота врага
        }

    }
}