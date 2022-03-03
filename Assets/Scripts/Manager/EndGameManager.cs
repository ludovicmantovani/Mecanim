using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    #region CUSTOM METHOD
    public void GotoMenu()
    {
        // Changement de scène
        SceneManager.LoadScene("MenuScene");
    }
    #endregion
}
