using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started)
            return;
        Debug.Log("Click!");
    }

    public void OnTouch(InputAction.CallbackContext context)
    {
        if (!context.started)
            return;
        int tmp = int.Parse(text.text) + 1;
        text.text = tmp.ToString();
        Debug.Log("Touch!");
    }
}
