using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorTest : MonoBehaviour
{
    Vector3 zeroVector = Vector3.zero;
    Vector3 destVector = new Vector3(10, 10, 10);

    // Start is called before the first frame update
    void Start()
    {
        Debug.LogFormat("두 점 사이의 거리 : {0}", (destVector - zeroVector).magnitude);
        Debug.LogFormat("목적지에서 원점으로 가는 방향 : {0}", (destVector - zeroVector).normalized);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
