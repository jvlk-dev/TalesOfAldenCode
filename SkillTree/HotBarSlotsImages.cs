using UnityEngine;
using UnityEngine.UI;

/**
* HotBarSlotsImages class for handling updating the hotbar images
*/
public class HotBarSlotsImages : MonoBehaviour
{
    public GameObject sourceObject;
    public GameObject destinationObject;

    /**
    * OnChange method is used to copy or update the Image component of a source object to a destination object's Image component.
    * Method is called on change of the gameObject
    * @return void
    */
    public void OnChange()
    {
        Transform childTransform = sourceObject.transform.GetChild(0);
        Image sourceImage = childTransform.GetComponent<Image>();

        Image destinationImage = destinationObject.GetComponent<Image>();

        // Copy/Update Image component to destinationImage
        if (sourceImage != null)
        {
            // Check if the Image component already exists on the destinationImage
            Image existingImage = destinationImage.GetComponent<Image>();

            // If the Image component exists, update its sprite
            if (existingImage != null)
            {
                existingImage.sprite = sourceImage.sprite;
            }
            // If the Image component doesn't exist, add a new instance and set its sprite
            else
            {
                destinationImage.gameObject.AddComponent<Image>().sprite = sourceImage.sprite;
            }
        }
    }
}