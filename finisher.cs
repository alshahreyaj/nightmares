using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finisher : MonoBehaviour
{

    bool done = false;

    [SerializeField]
    GameObject block, end_pan;
    // Start is called before the first frame update
    void Start()
    {
        done = false;
        block.GetComponent<Rigidbody>().useGravity = false;
    }



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if (done)
            {
                block.GetComponent<Rigidbody>().useGravity = true;
                StartCoroutine(end());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") done = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")  done = false;
    }

    IEnumerator end()
    {
        yield return new WaitForSeconds(1f);
        end_pan.SetActive(true);
        Cursor.visible = true;
    }
}
