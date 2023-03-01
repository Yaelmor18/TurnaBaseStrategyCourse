using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    [SerializeField] private Unit selectedUnit;
    [SerializeField] private LayerMask unitsLayerMask;
    private void Update()
    {
        HandleUnitSelection();
        if (Input.GetMouseButtonDown(0))
        {
            selectedUnit.Move(MouseWorld.GetPosition());
        }
    }

    private void HandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, unitsLayerMask))
        {
            selectedUnit.Move(raycastHit.point);
        }
    }
}
