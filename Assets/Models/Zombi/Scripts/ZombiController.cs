using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ZombiController : MonoBehaviour
{
    public Transform player;
    [SerializeField] private float minSpeed, maxSpeed, distanceAttack, aniSpeed, health, damage;

   
    private Transform _thisTR;
    private Animator _thisAni;
    private AudioSource _audio;
    private CharacterController _ch;
    private EnemyHealth _enemyHealth;
    private float _distance, _realSpeed, _realSpeedAnimation;
    private bool _jdun;
    void Start()
    {
        _thisTR = GetComponent<Transform>();
        _thisAni = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        _ch = GetComponent<CharacterController>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _enemyHealth.UpdateHealth(health);
        _realSpeed = Random.Range(minSpeed, maxSpeed);
        _realSpeedAnimation = _realSpeed * aniSpeed;
        _audio.pitch = aniSpeed*_realSpeed-0.4f;
        _thisAni.SetFloat("Speed", _realSpeedAnimation);
        _jdun = true;
        StartCoroutine(JustWait());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _distance = (_thisTR.position.x - player.position.x) * (_thisTR.position.x - player.position.x) + (_thisTR.position.z - player.position.z) * (_thisTR.position.z - player.position.z);
        MovementAndRotation();
        AnimationController();
        SavePositionY();
    }

    private void SavePositionY()
    {
        _thisTR.position = new Vector3(_thisTR.position.x, 0, _thisTR.position.z);
    }

    private void MovementAndRotation()
    {
        _thisTR.LookAt(new Vector3(player.position.x, 0, player.position.z));
        if (_distance >= distanceAttack*distanceAttack && _jdun == false)
        {
            _ch.Move(transform.forward * _realSpeed * Time.deltaTime);
        }
        else
        {
            _ch.Move(Vector3.zero);
        }
                          
    }

    private void AnimationController()
    {
       
        if (_distance <= distanceAttack * distanceAttack)
        {
            _thisAni.SetBool("Attack", true);
        }
        else
        {
            _thisAni.SetBool("Attack", false);
        }
    }

    public void GiveDamage()
    {
        if (_distance <= distanceAttack * distanceAttack)
        {
            player.transform.gameObject.GetComponent<Health>().Damage(damage);
        }
       
    }

    IEnumerator JustWait()
    {
        yield return new WaitForSeconds(0.1f);
        _jdun = false;

    }
}
