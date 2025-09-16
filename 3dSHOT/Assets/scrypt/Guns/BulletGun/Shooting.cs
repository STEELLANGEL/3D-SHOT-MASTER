using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] public GameObject _bulletPrefab;  //������ ���� (� ������ ������ ���� ������ Bullet, � ������� ��������� :
                                                       //transform.Translate(Vector3.forward * _speed * Time.deltaTime) ��� �������� ���� (������ ���������� �������� �������

    [SerializeField] public Transform _firePoint;  // ����� ��� ���� �������� ������ (������� ��������� �� ���� ������ ��� �����)
   
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
        Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation); // ������� ������(������ ����, ������� ����� ��������, ������� ����� ��������)

        Debug.Log("������");
    }
}
