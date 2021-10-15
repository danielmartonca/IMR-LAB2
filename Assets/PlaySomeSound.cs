using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySomeSound : MonoBehaviour
{
    public GameObject cocktus;

    // Start is called before the first frame update
    void Start()
    {
        cocktus.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        cocktus.SetActive(true);
    }
}
