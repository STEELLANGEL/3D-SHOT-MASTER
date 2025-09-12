using UnityEngine;

namespace Player
{
    public class Look : MonoBehaviour
    {
        [SerializeField] private Transform _head;                                                    // ���� ������ ������ (������ ������� ������) � ����������
        [SerializeField] private Transform _body;                                                    // ���� ������ ���� � ����������
        [SerializeField] private float _horizontalSens = 9.0f;                                       // �������� �������� �� �����������
        [SerializeField] private float _verticalSens = 9.0f;                                         // �������� �������� �� ���������
        [SerializeField] private float _minVerticalAngle = -45.0f;                                   // ����������� ���� �������� �� �����������
        [SerializeField] private float _maxVerticalAngle = 45.0f;                                    // ������������ ���� �������� �� �����������
        [SerializeField] private bool _invertYAxis = false;                                          // ������������� ��������� (�����)

        private float _mousePositionX = 0f;                                                          // ������� ���� X (����������) ������� ���������
        private float _mousePositionY = 1f;                                                          // ������� ���� Y (����������) ������� ���������

        private void Awake()
        {
            _mousePositionX = transform.eulerAngles.x;                                               // ������������� �������� ��������� ���� ������ �������� �������� �������� ������� �� ��� X,
                                                                                                     // ����� ��� ������ ���� �������� ������ �� ������������� � ������� ����������. 

            _mousePositionY = transform.eulerAngles.y;                                               // ���� ����� � Y
        }


        private void Update()
        {
            LookInput();
        }

        private void LookInput()
        {
            _mousePositionX += Input.GetAxis("Mouse X") * _horizontalSens;                           // �������� ���������� ��������� X ���� � �������� �� ��������

            _mousePositionY += Input.GetAxis("Mouse Y") * _verticalSens * (_invertYAxis ? 1f : -1f); // �������� ���������� ��������� Y ���� � �������� �� ��������
                                                                                                     // � �������� �� ������� 9������ ��� ���, ����� ����� �������� ������ �� y ���

            _mousePositionY = Mathf.Clamp(_mousePositionY, _minVerticalAngle, _maxVerticalAngle);    // ������������ ���������� �������� ���������� _mousePositionY
                                                                                                     // ������������ ��� ����������� ��������� ���������
                                                                                                     // � ���������� minimunVert � maximumVert
                                                                                                     // Math.Clamp(���������� ������� ������������, ������ ����� (��), ������ ����� (�� �������))

            _head.localEulerAngles = new Vector3(_mousePositionY, 0, 0);                             // ������� ������-������ (head), �� ��� X �������� ���������� ������.

            _body.eulerAngles = new Vector3(0, _mousePositionX, 0);                                  // ������� ������-���� (body), �� ��� Y �������� ���������� ������
        }
    }
}