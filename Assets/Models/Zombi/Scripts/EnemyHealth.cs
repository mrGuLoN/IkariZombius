using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private LayerMask stageTerrain;
    private Rigidbody[] _ragdollRb;
    private Collider[] _colliders;
    private ZombiController _zb;   
    private Animator _ani;
    private CharacterController _ch;
   
    private float _maxHealth, _currentHealth;
    // Start is called before the first frame update
    void Awake()
    {
        _ani = GetComponent<Animator>();
        _ragdollRb = GetComponentsInChildren<Rigidbody>();
        _colliders = GetComponentsInChildren<Collider>();
        _zb = GetComponent<ZombiController>();
        _ch = GetComponent<CharacterController>();       
        Alive();
        StartBuild();
    }

    

    public void Alive()
    {
        _zb.enabled = true;
        _ani.enabled = true;
        _ch.enabled = true;
        
        for (int i = 0; i < _ragdollRb.Length; i++)
        {
            _ragdollRb[i].useGravity = false;
            _ragdollRb[i].isKinematic = true;
            _colliders[i].transform.gameObject.tag = "Enemy";
            if (i != 0) _colliders[i].isTrigger = true;            
        }
    }

    private void StartBuild()
    {
        for (int i = 0; i < _ragdollRb.Length; i++)
        {
            if (i != 0) _colliders[i].isTrigger = true;
            _colliders[i].transform.gameObject.AddComponent<DamageZone>()._enemyHealth = this.gameObject.GetComponent<EnemyHealth>(); ;
        }
    }

    public void Death()
    {
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(this.transform.position + Vector3.up, Vector3.down, out hit, 3f, stageTerrain))
        {            
            this.transform.SetParent(hit.transform.gameObject.transform);
        }
        _zb.enabled = false;
        _ani.enabled = false;
        _ch.Move(Vector3.zero);
        _ch.enabled = false;      
        for (int i = 0; i < _ragdollRb.Length; i++)
        {
            _ragdollRb[i].useGravity = true;
            _ragdollRb[i].isKinematic = false;            
            if (i != 0) _colliders[i].isTrigger = false;            
        }
       
    }

    public void UpdateHealth(float health)
    {
        _maxHealth = health;
        _currentHealth = health;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Death();
        }
    }
}
