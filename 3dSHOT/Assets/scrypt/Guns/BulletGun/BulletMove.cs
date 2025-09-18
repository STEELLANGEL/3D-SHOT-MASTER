using UnityEngine;

namespace Enemy
{
    public class BulletMove : MonoBehaviour
    {
        [SerializeField] float _speed = 1.0f;

        Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                _rb.linearVelocity = Vector3.zero;
            }
        }
    }

}

