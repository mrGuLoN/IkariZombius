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
    }

    private void FixedUpdate()
    {               
        _thisTransform.position -= _thisTransform.forward * speed * Time.deltaTime;
    }

    public void  RespawnZombi()
    {
        _intZombi = Random.Range(minZombi, maxZombi);
        for (int i = 0; i <= _intZombi; i++)
        {
            int Zombi = 1;
            int j = Random.Range(0, _respZombi.Length);
            int x = Random.Range(-4, +4);
            int y = Random.Range(-4, +4);
            GameObject enemy = PollerObject.Instance.GetObject(zombi);               

            enemy.GetComponent<NewEnemyController>().player = player;
            enemy.transform.position = _respZombi[j].position + new Vector3(x, 0.01f, y);
            StartCoroutine(CharacterOn(enemy));
            Debug.Log(Zombi);
            Zombi++;
        }
    }   

    IEnumerator CharacterOn(GameObject enemy)
    {
        yield return new WaitForSeconds(1f);
        enemy.GetComponent<CharacterController>().enabled = true;
    }

    public void Destroy()
    {
        Debug.Log("Enananan");
        Destroy(this.gameObject);
    }
   
}
