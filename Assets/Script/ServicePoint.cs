using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServicePoint : MonoBehaviour
{
    public bool IsOccupied { get; private set; } // Flag to check if the service point is occupied

    void Start()
    {
        IsOccupied = false;
    }

    public bool TryOccupy()
    {
        if (!IsOccupied)
        {
            IsOccupied = true;
            return true;
        }
        return false;
    }

    public void Release()
    {
        IsOccupied = false;
    }
}
