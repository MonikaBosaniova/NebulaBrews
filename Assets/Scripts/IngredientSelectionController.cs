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
    public event BooleanChangeDelegate OnBooleanChangeSelection;

    public event BooleanChangeDelegate OnBooleanChangeCauldron;

    public bool isSelected = false;
    public bool isNearCauldron = false;

    public ParticleSystem PotionParticles;

    //private Sequence sequence;

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
                OnBooleanChangeSelection(value);
            }
        }
    }

    public bool IsNearCauldron
    {
        get { return isNearCauldron; }
        set
        {
            // Check if the value is different
            if (isNearCauldron != value)
            {
                // Set the new value
                isNearCauldron = value;

                // Trigger the event
                OnBooleanChangeCauldron(value);
            }
        }
    }

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to the event
        this.OnBooleanChangeSelection += HandleBooleanChangeSelection;
        this.OnBooleanChangeCauldron += HandleBooleanChangeCauldron;
        startPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        //sequence = DOTween.Sequence();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void MoveIngredientToCauldron()
    {
        transform.DOLocalMoveY(0.35f, 0.2f, false);
        transform.DOLocalMove(new Vector3(-0.3f, 0.35f, 0.5f), 1, false).OnComplete(() => { PotionParticles.Play(); });
        transform.DOLocalRotate(new Vector3(0, 0, -95f), 0.5f);

    }

    private void MoveIngredientFromCauldron()
    {
        if (transform.localPosition != startPosition)
        {
            //float y = transform.localPosition.y;


            transform.DOLocalRotate(new Vector3(0, 0, 0), 0.5f);
            transform.DOLocalMove(new Vector3(startPosition.x, 0.2f, startPosition.z), 1f, false).OnComplete(() =>
            {
                this.IsSelected = false;
            });
            ;
            //this.transform.parent.parent.GetComponent<IngredientSelectionManager>().SelectedObject = null;

        }

    }


    private void HandleBooleanChangeSelection(bool newValue)
    {
        if (newValue)
        {
            transform.DOLocalMoveY(startPosition.y + .4f, 0.5f, false);
            transform.parent.parent.GetComponent<IngredientSelectionManager>().SelectedObject = this;
            transform.parent.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            transform.DOLocalMoveY(startPosition.y, 0.5f, false).OnComplete(() =>
            {
                transform.parent.parent.GetComponent<IngredientSelectionManager>().SelectedObject = null;
            });
            transform.parent.GetChild(1).gameObject.SetActive(false);
        }

    }

    private void HandleBooleanChangeCauldron(bool newValue)
    {
        if (newValue)
        {
            MoveIngredientToCauldron();
        }
        else
        {
            MoveIngredientFromCauldron();
        }

    }

    private void OnDestroy()
    {
        // Unsubscribe from the event to avoid memory leaks
        this.OnBooleanChangeSelection -= HandleBooleanChangeSelection;
        this.OnBooleanChangeCauldron -= HandleBooleanChangeCauldron;
    }



}
