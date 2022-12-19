using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private float timeToDestruct;
    [SerializeField] private bool randomDamage;
    [SerializeField] private float damage;
    [SerializeField] private float minRandLimit;
    [SerializeField] private float maxRandLimit;
    
    [SerializeField] private float startPoinOfDamageReduction;
    [SerializeField] private float finalDamageInPercent;
    [SerializeField] private AnimationCurve damageReductionGraph;
    [SerializeField] private int startSpeed;
    [SerializeField] private PollerObject.ObjectInfo.ObjectType blood, wall, glass;
    [SerializeField] private LayerMask layerMask;
   

    private Vector3 _previousStep, direction;
    private float _startTime;
    private float _currentDamage;
    private Rigidbody _rb;
    private Transform _transform;
    private Vector3 _startTransform;
    private bool _firstFrame;
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        _firstFrame = true;
    }

    void FixedUpdate()
    {
        if (_firstFrame == true)
        {
            _startTransform = _transform.position;
            _firstFrame = false;
        }
        Quaternion CurrentStep = _transform.rotation;

        _transform.LookAt(_previousStep, _transform.up);
        RaycastHit hit = new RaycastHit();
        float Distance = Vector3.Distance(_previousStep, _transform.position);
        if (Distance == 0.0f)
            Distance = 1e-05f;        
        if (Physics.Raycast(_previousStep, _transform.TransformDirection(Vector3.back), out hit, Distance * 0.9999f, layerMask) && (hit.transform.gameObject != gameObject))
        {
            if (hit.collider.CompareTag("EnemyBot"))
            {
                GameObject hole = PollerObject.Instance.GetObject(blood);                
                hole.transform.position = hit.point + hit.normal * 0.01f;
                Vector3 line = -_startTransform + hit.point;
                hole.transform.forward = line;
                hole.transform.SetParent(hit.transform);
                hole.GetComponent<AudioSource>().Play(); 
                SendDamage(hit.transform.gameObject, _currentDamage, line);
                damage *= 0.8f;
            }
            else if(hit.transform.gameObject.CompareTag("DestroyerFloor"))
            {
                GameObject hole = PollerObject.Instance.GetObject(glass);
                hole.transform.position = hit.point + hit.normal * 0.01f;
               // hit.transform.gameObject.GetComponent<DestroyerFloor>().Damage();
               // hole.transform.up = -1*hit.normal;
                Vector3 dir = -hole.transform.position + hit.point;
                hole.transform.forward = transform.TransformDirection(_transform.up);
                //hole.GetComponent<AudioSource>().Play();
                DestroyNow();                
            }
            else
            {
                GameObject hole = PollerObject.Instance.GetObject(wall);
                hole.transform.position = hit.point + hit.normal * 0.01f;
              
                hole.transform.forward = -_startTransform + hit.point;

                // hole.GetComponent<AudioSource>().Play();
                // DestroyNow();
            }
            
        }

        _transform.rotation = CurrentStep;

        _previousStep = _transform.position;
    }

    void DestroyNow()
    {        
        PollerObject.Instance.DestroyGameObject(this.gameObject);
        _firstFrame = true;
    }

    void SendDamage(GameObject Hit, float dmg, Vector3 traectory)
    {
        traectory = traectory.normalized;
      //  Hit.transform.gameObject.GetComponent<Damage>().DamageTake(traectory);
        PollerObject.Instance.DestroyGameObject(this.gameObject);
        _firstFrame = true;
    }

    float GetDamageCoefficient()
    {
        float Value = 1.0f;
        float CurrentTime = Time.time - _startTime;
        Value = damageReductionGraph.Evaluate(CurrentTime / timeToDestruct);

        return Value;
    }

    public void UpdateData(float damage, float speedBullet)
    {
        _rb.velocity = _transform.forward * speedBullet;
        direction = _transform.TransformDirection(_transform.forward);
        Invoke("DestroyNow", timeToDestruct);

        _previousStep = _transform.position;

        _startTime = Time.time;

        _currentDamage = damage;
        if (randomDamage)
            _currentDamage += Random.Range(minRandLimit, maxRandLimit);

        Keyframe[] ks;
        ks = new Keyframe[3];

        ks[0] = new Keyframe(0, 1);
        ks[1] = new Keyframe(startPoinOfDamageReduction / 100, 1);
        ks[2] = new Keyframe(1, finalDamageInPercent / 100);


        damageReductionGraph = new AnimationCurve(ks);
    }

}
