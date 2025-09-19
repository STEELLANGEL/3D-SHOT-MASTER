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

        [SerializeField] float _normalizedSpeed; // ����������� �������� ��� �������� �� ���������

        [SerializeField] float _gravity = -9.81f;

        private bool _isGround = false;

        [SerializeField] float _horizontal;
        [SerializeField] float _vertical;

        Vector3 _moveVector;

        Rigidbody _rb;

        Camera _cam;  // ������� ���������� ������ (������� ������� �������� � ��������� ���� (� ������)

        private void Awake()
        {
            _cam = Camera.main; // ���������������� ������ ��� ������� ������������
        }
        void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.freezeRotation = true;  // ��������� ������� ������� (����� �� ������)
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
                // ����������� �������� ��� ����� ��������� (������������ �� ��������������� ���������)
            }

            if (!Input.GetKey(KeyCode.W) &&
                !Input.GetKey(KeyCode.A) &&
                !Input.GetKey(KeyCode.D) &&
                !Input.GetKey(KeyCode.S))
            {
                if (_isGround)
                {
                    _rb.linearVelocity = new Vector3(0f, 0f, 0f);
                    // ������������� ����� ������ ���� ��������� ������ �� �����1
                }
                //if (!_isGround)
                //{
                //    _rb.linearVelocity = new Vector3(0f, _fallspeed, 0f);
                //    // ������������� ����� ������ ���� ��������� ������ � �������!!!

                //    // ���������� � �������� ������� ������� ������
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

            Vector3 _moveVector = _cam.transform.right * _horizontal + _cam.transform.forward * _vertical;  // ����������� �������� � ������� ��������� ���� �������� � 3D

            _moveVector *= _actualSpeed;

            transform.TransformDirection(_moveVector);  //����������� ������ �� ��������� ������� ��������� � ����������.

            // ��������� ������������ ������������ - ��� ������������ ������������ ������������� �������(���� �� ����),
            // ���� ������������� ������� ���, �� ������ ��� �� ���� �������� ������������ ��� ���� ������.
            // ��� ������� -�������� ���� ����� � ��� ��� ��� ������ ����� �������� �����, ��� ����������� � ����� ������� �����(�����, ��, �����, ������) ��� ����������.
            // ���������� ������������ ������������ - ��� ������������, ��� � ���� �������� ���� � �� �� ����������� �� ���� X, Y � Z, �� ������ ���������� � ������������.
            // ��������, �� � ��� ����, ������� �����, ������ ������ ���������� � ������������, �� ������� ����� ��� ��� ����� � ����� � ��� �� �����������.
            // �.�.��� ���� ������, ����� "������", �� ����� ��������� ������ "������" �� ��������� ����������� ��� ����������� �� �������, ���� �� ����������� � �������.

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
