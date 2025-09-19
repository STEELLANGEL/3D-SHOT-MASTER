using UnityEngine;
using System;

namespace Player
{
    [Serializable]
    public class MoveObject : MonoBehaviour
    {
        [SerializeField] float _actualSpeed;
        [SerializeField] public float _run = 20f;
        [SerializeField] float _step = 10f;

        [SerializeField] float _normalizedSpeed; // выравниваем скорость при движении по диагонали

        [SerializeField] float _gravity = -9.81f;

        private bool _isGround = false;

        [SerializeField] float _horizontal;
        [SerializeField] float _vertical;

        Vector3 _moveVector;

        Rigidbody _rb;

        Camera _cam;  // создали переменную камера (которую сделали дочерней к движемому телу (к плееру)

        private void Awake()
        {
            _cam = Camera.main; // инициализировали камеру как главную используюмую
        }
        void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.freezeRotation = true;  // фиксируем ротацию капсулы (ЧТОБЫ НЕ ПАДАЛА)
        }

        void FixedUpdate()
        {

            if (Input.GetKey(KeyCode.W))
                MoveForward();

            if (Input.GetKey(KeyCode.S))
                MoveBack();

            if (Input.GetKey(KeyCode.A))
                MoveLeft();

            if (Input.GetKey(KeyCode.D))
                MoveRight();

            _normalizedSpeed = _actualSpeed / 3;

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) ||
                Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) ||
                Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) ||
                Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                _actualSpeed -= _normalizedSpeed;
                // выравниваем скорость при косом движением (препятствуем не контролируемому ускорению)
            }

            if (!Input.GetKey(KeyCode.W) &&
                !Input.GetKey(KeyCode.A) &&
                !Input.GetKey(KeyCode.D) &&
                !Input.GetKey(KeyCode.S))
            {
                if (_isGround)
                {
                    _rb.linearVelocity = new Vector3(0f, 0f, 0f);
                    // Останавливаем резко игрока если отпустили кнопку НА ЗЕМЛЕ1
                }
                //if (!_isGround)
                //{
                //    _rb.linearVelocity = new Vector3(0f, _fallspeed, 0f);
                //    // Останавливаем резко игрока если отпустили кнопку В ВОЗДУХЕ!!!

                //    // ОБРАЩАЕМСЯ к скорости падения скрипта прыжка
                //}
            }

            _moveVector = GetVector();

            _rb.AddForce(_moveVector);
        }

        private void MoveForward()
        {
            _actualSpeed = _step;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _actualSpeed = _run;
            }
        }

        private void MoveBack()
        {
            _actualSpeed = _step;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _actualSpeed = _run;
            }
        }

        private void MoveLeft()
        {
            _actualSpeed = _step;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _actualSpeed = _run;
            }
        }


        private void MoveRight()
        {
            _actualSpeed = _step;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _actualSpeed = _run;
            }
        }

        private Vector3 GetVector()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");

            Vector3 _moveVector = _cam.transform.right * _horizontal + _cam.transform.forward * _vertical;  // преобразуем движение с камерой правильно чтоб работали в 3D

            _moveVector *= _actualSpeed;

            transform.TransformDirection(_moveVector);  //Преобразует вектор из локальной системы координат в глобальную.

            // Локальное координатное пространство - это пространство относительно родительского объекта(если он есть),
            // если родительского объекта нет, то объект сам по себе является родительским для себя самого.
            // Для примера -вытяните руку вперёд и для вас она всегда будет смотреть вперёд, вне зависимости в какую сторону света(север, юг, запад, восток) она направлена.
            // Глобальное координатное пространство - это пространство, где у всех объектов одни и те же направления по осям X, Y и Z, но разные координаты в пространстве.
            // Например, вы и ваш друг, стоящий рядом, имеете разные координаты в пространстве, но стороны света для вас будут в одном и том же направлении.
            // Т.е.без этой строки, зажав "вправо", мы будем двигаться всегда "вправо" по локальным координатам вне зависимости от стороны, куда мы повернулись и смотрим.

            return _moveVector;
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("PlayField"))
            {
                _isGround = true;
                Debug.Log("Collizion true");
            }
        }

        void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("PlayField"))
            {
                _isGround = false;
            }
        }
    }
}
