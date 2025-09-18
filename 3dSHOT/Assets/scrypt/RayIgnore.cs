using UnityEngine;

public class RayIgnore : MonoBehaviour
{
    [SerializeField] public Transform _ignoreObject;

    public LayerMask myLayerMask;

    // Update is called once per frame
    void Update()
    {
        Ray _ray = new Ray(_ignoreObject.position, _ignoreObject.up);  

        RaycastHit _rayHit;

        bool _isHitSomething = Physics.Raycast( _ray, out _rayHit );

        if (_isHitSomething)
        {
            Debug.DrawLine(_ray.origin, _rayHit.point);
        }
    }

    // в ПОЕ IGNORE OBJECT ( в инспекторе ) кидаем префаб например пулои( предмета который будет игнорится)
    // в поле myLayerMask указываем маску которую будем игнорить (маска должна быть надета (выбрана) на предмете игнора (пуля например)!
    // СКРИПТ БРОСАЕМ КАК САМОСТОЯТЕЛЬНЫЙ ОБЬЕКТ В ПРОЕКТ, не привязывваем ни к какому обьекту
}

