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
        Debug.LogFormat("�� �� ������ �Ÿ� : {0}", (destVector - zeroVector).magnitude);
        Debug.LogFormat("���������� �������� ���� ���� : {0}", (destVector - zeroVector).normalized);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
