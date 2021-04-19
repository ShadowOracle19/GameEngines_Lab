using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class ItemPickupComponent : MonoBehaviour
    {
        [SerializeField] private ItemScriptable pickupItem;

        [Tooltip("Manual override for drop amount if left at -1 it will use the amount from the scriptable object.")]
        [SerializeField] private int Amount = -1;

        [SerializeField] private MeshRenderer propMeshRenderer;
        [SerializeField] private MeshFilter propMeshFilter;

        private ItemScriptable ItemInstance;

        // Start is called before the first frame update
        void Start()
        {
            Instatiate();
        }

        private void Instatiate()
        {
            ItemInstance = Instantiate(pickupItem);
            if(Amount > 0)
            {
                ItemInstance.SetAmount(Amount);
            }

            ApplyMesh();
        }

        private void ApplyMesh()
        {
            if(propMeshFilter)
            {
                propMeshFilter.mesh = pickupItem.ItemPrefab.GetComponentInChildren<MeshFilter>().sharedMesh;
            }
            if(propMeshRenderer)
            {
                propMeshRenderer.materials = pickupItem.ItemPrefab.GetComponentInChildren<MeshRenderer>().sharedMaterials;
            }

        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            Debug.Log("Picked up");

            ItemInstance.UseItem(other.GetComponent<PlayerController>());
            Destroy(gameObject);

        }

        private void OnValidate()
        {
            ApplyMesh();   
        }
    }

}
