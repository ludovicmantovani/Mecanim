using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLife : MonoBehaviour
{
    #region PRIVATE VARIABLE
    [SerializeField] private int _lifePoint = 5;
    [SerializeField] bool _isPlayer = true;
    [SerializeField] private GameManager _gameManager;

    private bool _isAlive = true;

    public bool IsAlive
    {
        get { return _isAlive; }
    }
    #endregion

    #region BUILTIN METHOD
    void Update()
    {
        if (_isAlive && _lifePoint <= 0)
        {
            _isAlive = false;
            if (_gameManager)
            {
                if (_isPlayer)
                    _gameManager.LooseGame();
                else
                    _gameManager.WinGame();
            }
        }
    }
    #endregion

    #region CUSTOM METHOD
    public void TakeDamage()
    {
        if (_isAlive)
            _lifePoint -= 1;
    }

    public void Cure()
    {
        if (_isAlive && _lifePoint < 5)
            _lifePoint += 1;
    }
    #endregion

}
