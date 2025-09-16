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


        //[SerializeField] private ROTATOR _rotator;

        public bool _IsHitPlayer = false;

        //private void Awake()
        //{
        //    _rotator.enabled = false;
        //}
        private void Start()                                                        
        {
            transform.eulerAngles = new Vector3(0, RandomAngle(), 0);               // ������������ ����� � ��������� ����������� ��� ��������� ��� �� �����.
                                                                                    // transform.eulerAngles = vector (0 horiz, random � �����, 0 vertical)
                                                                                    // transform.eulerAngles - ������������ � ������� �������
        }
        private void Update()
        {
            ObstacleDetection();                                                    // ��� ����������� ����������� 
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