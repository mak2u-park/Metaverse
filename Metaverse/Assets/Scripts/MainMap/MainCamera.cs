using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MainCamera : MonoBehaviour
{
    public Transform Target;
    private Vector3 offSet;

    // Start is called before the first frame update
    void Start()
    {
        if (Target == null)
            return;
        offSet = transform.position - Target.position; // zÃà Â÷ÀÌ
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Target == null)
            return;
        Vector3 desiredPosition = Target.position + offSet;
        desiredPosition.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f);
        
    }
}
