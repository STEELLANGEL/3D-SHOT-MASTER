using Unity.VisualScripting;
using UnityEngine;

public class FieldTought : MonoBehaviour
{
    Rigidbody _rb;

    private bool _isTouhted = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_isTouhted)
        {
            
        }
    }

    void OnCollisionEnter(Collision collision )
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isTouhted = true;
            Debug.Log("Collizion true");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isTouhted = false;
            Debug.Log("Collizion false");
        }
    }
}
