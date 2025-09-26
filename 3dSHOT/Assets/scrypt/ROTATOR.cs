using System;
using UnityEngine;

[Serializable]
public class ROTATOR : MonoBehaviour
{

    // �� �� ��� (�� �� ����� ���� �� ��������!!!) �������� ��� ��������������� ������ ������ � �������� (���� � ���������)
    [SerializeField] public Transform _target_Player;

    [SerializeField] public Transform _hunter_Enemy;

    //[SerializeField] public Transform _bullet;

    [SerializeField] public float _rotSpeed = 1.5f;

    [SerializeField] public bool _yNotRotation;

    [SerializeField] public bool _lookAtTarget;

    [SerializeField] public bool _rotToTarget;

    [SerializeField] public bool _rotToTargetAngle;

    [SerializeField] public bool _rotToAngle;

    [SerializeField] public float _customAngle = 90f;

    private void Awake()
    {
        //_bullet.rotation = _hunter_Enemy.rotation;
    }
    private void Update()

    {
    
        if (_lookAtTarget) // ������� �������� ��� �������� (�����������������, ������ �������)
        {
            _hunter_Enemy.LookAt(_target_Player);

            //_bullet.rotation = _hunter_Enemy.rotation;
        }

        if (_rotToTarget)  // ������� ������� � ���� (����� � ������)
        {
            _hunter_Enemy.rotation = Quaternion.Slerp(_hunter_Enemy.rotation,
                Quaternion.LookRotation(_target_Player.position - _hunter_Enemy.position), _rotSpeed * Time.deltaTime);
        }

        if (_rotToTargetAngle)  // ������� ������� � ���� �� ����� �� ���� ��� � ���� (����� � ������)
        {
            _hunter_Enemy.rotation = Quaternion.Lerp(_hunter_Enemy.rotation, _target_Player.rotation, _rotSpeed * Time.deltaTime);

           // _bullet.rotation = _hunter_Enemy.rotation;
        }

        if (_rotToAngle)  // ������� ������� � ���� �� ���������  ���� (����� � ������)
        {
            _hunter_Enemy.rotation = Quaternion.Slerp(_hunter_Enemy.rotation, Quaternion.Euler(0, _customAngle, 0), _rotSpeed * Time.deltaTime);

            //_bullet.rotation = _hunter_Enemy.rotation;
        }

        if (_yNotRotation)  // ��������� �����  �� ���������
        {
            _hunter_Enemy.eulerAngles = new Vector3(0, _hunter_Enemy.eulerAngles.y, 0);
        }
    }
}