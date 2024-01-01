using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shots : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator anim ;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        anim.SetBool("straight",true);
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("straight",false);
    }

  
}
