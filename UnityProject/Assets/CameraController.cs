using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform m_followTarget;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.FindWithTag("Player");
        if(obj != null) 
        {
            m_followTarget = obj.transform;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(m_followTarget.position, transform.position, Time.fixedDeltaTime * 30.0f);

        

    }
}
