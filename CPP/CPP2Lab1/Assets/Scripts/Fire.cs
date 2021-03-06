using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    Transform rayOrigin;

    [SerializeField]
    Transform cameraTransform;

    [SerializeField]
    Rigidbody projectilePrefab;

    [SerializeField]
    float projectileForce;

    public LayerMask LayersToCheck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin.transform.position, transform.forward, out hitInfo, 10.0f, LayersToCheck))
        {
            Debug.Log("Hit:" + hitInfo.transform.gameObject.name);
        }

        Vector3 endPos = transform.forward * 10.0f;

        Debug.DrawRay(rayOrigin.transform.position, endPos, Color.red);
    }



    public void FireProjectile()
    {
        if (rayOrigin && projectilePrefab)
        {
            Rigidbody temp = Instantiate(projectilePrefab, rayOrigin.position, rayOrigin.rotation);
            temp.AddForce(cameraTransform.transform.forward * projectileForce, ForceMode.Impulse);

            Destroy(temp.gameObject, 2.0f);
        }
    }
}
