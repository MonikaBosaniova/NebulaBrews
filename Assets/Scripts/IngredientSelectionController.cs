using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IngredientSelectionController : MonoBehaviour
{
    // Define a delegate for the event
    public delegate void BooleanChangeDelegate(bool newValue);

    // Define the event using the delegate
    public event BooleanChangeDelegate OnBooleanChange;

    public bool isSelected = false;

    public bool IsSelected
    {
        get { return isSelected; }
        set
        {
            // Check if the value is different
            if (isSelected != value)
            {
                // Set the new value
                isSelected = value;

                // Trigger the event
                OnBooleanChange(value);
            }
        }
    }

    private float startYPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to the event
        this.OnBooleanChange += HandleBooleanChange;
        startYPosition = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void HandleBooleanChange(bool newValue)
    {
        if (newValue)
        {
            transform.DOLocalMoveY(startYPosition + .1f, 0.5f, false).WaitForCompletion();
            transform.parent.parent.GetComponent<IngredientSelectionManager>().SelectedObject = this;
            transform.parent.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            transform.DOLocalMoveY(startYPosition, 0.5f, false).WaitForCompletion();
            transform.parent.GetChild(1).gameObject.SetActive(false);
        }

    }

    private void OnDestroy()
    {
        // Unsubscribe from the event to avoid memory leaks
        this.OnBooleanChange -= HandleBooleanChange;
    }


}
