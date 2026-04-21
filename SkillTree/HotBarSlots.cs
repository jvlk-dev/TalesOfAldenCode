using UnityEngine;
using UnityEngine.UI;

/**
* HotBarSlots class for handling the update of hotbar
*/
public class HotBarSlots : MonoBehaviour
{
    public GameObject sourceObject;
    public GameObject destinationObject;

    /**
    * OnChange method is used to copy or update the MonoBehaviour component of a source object to a destination object's MonoBehaviour component.
    * Method is called on change of the gameObject
    * @return void
    */
    public void OnChange()
    {
        // Get all MonoBehaviours from sourceObject
        MonoBehaviour[] sourceBehaviours = sourceObject.GetComponents<MonoBehaviour>();

        // Copy/Update MonoBehaviours to destinationObject
        foreach (MonoBehaviour sourceBehaviour in sourceBehaviours)
        {
            // Skip the script attached to this game object
            if (sourceBehaviour == this)
            {
                continue;
            }

            // Check if the component already exists on the destination object
            Component existingComponent = destinationObject.GetComponent(sourceBehaviour.GetType());

            // If the component exists, update its values
            if (existingComponent != null)
            {
                // Serialize component data to JSON
                string json = JsonUtility.ToJson(sourceBehaviour);
                // Deserialize JSON to existing component
                JsonUtility.FromJsonOverwrite(json, existingComponent);
            }
            // If the component doesn't exist, add a new instance
            else
            {
                Component newComponent = destinationObject.AddComponent(sourceBehaviour.GetType());
                // Serialize component data to JSON
                string json = JsonUtility.ToJson(sourceBehaviour);
                // Deserialize JSON to new component
                JsonUtility.FromJsonOverwrite(json, newComponent);
            }
        }

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
                existingImage.type = Image.Type.Simple;
                existingImage.preserveAspect = true;
            }
            // If the Image component doesn't exist, add a new instance and set its sprite
            else
            {
                Image newImage = destinationImage.gameObject.AddComponent<Image>();
                newImage.sprite = sourceImage.sprite;
                newImage.type = Image.Type.Simple;
                newImage.preserveAspect = true;
            }
        }
    }
}