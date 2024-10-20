using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Note : MonoBehaviour
{
    [SerializeField] private SystemSetting systemSetting;
    [SerializeField] GraphicRaycaster m_Raycaster;
    [SerializeField] private PointerEventData m_PointerEventData;
    [SerializeField] EventSystem m_EventSystem;
    [SerializeField] private GameObject noteObj;
    [SerializeField] private SpriteRenderer noteSprite;
    void Update()
    {

        //Set up the new Pointer Event
        m_PointerEventData = new PointerEventData(m_EventSystem);
        //Set the Pointer Event Position to that of the mouse position
        m_PointerEventData.position = systemSetting.GetPointerPos();
        transform.position = Camera.main.ScreenToWorldPoint(m_PointerEventData.position);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>();

        //Raycast using the Graphics Raycaster and mouse click position
        m_Raycaster.Raycast(m_PointerEventData, results);

        //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        if (results.Count > 0 && results[0].gameObject.layer == LayerMask.NameToLayer("Note"))
        {
            noteSprite.sprite = results[0].gameObject.GetComponent<NoteInfo>().infoSprite;
            noteObj.SetActive(true);
        }
        else
        {
            noteObj.SetActive(false);
        }

    }
}
