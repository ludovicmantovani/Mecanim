using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomState : StateMachineBehaviour
{
    #region PRIVATE VARIABLE
    // Nombre de choix d'animation possibles
    [SerializeField] private int _stateNumber = 0;
    // Pourcentage de temps parcourus avant changement d'animation
    [Range(0, 100)]
    [SerializeField] private int _switchTimePercent = 90;
    // Durée avant le changement d'animation
    [SerializeField]
    private float _switchTime = 0f;
    // Flag indiquant que le choix de la prochaine animation est effectué
    [SerializeField]
    private bool _haveNextChange = false;
    #endregion

    #region BUILTIN METHOD
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Indique qu'aucune prochaine animation n'est choisie 
        _haveNextChange = false;
        // Reset du paramètre "RandomIdle" de l'animator
        animator.SetInteger("RandomIdle", -1);
        // Test si besoin de calculer le temps avant changement animation
        if (_switchTime == 0f)
        {
            // Calcul et assignation du temp correpondant à 90% de l'animation
            _switchTime = _switchTimePercent * animator.GetCurrentAnimatorStateInfo(layerIndex).length / 100;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Test si % de l'animation "maître" parcourue
        if (stateInfo.normalizedTime >= _switchTime && !_haveNextChange )
        {
            // Assignation du choix aléatoire de la prochaine animation au paramètre "RandomIdle" de l'animator
            animator.SetInteger("RandomIdle", Random.Range(0, _stateNumber));
            // Indique que l'on a effectué le choix de la prochaine animation
            _haveNextChange = true;
        }
    }
    #endregion
}
