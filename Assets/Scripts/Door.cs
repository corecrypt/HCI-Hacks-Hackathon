using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool IsOpen;
    public float doorSpeed = 1;

    public List<DoorMovement> DoorParts;

    private void Start()
    {
        if (IsOpen)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    public void Toggle()
    {
        if (IsOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    public void Open()
    {
        IsOpen = true;
        StopAllCoroutines();

        foreach (var part in DoorParts)
        {
            switch (part.type)
            {
                case DoorType.Move:
                    StartCoroutine(MoveDoor(part.target, part.open, part.linearMotion));
                    break;
                case DoorType.Rotate:
                    StartCoroutine(RotateDoor(part.target, part.hinge, part.open.rotation));
                    break;
            }
        }
    }

    public void Close()
    {
        IsOpen = false;
        StopAllCoroutines();

        foreach (var part in DoorParts)
        {
            switch (part.type)
            {
                case DoorType.Move:
                    StartCoroutine(MoveDoor(part.target, part.close, part.linearMotion));
                    break;
                case DoorType.Rotate:
                    StartCoroutine(RotateDoor(part.target, part.hinge, part.close.rotation));
                    break;
            }
        }
    }

    private IEnumerator MoveDoor(Transform target, Transform end, bool linear)
    {
        float start = Time.time;
        Vector3 startPosition = target.position;
        while ((end.position - target.position).magnitude > 1e-4)
        {
            if (linear)
            {
                target.position = Vector3.Lerp(startPosition, end.position, (Time.time - start) * doorSpeed);
            }
            else
            {
                target.position = Vector3.Lerp(target.position, end.position, doorSpeed * Time.deltaTime);
            }
            yield return null;
        }
    }

    private IEnumerator RotateDoor(Transform target, Transform hinge, Quaternion desiredRotation)
    {
        while (Quaternion.Angle(target.rotation, desiredRotation) > 1e-4)
        {
            target.rotation = Quaternion.RotateTowards(target.rotation, desiredRotation, Time.deltaTime * doorSpeed);
            yield return null;
        }
    }

    [System.Serializable]
    public class DoorMovement
    {
        public DoorType type;
        public bool linearMotion;
        public Transform target;
        public Transform open;
        public Transform close;

        public Transform hinge;
    }

    public enum DoorType
    {
        Move,
        Rotate
    }
}
