using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private float speed, minZombi, maxZombi, upDateZombi;
    [SerializeField] private GameObject[] stagePrefab;
    [SerializeField] private int maxZombieOnMap;
   
    private Transform _player;
    private Transform _thisTransform, _stageInstantiateTransformEnd;
    private GameObject _stageInstantiate;
    private int _randomNum, _howManyZombie;
    private bool _respawnOn;
    // Start is called before the first frame update
    void Start()
    {
        _howManyZombie = 0;
        _respawnOn = true;
        _thisTransform = GetComponent<Transform>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _stageInstantiate = Instantiate(stagePrefab[0], Vector3.zero, Quaternion.identity,_thisTransform);
        _stageInstantiateTransformEnd = _stageInstantiate.GetComponent<PrefData>().end;
        _stageInstantiate.GetComponent<PrefData>().speed = speed;
        _stageInstantiate.GetComponent<PrefData>().player = _player;
        RoadBulding();
        RoadBulding();
        EnemyHealth._zombieInt += Zombieint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RoadBulding()
    {
        _randomNum = Random.RandomRange(0, stagePrefab.Length);
        _stageInstantiate = Instantiate(stagePrefab[_randomNum], _stageInstantiateTransformEnd.position, Quaternion.identity, _thisTransform);
        _stageInstantiateTransformEnd = _stageInstantiate.GetComponent<PrefData>().end;
        PrefData prData = _stageInstantiate.GetComponent<PrefData>();
        prData.speed = speed;
        prData.minZombi = minZombi;
        prData.maxZombi = maxZombi;
        prData.player = _player;
        minZombi += upDateZombi;
        maxZombi += upDateZombi;
        if (_respawnOn)
        {
            prData.RespawnZombi();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        RoadBulding();
        other.transform.parent.gameObject.GetComponent<PrefData>().Destroy();
    }

    private void Zombieint(int zombi)
    {
        _howManyZombie += zombi;
        if (_howManyZombie > maxZombieOnMap)
        {
            _respawnOn = false;
        }
        else
        {
            _respawnOn = true;
        }
    }
}
