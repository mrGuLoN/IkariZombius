using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class BulletController : MonoBehaviour
{   
    [SerializeField] private float timeToDestruct;
    [SerializeField] private LayerMask layerMask, stageTerrain;
    [SerializeField] PollerObject.ObjectInfo.ObjectType blood, wall, glass;

    private Vector3 _previousStep, _direction, _firstPoint;
    private float _damage, _distance;
    private Rigidbody _rb;
    private float _timer;
    private Transform _thisTransform, _startTransform;
    private TrailRenderer _trailRender;
    
    void Awake()
    {
        _timer = 0;
        _rb = GetComponent<Rigidbody>();
        _thisTransform = GetComponent<Transform>();
        _trailRender = GetComponent<TrailRenderer>();
        _trailRender.enabled = false;        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        _timer += Time.deltaTime;
        if (_timer >= timeToDestruct)
        {
            Destroy();
        }
        _distance = Vector3.Distance(_previousStep, _thisTransform.position);
        BulletFly();
    }

    private void BulletFly()
    {        
        RaycastHit hit = new RaycastHit();
        if (_distance == 0.0f)
            _distance = 1e-05f;
        if (Physics.Raycast(_previousStep, _thisTransform.forward, out hit, _distance * 0.9999f, layerMask)) //ѕровер€ем было ли столкновение до этого момента
        {
            if (hit.transform.gameObject.CompareTag("Enemy"))                                               //если тэг преп€тстви€ противник - кровь и урон, нет - просто искры, нет преп€тствий - полет дальше
            {
                GameObject hole = PollerObject.Instance.GetObject(blood);                       
                _direction = hit.point - _firstPoint;
                hole.transform.position = hit.point;
                hole.transform.up = _direction.normalized;
                RaycastHit hit2 = new RaycastHit();
                if (Physics.Raycast(hit.point, Vector3.down, out hit2, 5f, stageTerrain))
                {                   
                    hole.transform.SetParent(hit2.transform.gameObject.transform);
                }
                hit.transform.gameObject.GetComponent<DamageZone>().Damage(_damage);

            }
            else
            {
                GameObject hole = PollerObject.Instance.GetObject(wall);
                hole.transform.position = hit.point;
            }
            Destroy();
        }
        _previousStep = _thisTransform.position;
    }


    private void Destroy()
    {
        _timer = 0;
        _trailRender.enabled = false;
        
        _rb.velocity = Vector3.zero;
        PollerObject.Instance.DestroyGameObject(this.gameObject);        
    }

    public void UpDateData(float damage, float speed, Vector3 firePoint)
    {
        _previousStep = firePoint;
        _firstPoint = firePoint;
        _timer = 0;
        _rb.velocity = _thisTransform.forward * speed;
        _damage = damage;
        _trailRender.enabled = true;
    }
}
