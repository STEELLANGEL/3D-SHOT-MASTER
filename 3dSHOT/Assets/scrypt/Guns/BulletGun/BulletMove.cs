using UnityEngine;

namespace Enemy
{
    public class BulletMove : MonoBehaviour
    {
        [SerializeField] float _speed = 1.0f;

        private void FixedUpdate()
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }
}

