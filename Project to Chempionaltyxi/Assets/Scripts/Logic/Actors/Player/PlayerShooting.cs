using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Move to camera
public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform _leftGunPoint;
    [SerializeField] private Transform _rightGunPoint;

    [SerializeField] private float _shootingCooldown;

    private bool _readyLeft = true;
    private bool _readyRight = true;

    private IFactoryPlayerProjectile _factoryProjectileService;
    private IInputService _inputService;

    private void Start()
    {
        _factoryProjectileService = AllServices.Instance.GetService<IFactoryPlayerProjectile>();
        _inputService = AllServices.Instance.GetService<IInputService>();
    }

    private void Update()
    {
        if (_inputService.GetLeftShootButton() == true)
            ProcessFire(_leftGunPoint, left: true, _readyLeft);

        if (_inputService.GetRightShootButton() == true)
            ProcessFire(_rightGunPoint, left: false, _readyRight);

    }

    private void ProcessFire(Transform point, bool left, bool ready)
    {
        if (ready == false)
            return;

        _factoryProjectileService.Create(point.position, point.rotation);
        StartCoroutine(CooldownRoutine(left));
    }

    private IEnumerator CooldownRoutine(bool left)
    {
        float cooldown = _shootingCooldown;

        if (left == true)
            _readyLeft = false;
        else
            _readyRight = false;


        while (cooldown > 0f)
        {
            yield return null;
            cooldown -= Time.deltaTime;
        }
        
        if (left == true)
            _readyLeft = true;
        else
            _readyRight = true;
    }

}
