using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonMonster : MonoBehaviour
{
    public GameObject monsters;
    public float waktuMin, waktuMaks;
    public float posisiMin, posisiMaks;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Monsters());
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Monsters()
    {
        Instantiate(monsters, transform.position + Vector3.right * Random.Range(posisiMin, posisiMaks), Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(waktuMin, waktuMaks));
        StartCoroutine(Monsters());
    }
}
