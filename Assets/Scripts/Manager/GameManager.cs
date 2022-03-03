using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    #region PRIVATE VARIABLE
    // Script pour activation du ragdoll
    [SerializeField] RagdollController _ragdollController;

    // Falg d�faite
    private bool _isDefeat = false;
    // Timer avant de charger la scene perdue
    private float _defeatTimer = 5f;
    #endregion

    #region BUILTIN METHOD
    // Update is called once per frame
    void Update()
    {
        // En cas de d�faite, on attend la dur�e du timer avant de charger la sc�ne
        if (_isDefeat)
            if (_defeatTimer <= 0f)
                SceneManager.LoadScene("LooseScene");
            else
                _defeatTimer -= Time.deltaTime;
    }
    #endregion

    #region CUSTOM METHOD
    public void LooseGame()
    {
        // Lancement du ragdoll
        if (_ragdollController)
            _ragdollController.ActiveRagdoll();
        // Lancement du timer avant changement de sc�ne
        _isDefeat = true;
    }
    public void WinGame()
    {
        // Changement de sc�ne
        SceneManager.LoadScene("WinScene");
    }
    #endregion
}
