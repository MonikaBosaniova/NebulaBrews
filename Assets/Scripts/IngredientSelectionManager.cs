using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSelectionManager : MonoBehaviour
{
    // Define a delegate for the event
    //public delegate void TransformChangeDelegate(IngredientSelectionController newObject);

    // Define the event using the delegate
    //public event TransformChangeDelegate OnSelectionChange;

    public IngredientSelectionController SelectedObject;

    //public IngredientSelectionController SelectedObject
    //{
    //    get { return selectedObject; }
    //    set
    //    {
    //        // Check if the value is different
    //        if (selectedObject != value)
    //        {
    //            if (selectedObject != null) selectedObject.IsSelected = false;
    //            // Set the new value
    //            selectedObject = value;

    //            // Trigger the event
    //            OnSelectionChange(value);
    //        }
    //    }
    //}


    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to the event
        //this.OnSelectionChange += HandleSelectionChange;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void HandleSelectionChange(IngredientSelectionController newValue)
    {
        if (newValue != null)
        {
            newValue.IsSelected = true;
        }
        //selectedObject.isSelected = false;


    }

    private void OnDestroy()
    {
        // Unsubscribe from the event to avoid memory leaks
        //this.OnSelectionChange -= HandleSelectionChange;
    }
}
