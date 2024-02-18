using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Alohomora : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalRotate(new Vector3(0, -30f, 0), 1.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
