using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    #region PRIVATE VARIABLE
    // Animator (a desactiver pour ragdoll)
    private Animator _animator;
    // Character controlleur (a desactiver pour ragdoll)
    private CharacterController _characterController;
    // Player controller controlleur (a desactiver pour ragdoll)
    private PlayerController _playerController;
    #endregion

    #region BUILTIN METHOD
    void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
        _playerController = GetComponent<PlayerController>();
    }
    #endregion

    #region CUSTOM METHOD
    /// <summary>
    /// Désactivation des éléments "génant" le ragdoll
    /// </summary>
    public void ActiveRagdoll()
    {
        if (_playerController)
            _playerController.enabled = false;

        if (_characterController)
            _characterController.enabled = false;

        if (_animator)
            _animator.enabled = false;
    }
    #endregion

}
