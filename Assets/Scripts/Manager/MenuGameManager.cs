using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameManager : MonoBehaviour
{
    #region PRIVATE VARIABLE
    [SerializeField]
    // Animator du personage
    private Animator _characterAnimator;
    #endregion

    #region CUSTOM METHOD
    public void LaunchGame()
    {
        // Lancement de l'animation "Pr�t au combat"
        _characterAnimator.SetTrigger("Ready");
    }

    void StartBattle()
    {
        // Changement de sc�ne
        SceneManager.LoadScene("GameScene");
    }
    #endregion
}
