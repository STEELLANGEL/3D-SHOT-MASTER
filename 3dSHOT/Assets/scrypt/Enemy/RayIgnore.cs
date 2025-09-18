using UnityEngine;

public class RayIgnore : MonoBehaviour
{
    [SerializeField] public Transform _ignoreObject;

    public LayerMask myLayerMask;

    // Update is called once per frame
    void Update()
    {
        Ray _ray = new Ray(_ignoreObject.position, _ignoreObject.up);  

        RaycastHit _rayHit;

        bool _isHitSomething = Physics.Raycast( _ray, out _rayHit );

        if (_isHitSomething)
        {
            Debug.DrawLine(_ray.origin, _rayHit.point);
        }
    }

    // � ��� IGNORE OBJECT ( � ���������� ) ������ ������ �������� �����( �������� ������� ����� ���������)
    // � ���� myLayerMask ��������� ����� ������� ����� �������� (����� ������ ���� ������ (�������) �� �������� ������ (���� ��������)!
    // ������ ������� ��� ��������������� ������ � ������, �� ������������ �� � ������ �������
}

