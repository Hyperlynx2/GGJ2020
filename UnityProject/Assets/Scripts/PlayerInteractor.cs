using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public Trap SelectedTrap { get {return m_selectedTrap;}}
    [SerializeField]
    private Trap m_selectedTrap;

    private void OnTriggerStay(Collider other) {
        if(m_selectedTrap == null) {
            GameObject obj = other.gameObject;

            if(LayerMask.LayerToName(obj.layer) == "Payloads") {
                Debug.Log("Entered: " + other.gameObject);
                m_selectedTrap = obj.transform.parent.GetComponent<Trap>();
                m_selectedTrap.HighlightTrap(true);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if(m_selectedTrap != null) {
            m_selectedTrap.HighlightTrap(false);
        }
        
        m_selectedTrap = null;
    }
}
