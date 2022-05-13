using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFoloww : MonoBehaviour

{
    public Transform target;
    public float followVelocity = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
       // offset = new Vector3();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 directionRaw = target.position - transform.position;
        float distance = directionRaw.sqrMagnitude;
        //transform.position = target.transform.position.normalized;
        transform.position += directionRaw.normalized * followVelocity * Time.fixedDeltaTime * distance;

    }
}
