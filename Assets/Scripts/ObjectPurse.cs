using UnityEngine;

public class ObjectPurse : MonoBehaviour
{
    [SerializeField] private GameObject pursuedObject;
    [SerializeField] private float softness;
    [SerializeField] private bool allowChangeObject = true;
    
    private void FixedUpdate()
    {
        PurseObject(pursuedObject);
    }

    private void PurseObject(GameObject pursed)
    {
        var transform1 = transform;
        var position = transform1.position;
        var position1 = pursed.transform.position;
        var xDifference = (position1.x - position.x) / softness;
        var yDifference = (position1.y - position.y) / softness;

        position = new Vector3(
            position.x + xDifference, 
            position.y + yDifference, 
            position.z);
        transform1.position = position;
    }

    public void SetPurseObject(GameObject purse)
    {
        if (allowChangeObject)
            pursuedObject = purse;
    }
}