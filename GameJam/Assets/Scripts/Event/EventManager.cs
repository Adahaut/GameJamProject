using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EventManager : MonoBehaviour
{
    [SerializeField] GameObject _player;
    PlayerMovement _pM;
    [SerializeField] GameObject _stormEffect;
    public float _stormDuration;
    public float _stormForce;

    private void Start()
    {
        _pM = _player.GetComponent<PlayerMovement>();
    }
    public void Storm(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            _pM.ActiveStorm(_stormDuration, _stormForce, _stormEffect);
        }
    }
}
