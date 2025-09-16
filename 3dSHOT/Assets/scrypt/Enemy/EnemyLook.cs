using UnityEngine;
using UnityEngine.UIElements;

namespace Enemy
{
    public class EnemyLook : MonoBehaviour
    {
        [SerializeField] private float _obstacleRange = 5.0f;  // расстояние до препятствия  , и если расстояние до препятствием меньше, чем эта переменная, враг развернётся.

        [SerializeField] public float _targetDistance = 10f;   // растсояние до игрока (обьекта атаки)
                                                  

        [SerializeField] private float _rotationAngle = 110f;                       // Переменная с максимальным и минимальным углом поворота врага
                                                                                    // при обнаружении препятствия.

        [SerializeField] bool _enabled = false;


        //[SerializeField] private ROTATOR _rotator;

        public bool _IsHitPlayer = false;

        //private void Awake()
        //{
        //    _rotator.enabled = false;
        //}
        private void Start()                                                        
        {
            transform.eulerAngles = new Vector3(0, RandomAngle(), 0);               // Поворачиваем врага в случайном направлении при появлении его на сцене.
                                                                                    // transform.eulerAngles = vector (0 horiz, random в игрек, 0 vertical)
                                                                                    // transform.eulerAngles - поворачивает в сторону вектора
        }
        private void Update()
        {
            ObstacleDetection();                                                    // для обнаружения препятствий 
        }

        private void ObstacleDetection()
        {
            ////Ray ray = new Ray(transform.position, transform.forward) - так надо обьявлять, ВНИЗУ ДЛЯ НАГЛЯДНОСТИ)//////
            ///
            Ray ray = new Ray();                                                    // Создаём переменную типа "Ray" (Луч).

            ray.origin = transform.position;                                        // Задаём "Лучу" начало. ((origin) начальная точка == (transform.position) позиция оьъбьекта (нашего от куда луч)

            ray.direction = transform.forward;                                      //Этот код устанавливает направление луча (ray) вперёд от объекта (transform). 
                                                                                    // Задаём "Лучу" направление. (transform.forward - движем вперед)


            RaycastHit hit;                                                         // тот обьект в который обьект попал луч
                                                                                    // HIT - УДАР, попадание в обьект.

            if (Physics.Raycast(ray, out hit, _targetDistance))                     // Запускаем СФЕРУ ПЕРЕД ЛУЧОМ С РАДИУСОМ 1А и, если он попал в какой-то объект, выполняем дальнейшее условие
                                                                                    // (РАДИУС ДАЛЬНОСТЬ ЛУЧА, ВСТРЕТИВШИЙСЯ ОБЬЕКТ - HIT).
                                                                                    // сФЕРА НУЖНА ЧТОБЫ ТОНКИЙ ЛУЧ НЕ ПРОМАХНКЛСЯ МИМО ОБЬЕКТА.Сфера это расширение диаметра луча, можно сказать
            {
                if (hit.distance <= _obstacleRange)                                 // Если дистанция между началом луча и объектом в, который он попал,                                                                   // меньше или ровна переменной _obstacleRange , выполняем дальнейшее условие.
                {
                    transform.eulerAngles = new Vector3(0, RandomAngle(), 0);       // поворачиваем наш обьект на созданный вектор (рандомное направление)
                                                                                    // по оси ROTATION Y (именно поворот)

                    Debug.Log("попал по стенке");
                }
                if (hit.collider.gameObject.CompareTag("Player"))     // Есди луч попадант в то то указали tag то выполняет действие
                {
                    _IsHitPlayer = true;

                    Debug.Log("Попал в игрока");
                }
                else
                {
                    _IsHitPlayer= false;

                    Debug.Log("игрок сбежал");
                }
            }

            Debug.DrawRay(transform.position, transform.forward * 100f, Color.red); // Рисуем в редакторе луч, наглядно показывающий направление взгляда "Врага"
                                                                                    // transorm.position (позиция нашего игрока),
                                                                                    // создаем луч впереди нашего обьекта на 100f вперед,и окрашиваем его в красный цвет.
        }

        private float RandomAngle()
        {

            float randomAngle = Random.Range(-_rotationAngle, _rotationAngle);      // Создаём переменную с случайным числом из диапазона: от -_rotationAngle до +_rotationAngle.

            return randomAngle;                                                     // возвращаем самое рандомное число поворота врага
        }
    }
}