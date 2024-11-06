using System.Collections.Generic;
using UnityEngine;
using Zenject;
public abstract class ObstacleBase : MonoBehaviour
{
    [SerializeField] private GameObject[] _explosionEffects;
    private GameManager _gameManager;
    private LevelPrefabManager _levelPrefabManager;
    private PlayerController _playerController;
    private bool _isKillable = true;
    [SerializeField] internal List<GameObject> _coins = new List<GameObject>();
    [SerializeField] internal List<GameObject> _obstacle = new List<GameObject>();
    [SerializeField] internal List<GameObject> _hammer = new List<GameObject>();
    internal List<GameObject> _diactivateObject = new List<GameObject>();
    
    [Inject]
    private void Construct(GameManager gameManager, LevelPrefabManager levelPrefabManager, PlayerController playerController)
    {
        _gameManager = gameManager;
        _levelPrefabManager = levelPrefabManager;
        _playerController = playerController;
    }

    private void Start()
    {
        Debug.Log(_obstacle.Count);
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (_playerController.IsHitPressed && AnimationTrigger._animationPlay)
        {
            DisableKillAbility();
            _gameManager.PlayerHit();
            ActivateHitEffects();
            // _diactivateObject.Add(other.gameObject);
            // Debug.Log(_diactivateObject.Count);
            gameObject.SetActive(false);
            _playerController.ResetHitPressed();
        }
        else if (_isKillable)
        {
            _gameManager.PlayerDied();
        }
        
        StopAllCoroutines();
    }
    
    public void DisableKillAbility()
    {
        _isKillable = false;
    }
    public void ActivateHitEffects()
    {
        foreach (var effect in _explosionEffects)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
        }
    }
    public virtual void ResetObstacle()
    {
        // _diactivateObject.AddRange(_coins);
        // _diactivateObject.AddRange(_obstacle);
        // //_diactivate.AddRange(_hammer);
        // Debug.Log("Objects to activate: " + _diactivateObject.Count);
        // foreach (var dis in _diactivateObject)
        // {
        //    Debug.Log("ACTIV");
        //     dis.SetActive(true);
        // }
        //
        // _diactivateObject.Clear();
        _isKillable = true;
    }
}
