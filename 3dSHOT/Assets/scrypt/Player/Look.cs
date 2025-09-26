using UnityEngine;

namespace Player
{
    public class Look : MonoBehaviour
    {
        [SerializeField] private Transform _head;                                                    // сюда кидаем голову (камеру дочерне делаем) в инспекторе
        [SerializeField] private Transform _body;                                                    // сюда кидаем тело в инспекторе
        [SerializeField] private float _horizontalSens = 9.0f;                                       // скорость движения по горизонтали
        [SerializeField] private float _verticalSens = 9.0f;                                         // скорость движения по вертикали
        [SerializeField] private float _minVerticalAngle = -45.0f;                                   // минимальный угол поворота по горизонтали
        [SerializeField] private float _maxVerticalAngle = 45.0f;                                    // максимальный угол поворота по горизонтали
        [SerializeField] private bool _invertYAxis = false;                                          // инвертировать вертикаль (опция)

        private float _mousePositionX = 0f;                                                          // позиция мыши X (переменная) текущее положение
        private float _mousePositionY = 1f;                                                          // позиция мыши Y (переменная) текущее положение

        private void Awake()
        {
            _mousePositionX = transform.eulerAngles.x;                                               // Устанавливаем значение положения мыши равным значению текущего поворота объекта по оси X,
                                                                                                     // чтобы при начале игры персонаж игрока не поворачивался в нулевые координаты. 

            _mousePositionY = transform.eulerAngles.y;                                               // Тоже самое с Y
        }


        private void Update()
        {
            LookInput();
        }

        private void LookInput()
        {
            _mousePositionX += Input.GetAxis("Mouse X") * _horizontalSens;                           // получаем координату положения X мыши и умножаем на скорость

            _mousePositionY += Input.GetAxis("Mouse Y") * _verticalSens * (_invertYAxis ? 1f : -1f); // получаем координату положения Y мыши и умножаем на скорость
                                                                                                     // и умножаем на позицию 9инверт или нет, ЧТОБЫ МОЖНО ВКЛЮЧИТЬ ИНВЕРТ ПО y ОСИ

            _mousePositionY = Mathf.Clamp(_mousePositionY, _minVerticalAngle, _maxVerticalAngle);    // Ограничиваем полученное значение переменной _mousePositionY
                                                                                                     // максимальным или минимальным значением указанным
                                                                                                     // в переменных minimunVert и maximumVert
                                                                                                     // Math.Clamp(координата которую ограничиваем, первая точка (ОТ), вторая тоска (до которой))

            _head.localEulerAngles = new Vector3(_mousePositionY, 0, 0);                             // Вращаем объект-голову (head), по оси X согласно полученным данным.

            _body.eulerAngles = new Vector3(0, _mousePositionX, 0);                                  // Вращаем объект-тело (body), по оси Y согласно полученным данным
        }
    }
}