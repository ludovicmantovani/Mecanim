using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    #region PRIVATE VARIABLE
    [SerializeField] private GameObject _player;
    [SerializeField] private float _minPlayerDistanceToAttack = 0.75f;
    [SerializeField] private float _walkSpeed = 2.5f;
    [SerializeField] private float _runSpeed = 3.5f;

    [SerializeField] private Transform[] _wayPointList;


    private Animator _animator;
    private NavMeshAgent _navMeshAgent;
    private Transform _currentTarget;
    private SphereCollider _sphereCollider;

    public Transform Target
    {
        get { return _currentTarget; }
    }

    private bool _onPursuit = false;
    private bool _onAttack = false;
    private CharacterLife _characterLife;
    #endregion

    #region BUILTIN METHOD
    void Start()
    {
        _animator = GetComponent<Animator>();
        _sphereCollider = GetComponent<SphereCollider>();
        if (_player)
            _characterLife = _player.GetComponent<CharacterLife>();
    }

    
    void Update()
    {
        Locomotion();
        Attack();
        UpdateAnimation();
    }

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_player && other.gameObject == _player)
            _onPursuit = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (_player && other.gameObject == _player)
            _onPursuit = false;
    }

    #endregion

    #region CUSTOM METHOD
    private void Locomotion()
    {
        if (_onAttack == false)
        {
            if (_onPursuit && _player && _navMeshAgent)
            {
                // L'ennemi se met ? courrir
                _navMeshAgent.speed = _runSpeed;
                // Il va vers le joueur
                _navMeshAgent.destination = _player.transform.position;
            }
            else // Gestion de la ronde
            {
                // si pas de destination ou destination atteinte
                if (_currentTarget == null
                    || (_currentTarget.position.x == transform.position.x && _currentTarget.position.z == transform.position.z))
                {
                    // Choix de la prochaine destination al?atoirement
                    ChooseRandomTarget();
                }
                if (_navMeshAgent)
                {
                    // L'ennemi marche
                    _navMeshAgent.speed = _walkSpeed;
                    // Assignation de la destination
                    _navMeshAgent.destination = _currentTarget.position;
                }
            }
        }
        else
            // L'ennemi de bouge pas losqu'il attaque
            _navMeshAgent.destination = transform.position;

    }

    private void Attack()
    {
        // Calcul la distance du player
        float playerDistance = Vector3.Distance(_player.transform.position, transform.position);
        // Test si le player est ? port?e
        _onAttack = playerDistance <= _minPlayerDistanceToAttack ? true : false;        
    }

    private void UpdateAnimation()
    {
        if (_animator)
        {
            _animator.SetBool("Pursuit", _onPursuit);
            _animator.SetBool("Attack", _onAttack);
        }
    }

    private void ChooseRandomTarget()
    {
        if (_wayPointList!= null && _wayPointList.Length > 1)
        {
            Transform futurTarget = _wayPointList[Random.Range(0, _wayPointList.Length)];
            if (_currentTarget != null)
            {
                // Recherche al?atoirement une prochine destination de ronde qui n'est pas celle o? l'on est d?ja
                while (futurTarget == _currentTarget)
                {
                    futurTarget = _wayPointList[Random.Range(0, _wayPointList.Length)];
                }
            }
            _currentTarget = futurTarget;
        }
    }

    private void MakeDamage()
    {
        if (_characterLife)
            _characterLife.TakeDamage();
    }
    #endregion
}
