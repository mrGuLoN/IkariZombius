using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask layerGunPlane;
    [SerializeField] private float speed, health;
    [SerializeField] private Transform bonePointRotation, pointRotation;
    [SerializeField] private Animator gunAnimator;
    private Transform _thisTransform;
    private Health _health;
    private PlayerAnimation _playerAnimation;
    private PlayerMovement _playerMovement;
    private Camera _camera;
    private Vector2 _movement;
    private Vector3 _hitPoint, _direction;

    void Start()
    {
        _thisTransform = GetComponent<Transform>();
        _health = GetComponent<Health>();
        _health.UpdateData(health);
        _camera = Camera.main;
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
         GunController();
        if (Input.GetKeyDown(KeyCode.R)) gunAnimator.SetTrigger("Reload");
    }

    private void FixedUpdate()
    {     
        _movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        PlayerRotation();
        PointRotationController();
        if (_movement == Vector2.zero)
        {
            Idle();
        }
        else
        {
            PlayerMovement();
        }       
        SavePositionY();
    }

    private void SavePositionY()
    {
        _thisTransform.position = new Vector3(_thisTransform.position.x, 0, _thisTransform.position.z);
    }

    private void PlayerRotation()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100, layerGunPlane))
        {
            _thisTransform.LookAt(new Vector3(hit.point.x, _thisTransform.position.y, hit.point.z));
            _hitPoint = hit.point;
        }
    }

    private void Idle()
    {
        _direction = new Vector3 (_hitPoint.x, _thisTransform.position.y, _hitPoint.z) - _thisTransform.position;
        _direction = _direction.normalized;
        _playerAnimation.IdleMove(_direction.x, _direction.z);
        _playerMovement.Movement(0, 0);
    }

    private void PlayerMovement()
    {
        Vector3 direction = _thisTransform.TransformPoint(new Vector3(_movement.x, 0, _movement.y));
        _playerAnimation.Move(-1*direction.x, -1*direction.z);
        _playerMovement.Movement(_movement.x*speed, _movement.y*speed);
    }

    private void PointRotationController()
    {
        pointRotation.position = bonePointRotation.position;
        pointRotation.LookAt(new Vector3(_hitPoint.x, pointRotation.position.y, _hitPoint.z));
    }

    private void GunController()
    {
        if (Input.GetMouseButton(0))
        {
            gunAnimator.SetBool("Fire", true);
        }
        else
        {
            gunAnimator.SetBool("Fire", false);
        }
    }


}
