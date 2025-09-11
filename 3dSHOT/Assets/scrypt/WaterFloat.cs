using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class WaterFloat : MonoBehaviour
{
    public Rigidbody _rb;

    public float depthBetSub;

    public float displacementAmt;

    public int floaters;

    public float waterDrag;

    public float waterAngularDrag;

    public WaterSurface water;

    WaterSearchParameters Search;

    WaterSearchResult SearchResult;

    void FixedUpdate()
    {
        _rb.AddForceAtPosition(Physics.gravity / floaters, transform.position, ForceMode.Acceleration);

        Search.startPositionWS = transform.position;

        water.ProjectPointOnWaterSurface(Search, out SearchResult);

        if (transform.position.y < SearchResult.projectedPositionWS.y)
        {
            float displacmentMulti = Mathf.Clamp01((SearchResult.projectedPositionWS.y - transform.position.y) / depthBetSub * displacementAmt);

            _rb.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacmentMulti, 0f), transform.position, ForceMode.Acceleration);

            _rb.AddForce(displacmentMulti * -_rb.linearVelocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);

            _rb.AddTorque(displacmentMulti * -_rb.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}


// ///////                                            (                     ),///////////
//////////                                ////
///////////                 -                              Empty objecft (CreateEmpty)                        .///
////                                 ,            (                                            (                   )
////                                        (                       4      ) //                                      ///

////////////   !!!!!!!!!!
////////////                                  (                 !)                                    (floats)                          ///////
///////                        Water Angular Drag ,                           (                                   ,                                                                    )
