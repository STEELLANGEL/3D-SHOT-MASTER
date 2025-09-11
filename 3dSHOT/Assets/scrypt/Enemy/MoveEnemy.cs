using System;
using UnityEngine;

namespace Enemy
{
    public class MoveEnemy : MonoBehaviour
    {
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField] float _actualSpeed;

        [SerializeField] float _tochetRotate = 70f;

        private bool _isTouhted = false;

        Rigidbody _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }
        void FixedUpdate()
        {
            _actualSpeed = _moveSpeed;

            if (_isTouhted)
            {
                transform.Rotate(0, _tochetRotate, 0);
            }

            MoveForward();
        }

        public void MoveForward()
        {
            transform.Translate(Vector3.forward * _actualSpeed * Time.deltaTime); // transform.Translate - передвигает обьект
                                                                                  // transform в целом двигает, поворачивает, задает силу двидения и вектор обьекта.
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                _isTouhted = true;
                Debug.Log("Collizion true");
            }
        }

        void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                _isTouhted = false;
            }
        }
    }
}

