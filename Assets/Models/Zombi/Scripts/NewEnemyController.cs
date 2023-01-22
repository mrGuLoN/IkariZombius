using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyController : MonoBehaviour
{
    public Transform player;
    [SerializeField] private float minSpeed, maxSpeed, distanceAttack, aniSpeed, health, damage;

    private Rigidbody[] _ragdollRb;
    private float _realSpeed;
    private Collider[] _colliders;
    private EnemyHealth _enHealth;
    private CharacterController _ch;
    private Transform _thisTR;
    void Start()
    {
        RigidbodyAdd();
        _thisTR = GetComponent<Transform>();
        _enHealth.UpdateHealth(health);
        _realSpeed = Random.Range(minSpeed, maxSpeed);
        _ch = GetComponent<CharacterController>();
        _ch.enabled = false;
    }

    private void RigidbodyAdd()
    {
        _ragdollRb = GetComponentsInChildren<Rigidbody>();
        _colliders = GetComponentsInChildren<Collider>();
        _enHealth = GetComponent<EnemyHealth>();
        for (int i = 0; i < _ragdollRb.Length; i++)
        {
            if (i != 0) _colliders[i].isTrigger = true;
            _colliders[i].transform.gameObject.AddComponent<DamageZone>()._enemyHealth =_enHealth ;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _thisTR.LookAt(new Vector3(player.position.x, _thisTR.position.y, player.position.z));
       _ch.Move(_thisTR.forward * _realSpeed * Time.deltaTime);
    }
}
