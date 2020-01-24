using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillThisThing : MonoBehaviour
{
    private float lifetime = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IEKillThisThing(lifetime));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator IEKillThisThing(float killtime)
    {
        yield return new WaitForSeconds(killtime);
        Destroy(this.gameObject);
    }
}
