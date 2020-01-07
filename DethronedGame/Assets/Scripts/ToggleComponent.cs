using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleComponent : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] components;

    public void Toggle()
    {
        foreach (MonoBehaviour component in components)
        {
            component.enabled = !component.enabled;
        }
    }
}
