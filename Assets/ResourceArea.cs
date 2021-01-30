using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceArea : MonoBehaviour
{


    private int resourcesInside = 10;

    public GameObject ResourcePrefab;
    void Start()
    {
        for (int i = 0; i < resourcesInside; i++)
        {
            var resource = Instantiate(ResourcePrefab, new Vector3(Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2), Random.Range(transform.position.y - transform.localScale.y / 2, transform.position.y + transform.localScale.y / 2), Random.Range(transform.position.z - transform.localScale.z / 2, transform.position.z + transform.localScale.z / 2)), Quaternion.identity);
            resource.GetComponent<Resource>().resourceArea = transform.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnResourceRandomly()
    {
        Instantiate(ResourcePrefab, new Vector3(Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2), Random.Range(transform.position.y - transform.localScale.y / 2, transform.position.y + transform.localScale.y / 2), Random.Range(transform.position.z - transform.localScale.z / 2, transform.position.z + transform.localScale.z / 2)), Quaternion.identity);
    }

    public void DecreaseResource()
    {
        resourcesInside--;

        if (resourcesInside < 5)
        {
            Instantiate(ResourcePrefab, new Vector3(Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2), Random.Range(transform.position.y - transform.localScale.y / 2, transform.position.y + transform.localScale.y / 2), Random.Range(transform.position.z - transform.localScale.z / 2, transform.position.z + transform.localScale.z / 2)), Quaternion.identity);
            Instantiate(ResourcePrefab, new Vector3(Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2), Random.Range(transform.position.y - transform.localScale.y / 2, transform.position.y + transform.localScale.y / 2), Random.Range(transform.position.z - transform.localScale.z / 2, transform.position.z + transform.localScale.z / 2)), Quaternion.identity);
            Instantiate(ResourcePrefab, new Vector3(Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2), Random.Range(transform.position.y - transform.localScale.y / 2, transform.position.y + transform.localScale.y / 2), Random.Range(transform.position.z - transform.localScale.z / 2, transform.position.z + transform.localScale.z / 2)), Quaternion.identity);
            Instantiate(ResourcePrefab, new Vector3(Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2), Random.Range(transform.position.y - transform.localScale.y / 2, transform.position.y + transform.localScale.y / 2), Random.Range(transform.position.z - transform.localScale.z / 2, transform.position.z + transform.localScale.z / 2)), Quaternion.identity);
            Instantiate(ResourcePrefab, new Vector3(Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2), Random.Range(transform.position.y - transform.localScale.y / 2, transform.position.y + transform.localScale.y / 2), Random.Range(transform.position.z - transform.localScale.z / 2, transform.position.z + transform.localScale.z / 2)), Quaternion.identity);

        }
    }


    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("resource") && !other.gameObject.GetComponent<Resource>().collected)
    //     {
    //         resourcesInside++;
    //     }
    // }

    // void OnTriggerStay(Collider other)
    // {
    //     if (other.CompareTag("resource") && !other.gameObject.GetComponent<Resource>().collected)
    //     {

    //     }
    // }
    // void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("resource") && !other.gameObject.GetComponent<Resource>().collected)
    //     {
    //         resourcesInside--;
    //     }

    //     if (resourcesInside < 5)
    //     {
    //         Instantiate(ResourcePrefab, new Vector3(Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2), Random.Range(transform.position.y - transform.localScale.y / 2, transform.position.y + transform.localScale.y / 2), Random.Range(transform.position.z - transform.localScale.z / 2, transform.position.z + transform.localScale.z / 2)), Quaternion.identity);
    //         Instantiate(ResourcePrefab, new Vector3(Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2), Random.Range(transform.position.y - transform.localScale.y / 2, transform.position.y + transform.localScale.y / 2), Random.Range(transform.position.z - transform.localScale.z / 2, transform.position.z + transform.localScale.z / 2)), Quaternion.identity);
    //         Instantiate(ResourcePrefab, new Vector3(Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2), Random.Range(transform.position.y - transform.localScale.y / 2, transform.position.y + transform.localScale.y / 2), Random.Range(transform.position.z - transform.localScale.z / 2, transform.position.z + transform.localScale.z / 2)), Quaternion.identity);
    //         Instantiate(ResourcePrefab, new Vector3(Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2), Random.Range(transform.position.y - transform.localScale.y / 2, transform.position.y + transform.localScale.y / 2), Random.Range(transform.position.z - transform.localScale.z / 2, transform.position.z + transform.localScale.z / 2)), Quaternion.identity);
    //         Instantiate(ResourcePrefab, new Vector3(Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2), Random.Range(transform.position.y - transform.localScale.y / 2, transform.position.y + transform.localScale.y / 2), Random.Range(transform.position.z - transform.localScale.z / 2, transform.position.z + transform.localScale.z / 2)), Quaternion.identity);

    //     }
    // }

}
