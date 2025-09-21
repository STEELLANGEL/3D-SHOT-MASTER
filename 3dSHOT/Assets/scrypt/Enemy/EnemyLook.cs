using UnityEngine;
using UnityEngine.UIElements;

namespace Enemy
{
    public class EnemyLook : MonoBehaviour
    {
        [SerializeField] private float _obstacleRange = 5.0f;  // ���������� �� �����������  , � ���� ���������� �� ������������ ������, ��� ��� ����������, ���� ����������.

        [SerializeField] public float _targetDistance = 30f;   // ���������� �� ������ (������� �����)


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

        float _huntTime = 20f;

        [SerializeField] float _huntTimer;

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
        }

        private void FollowTarget()
        {
            _rotation.SetActive(true);
        }

        private void LeaveTarget()
        {
            _rotation.SetActive(false);

            //ObstacleDetection();
        }

        private void ObstacleDetection()
        {
            Ray ray = new Ray(transform.position, transform.forward); // - ��� ���� ���������, ����� ��� �����������)


            RaycastHit[] hitColliders = Physics.RaycastAll(ray, _targetDistance);

            foreach (RaycastHit hit in hitColliders)
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    Debug.Log("��������� � ������� - " + hit.distance);

                    Hunt();
                }

                //if (!hit.collider.gameObject.CompareTag("Player"))
                //{
                //    Debug.Log("���� ������ - ");

                //    LeaveTarget();
                //}
            }
            //Debug.DrawRay(transform.position, transform.forward * _targetDistance, Color.red); // ������ � ��������� ���, �������� ������������ ����������� ������� "�����"
            // transorm.position (������� ������ ������),
            // ������� ��� ������� ������ ������� �� 100f ������,� ���������� ��� � ������� ����.

            Debug.DrawRay(transform.position, transform.forward * _targetDistance, Color.red);

        }

        private void Hunt()
        {
            FollowTarget();

            if (_shootTimer >= _delayShoot)
            {
                Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation); // ������� ������(������ ����, ������� ����� ��������, ������� ����� ��������)

                _shootTimer = 1f;
            }
            _shootTimer += 1f;
        }

        private float RandomAngle()
        {
            float randomAngle = Random.Range(-_rotationAngle, _rotationAngle);      // ������ ���������� � ��������� ������ �� ���������: �� -_rotationAngle �� +_rotationAngle.

            return randomAngle;                                                     // ���������� ����� ��������� ����� �������� �����
        }

    }
}