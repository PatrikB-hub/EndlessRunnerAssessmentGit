using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class MainMenuScript : MonoBehaviour
{

    #region QuitMethod
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();

    }
    #endregion


}
