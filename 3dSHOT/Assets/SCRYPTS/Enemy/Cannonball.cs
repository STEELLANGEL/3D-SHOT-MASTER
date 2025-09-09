using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Rigidbody))]                                           // 1
    public class Cannonball : MonoBehaviour
    {
        [SerializeField] float _moveSpeed = 10f;                                             // 2
        private Vector3 _targetPosition;                                            // 3
        private Rigidbody _rigidbody;                                               // 4

        private void Awake()                                                        // 5.0
        {
            _rigidbody = GetComponent<Rigidbody>();                                 // 5.1
        }

        private void FixedUpdate()                                                  // 6.0
        {
            ObjectMove();                                                           // 6.1
        }

        private void OnCollisionEnter(Collision other)                              // 7.0
        {
            gameObject.SetActive(false);                                            // 7.1
        }

        public void SetTargetPosition(Vector3 target)                               // 8.0
        {
            _targetPosition = target;                                               // 8.1
        }

        public void SetMoveSpeed(float speed)                                       // 9.0
        {
            _moveSpeed = speed;                                                     // 9.1
        }

        private void ObjectMove()                                                   // 10.0
        {
            Vector3 moveDirection = transform.position + _targetPosition * Time.deltaTime * _moveSpeed; // 10.1

            _rigidbody.MovePosition(moveDirection);                                 // 10.2
        }
    }
}