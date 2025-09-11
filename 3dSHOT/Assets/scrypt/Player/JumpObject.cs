using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class JumpObject : MonoBehaviour
    {
        Rigidbody _rb;

        [SerializeField] float _speed;

        [SerializeField] float _jumpSpeed;

        [SerializeField] float _gravity = -9.81f;

        [SerializeField] public float _fallSpeed = -120f;

        bool _isGround = false;

        [SerializeField] float _jumpImpulse = 15f;

        MoveObject _moveScrypt;  // переменна€ дл€ обращени€ к другому скрипту (чтобы через нее взаимодействовать с переменными и методами другого скрипта

        void Start()
        {
            _rb = GetComponent<Rigidbody>();
            Physics.gravity = new Vector3(0, _gravity);
        }

        void FixedUpdate()
        {
            Physics.gravity = new Vector3(0, _gravity);

            _speed = Vector3.Magnitude(_rb.linearVelocity);


            if (_isGround)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    Jump();

                }
                if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Space))
                {
                    LongJump();
                }
            }

            if (!_isGround)
            {
                _rb.AddForce(Vector3.up * (_gravity + _fallSpeed) * Time.deltaTime, ForceMode.Impulse);

                //_rb.freezeRotation = false;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("PlayField"))
                _isGround = true;
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == "PlayField")
                _isGround = false;
        }

        void Jump()
        {
            //_rb.GetComponent<Rigidbody>();

            _rb.linearVelocity = new Vector3(0, _jumpImpulse, 0);
        }

        void LongJump()
        {
            _jumpSpeed = _moveScrypt._run; // ќЅ–јўј≈ћ—я к скорости падени€ скрипта ƒ¬»∆≈Ќ»я
                                           //_rb.GetComponent<Rigidbody>();

            _rb.linearVelocity = new Vector3(0, _jumpSpeed, 0);
        }
    }
}
