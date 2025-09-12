using UnityEngine;

namespace Enemy
{
    public class Shot : MonoBehaviour
    {
        [SerializeField] float _speed = 1.0f;

        [SerializeField] Transform _enemy;

        [SerializeField] Transform _player;

        [SerializeField] Transform _bullet;


        private void Start()
        {

            transform.position = _enemy.position;

        }

        private void FixedUpdate()
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }
}

