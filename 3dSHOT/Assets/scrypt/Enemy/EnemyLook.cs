using UnityEngine;
using UnityEngine.UIElements;

namespace Enemy
{
    public class EnemyLook : MonoBehaviour
    {
        [SerializeField] private float _obstacleRange = 5.0f;  // ���������� �� �����������  , � ���� ���������� �� ������������ ������, ��� ��� ����������, ���� ����������.

        [SerializeField] public float _targetDistance = 10f;   // ���������� �� ������ (������� �����)
                                                  

        [SerializeField] private float _rotationAngle = 110f;                       // ���������� � ������������ � ����������� ����� �������� �����
                                                                                    // ��� ����������� �����������.

        [SerializeField] bool _enabled = false;

        bool _IsHitPlayer = false;

        [SerializeField] public GameObject _bulletPrefab;  //������ ���� (� ������ ������ ���� ������ Bullet, � ������� ��������� :
                                                           //transform.Translate(Vector3.forward * _speed * Time.deltaTime) ��� �������� ���� (������ ���������� �������� �������

        [SerializeField] public Transform _firePoint;  // ����� ��� ���� �������� ������ (������� ��������� �� ���� ������ ��� �����)

        float _shootTimer;

        [SerializeField] float _delayShoot = 60f;

        [SerializeField] GameObject _rotation;

        private void Start()                                                        
        {
            transform.eulerAngles = new Vector3(0, RandomAngle(), 0);               // ������������ ����� � ��������� ����������� ��� ��������� ��� �� �����.
                                                                                    // transform.eulerAngles = vector (0 horiz, random � �����, 0 vertical)
                                                                                    // transform.eulerAngles - ������������ � ������� �������

            _shootTimer = _delayShoot;

            _rotation.SetActive(false);
        }
        private void Update()
        {
            ObstacleDetection();    // ��� ����������� ����������� 

            Hunt();
        }

        private void FollowTarget()
        {
            _rotation.SetActive(true);
        }

        private void LeaveTarget()
        {
            _rotation.SetActive(false);
        }

        public void Hunt()
        {
            if (_IsHitPlayer)
            {
                FollowTarget();

                //_rotation.SetActive(true);

                if (_shootTimer >= _delayShoot)
                {
                    Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation); // ������� ������(������ ����, ������� ����� ��������, ������� ����� ��������)

                    Debug.Log("������");

                    _shootTimer = 1f;
                }
                _shootTimer += 1f;
            }
            if (!_IsHitPlayer)
            {
                _shootTimer = _delayShoot;

                LeaveTarget();
            }
        }

        private void ObstacleDetection()
        {
            ////Ray ray = new Ray(transform.position, transform.forward) - ��� ���� ���������, ����� ��� �����������)//////
            ///
            Ray ray = new Ray();                                                    // ������ ���������� ���� "Ray" (���).

            ray.origin = transform.position;                                        // ����� "����" ������. ((origin) ��������� ����� == (transform.position) ������� ��������� (������ �� ���� ���)

            ray.direction = transform.forward;                                      //���� ��� ������������� ����������� ���� (ray) ����� �� ������� (transform). 
                                                                                    // ����� "����" �����������. (transform.forward - ������ ������)


            RaycastHit hit;                                                         // ��� ������ � ������� ������ ����� ���
                                                                                    // HIT - ����, ��������� � ������.

            if (Physics.Raycast(ray, out hit, _targetDistance))                     // ��������� ����� ����� ����� � �������� 1� �, ���� �� ����� � �����-�� ������, ��������� ���������� �������
                                                                                    // (������ ��������� ����, ������������� ������ - HIT).
                                                                                    // ����� ����� ����� ������ ��� �� ����������� ���� �������.����� ��� ���������� �������� ����, ����� �������
            {
                if (hit.distance <= _obstacleRange)                                 // ���� ��������� ����� ������� ���� � �������� �, ������� �� �����,                                                                   // ������ ��� ����� ���������� _obstacleRange , ��������� ���������� �������.
                {
                    transform.eulerAngles = new Vector3(0, RandomAngle(), 0);       // ������������ ��� ������ �� ��������� ������ (��������� �����������)
                                                                                    // �� ��� ROTATION Y (������ �������)

                    Debug.Log("����� �� ������");
                }
                if (hit.collider.gameObject.CompareTag("Player"))     // ���� ��� �������� � �� �� ������� tag �� ��������� ��������
                {
                    _IsHitPlayer = true;

                    Debug.Log("����� � ������");
                }
                else
                {
                    _IsHitPlayer= false;

                    Debug.Log("����� ������");
                }

            }

            Debug.DrawRay(transform.position, transform.forward * 100f, Color.red); // ������ � ��������� ���, �������� ������������ ����������� ������� "�����"
                                                                                    // transorm.position (������� ������ ������),
                                                                                    // ������� ��� ������� ������ ������� �� 100f ������,� ���������� ��� � ������� ����.
        }

        private float RandomAngle()
        {
            float randomAngle = Random.Range(-_rotationAngle, _rotationAngle);      // ������ ���������� � ��������� ������ �� ���������: �� -_rotationAngle �� +_rotationAngle.

            return randomAngle;                                                     // ���������� ����� ��������� ����� �������� �����
        }

    }
}