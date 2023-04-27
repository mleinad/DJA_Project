using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEditor.VersionControl;
using UnityEngine;

public class HitDynamic : MonoBehaviour
{



    public Camera fpsCam;
    public float range = 100f;
    public GameObject Player;
    private bool switchGUI = false;

    public float timeBetweenShots = 0.5f; // Add this variable to control the fire rate
    private float nextTimeToFire = 0f;


    public string message = "Press E to switch weapon";
    public GUIStyle style;

    void Start()
    {

    }

    void Update()
    {
            
        CheckEnv();

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + timeBetweenShots;
            Shoot();
        }
    }
    

    GameObject CheckEnv()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 5f))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Weapon"))
            {
                switchGUI = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameObject hitObject = hit.collider.gameObject;
                    pickUp(hitObject);
                }
            }
            else
            {
                switchGUI= false;
            }
            
        }
        return null;
    }
    void Shoot()
    {

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(-hit.normal * 100f);
                


            }

            

        }


    }
    void OnGUI()
    {
        if (switchGUI)
        {
            GUI.Label(new Rect(10, 10, 100, 20), message, style);
        }
    }
    void pickUp(GameObject obj)
    {
        Debug.Log("weapon picked up");


        Transform childTransform = transform.GetChild(0);
        childTransform.SetParent(null);


        Rigidbody childRigidbody = childTransform.GetComponent<Rigidbody>();
        
        if (childRigidbody != null)
        {
            childRigidbody.isKinematic = false;
            childRigidbody.AddForce(transform.forward * 25f, ForceMode.Impulse);
        }

        if (obj != null)
        {
            obj.transform.SetParent(transform);
            Rigidbody newChildRigidbody = obj.GetComponent<Rigidbody>();
            newChildRigidbody.isKinematic = true;  
            newChildRigidbody.transform.localPosition = Vector3.zero;
            newChildRigidbody.transform.localRotation = Quaternion.Euler(Vector3.zero);
        }
    }

}