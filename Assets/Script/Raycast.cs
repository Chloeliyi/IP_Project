using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CollectionSystem
{
    public class Raycast : MonoBehaviour
    {
        [SerializeField] private int rayLength = 5;
        [SerializeField] private LayerMask layerMaskInteract;
        [SerializeField] private string excluseLayerName = null;

        private ItemController raycastedObject;
        [SerializeField] private KeyCode Collection = KeyCode.Mouse0;

        [SerializeField] private Image crosshair = null;
        private bool isCrosshairActive;
        private bool doOnce;

        private string interactableTag = "InteractiveObject";
        private string CarTag = "Car";
        private string NPC = "NPC";

        [SerializeField] private Player playerScript;
        [SerializeField] private BossDialogueManager bossDialogueManager;
        private void Update()
        {
            RaycastHit hitInfo;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int mask = 1 << LayerMask.NameToLayer(excluseLayerName) | layerMaskInteract.value;

            if (Physics.Raycast(transform.position, fwd, out hitInfo, rayLength, mask))
            {
                if (hitInfo.collider.CompareTag(interactableTag)  || hitInfo.collider.CompareTag(CarTag))
                {
                    if (!doOnce)
                    {
                        raycastedObject = hitInfo.collider.gameObject.GetComponent<ItemController>();
                        CrosshairChange(true);
                    }

                    isCrosshairActive = true;
                    doOnce = true;

                    if (Input.GetKeyDown(Collection))
                    {
                        raycastedObject.ObjectInteraction();
                    }
                }
                else if (hitInfo.collider.CompareTag(NPC))
                {
                    isCrosshairActive = true;
                }
                else if(hitInfo.collider.CompareTag("Task1Item"))
                {
                    if (!doOnce)
                    {
                        raycastedObject = hitInfo.collider.gameObject.GetComponent<ItemController>();
                        CrosshairChange(true);
                    }
                    isCrosshairActive = true;
                    doOnce = true;

                    if (Input.GetKeyDown(Collection))
                    {
                        raycastedObject.ObjectInteraction();
                        playerScript.task1CollectibleCount++;
                        Debug.Log(playerScript.task1CollectibleCount);
                        if (playerScript.task1CollectibleCount == 5)
                        {
                            bossDialogueManager.task1Ongoing = false;
                            bossDialogueManager.task1Complete = true;
                        }
                    }
                }
                else if(hitInfo.collider.CompareTag("Task2Item") && bossDialogueManager.task1Complete == true)
                {
                    if (!doOnce)
                    {
                        raycastedObject = hitInfo.collider.gameObject.GetComponent<ItemController>();
                        CrosshairChange(true);
                    }
                    isCrosshairActive = true;
                    doOnce = true;

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        raycastedObject.ObjectInteraction();
                        bossDialogueManager.task2Ongoing = false;
                        bossDialogueManager.task2Complete = true;                       
                    }
                }
            }
            else
            {
                if (isCrosshairActive)
                {
                    CrosshairChange(false);
                    doOnce = false;
                }
            }
        }

        void CrosshairChange(bool on)
        {
            if (on && !doOnce)
            {
                crosshair.color = Color.red;
            }
            else
            {
                crosshair.color = Color.yellow;
                isCrosshairActive = false;
            }
        }
    }
}
