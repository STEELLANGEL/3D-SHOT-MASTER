using UnityEngine;

public class ELEMENTS_CONTROL : MonoBehaviour
{
    [SerializeField] GameObject _ocean;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _ocean.SetActive(true);
    }
}
