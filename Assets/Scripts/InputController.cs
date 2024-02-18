using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class InputController : MonoBehaviour
{
    //public TMP_Text text;
    public Camera Camera;

    IngredientSelectionController lastSelectedIngredient;

    // Start is called before the first frame update
    void Start()
    {
        lastSelectedIngredient = null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started)
            return;
        //int tmp = int.Parse(text.text) + 1;
        //text.text = tmp.ToString();
        Debug.Log("Click!");

        RaycastHit hit;
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {

            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Ingredients"))
            {
                IngredientSelectionController beforeSelectedIngredient = lastSelectedIngredient;
                if (lastSelectedIngredient?.IsSelected ?? false)
                {
                    DeselectItem();
                    //return;
                }
                // Do something with the object that was hit by the raycast.
                lastSelectedIngredient = hit.transform.GetComponent<IngredientSelectionController>();
                //if (lastSelectedIngredient == beforeSelectedIngredient)
                //{
                //    DeselectItem();
                //}
                if (lastSelectedIngredient != null)
                {
                    lastSelectedIngredient.IsSelected = true;
                }
                //hit.transform.parent.parent.GetComponent<IngredientSelectionManager>().SelectedObject = lastSelectedIngredient;

            }
            else if (hit.transform.parent.gameObject.tag == "Cauldron")
            {
                if (lastSelectedIngredient?.IsSelected ?? false)
                {
                    lastSelectedIngredient.IsNearCauldron = true;
                }
            }
            else
            {
                if (lastSelectedIngredient != null)
                {
                    DeselectItem();
                }
                //hit.transform.parent.parent.GetComponent<IngredientSelectionManager>().SelectedObject = null;
            }

        }
        else
        {
            if (lastSelectedIngredient != null)
            {
                DeselectItem();
            }
            //hit.transform.parent.parent.GetComponent<IngredientSelectionManager>().SelectedObject = null;
        }
    }

    public void OnTouch(InputAction.CallbackContext context)
    {
        if (!context.started)
            return;
        //int tmp = int.Parse(text.text) + 1;
        //text.text = tmp.ToString();
        Debug.Log("Touch!");
    }

    private void DeselectItem()
    {
        if (lastSelectedIngredient.IsNearCauldron)
        {
            lastSelectedIngredient.IsNearCauldron = false;

        }
        else
        {
            //lastSelectedIngredient.transform.parent.parent.GetComponent<IngredientSelectionManager>().SelectedObject = null;
            lastSelectedIngredient.IsSelected = false;
        }
        lastSelectedIngredient = null;
    }
}


