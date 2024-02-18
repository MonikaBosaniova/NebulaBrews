using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class IntroCameraMovement : MonoBehaviour
{
    public GameObject tmp_text;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalPath(new Vector3[] { new Vector3(0.055f, 1.52f, -3.239f), new Vector3(0.07064164f, 2.019526f, -0.4473011f) }, 3f, PathType.Linear).OnComplete(() => tmp_text.SetActive(true));
        transform.DOLocalRotate(new Vector3(25.647f, 0.273f, -0.005f), 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
