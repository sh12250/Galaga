using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static partial class GFunc
{
    // 래핑 : 이미 있는 함수를 사용하기 쉽게 재정의하는 것
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message)
    {
#if DEBUG_MODE
        Debug.Log(message);
#endif
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Assert(bool condition)
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif
    }

    //! Gameobject 받아서 Text 컴포넌트 찾아서 text 필드 값 수정하는 함수
    public static void SetText(this GameObject target, string text)
    {
        Text textComponent = target.GetComponent<Text>();
        // GetComponent<컴포넌트 명>() : 가지고 있는 컴포넌트를 찾는다
        // AddComponent<컴포넌트 명>() : 컴포넌트를 추가해준다
        if (textComponent == null || textComponent == default)
        {
            return;
        }

        textComponent.text = text;
    }

    //! LoadScene 함수 래핑
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
