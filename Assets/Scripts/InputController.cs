using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class InputController : MonoBehaviour
{
    public TMP_Text text;
    public Camera Camera;
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
        int tmp = int.Parse(text.text) + 1;
        text.text = tmp.ToString();
        Debug.Log("Click!");

        RaycastHit hit;
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.layer == LayerMask.NameToLayer("Ingredients"))
        {
            hit.transform.parent.GetComponent<IngredientSelectionManager>().SelectedObject = hit.transform.GetComponent<IngredientSelectionController>();
            // Do something with the object that was hit by the raycast.
        }
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


