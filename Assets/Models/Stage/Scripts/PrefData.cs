using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefData : MonoBehaviour
{
    public Transform end, player;
    public float speed, minZombi, maxZombi;
    [SerializeField] private Transform[] _respZombi;
    [SerializeField] private PollerObject.ObjectInfo.ObjectType zombi;

    private Transform _thisTransform;
    private Rigidbody _rb;
    private float _intZombi;    


    private void Start()
    {
        _thisTransform = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = new Vector3(0, 0, -1 * speed);
        RespawnZombi();       
    }

    private void FixedUpdate()
    {       
        _rb.velocity = new Vector3(0, 0, -1 * speed);
    }

    public void  RespawnZombi()
    {
        StartCoroutine(REspawn());
    }   

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    IEnumerator REspawn()
    {
        yield return new WaitForSeconds(1f);
        _intZombi = Random.Range(minZombi, maxZombi);
        for (int i = 0; i <= _intZombi; i++)
        {
            int j = Random.Range(0, _respZombi.Length);
            int x = Random.Range(-2, +2);
            int y = Random.Range(-2, +2);         

            GameObject enemy = PollerObject.Instance.GetObject(zombi);
            enemy.transform.position = _respZombi[j].position + new Vector3(x, 0, y);//new Vector3(_respZombi[j].position.x + x, 0, _respZombi[j].position.z + y);

            enemy.GetComponent<ZombiController>().player = player;
        }

    }
}
