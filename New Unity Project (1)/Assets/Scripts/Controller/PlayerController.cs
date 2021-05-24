using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
*/

/// <summary>
///
/// </summary>

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;

    public Interactable focus;

    Camera cam;
    PlayerMotor motor;

    private void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();

    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);
                // move our player to what we hit
                Debug.Log("We hit" + hit.collider.name + "" + hit.point);
                // stop focusing any objects
                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // check if we hit an in interactable
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null)
                {
                    SetFocus(interactable);
                }
                // if we did set it as out focus
            }
        }

        void SetFocus(Interactable newFocus)
        {
            if(newFocus != focus)
            {
                if (focus != null)
                    focus.OnDefocused();
                focus = newFocus;
                newFocus.OnFocused(transform);
                
            }
            motor.FollowTarget(newFocus);


        }

        void RemoveFocus()
        {
            if(focus!=null)
                focus.OnDefocused();

            focus = null;       
            motor.StopFollowingTarget();
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (focus.interactionTransform.position - this.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
