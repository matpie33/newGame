using UnityEngine;
using UnityEngine.UI;
public class PickableObjectsMarkerManager : MonoBehaviour
{
    public const int force = 3000;
    public GameObject objectsMarker;

    public bool HandleShowingPickableObjectMarker(Collider other)
    {
        if (other.attachedRigidbody != null && other.gameObject.CompareTag(TagsManager.PICKABLE))
        {
            objectsMarker.SetActive(true);
            Vector3 positionForMarker = other.transform.position;
            positionForMarker.y += other.bounds.size.y / 2 + objectsMarker.GetComponentInChildren<MeshRenderer>().bounds.size.y / 2;
            objectsMarker.transform.position = positionForMarker;
            return true;
        }
        return false;
    }

    public void HandleHidingPickableObjectMarker()
    {
        objectsMarker.SetActive(false);

    }












}
