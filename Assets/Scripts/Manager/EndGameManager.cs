using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    #region CUSTOM METHOD
    public void GotoMenu()
    {
        // Changement de sc�ne
        SceneManager.LoadScene("MenuScene");
    }
    #endregion
}
