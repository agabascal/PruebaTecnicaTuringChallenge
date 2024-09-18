using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation;

public class XRDeviceSimulatorToggle : MonoBehaviour
{
    [SerializeField] private XRDeviceSimulator simulator;

    [ContextMenu("Toggle")]
    public void EnableDisableXRSimulator()
    {
        simulator.gameObject.SetActive(!simulator.gameObject.activeSelf);
    }
}
