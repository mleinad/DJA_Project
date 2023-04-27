using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Aiming : MonoBehaviour
{

    public GameObject Gun;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Gun.GetComponent<Animator>().Play("Aim1");
            Debug.Log("aiming");

        }

        if (Input.GetMouseButtonUp(1))
        {
            Gun.GetComponent<Animator>().Play("Aim2");
        }
    }
}