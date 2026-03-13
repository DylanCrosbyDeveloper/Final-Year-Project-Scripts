using UnityEngine;
using Unity.Netcode.Components;
using Unity.VisualScripting;

public class ClientNetworkTransform : NetworkTransform
{
    protected override bool OnIsServerAuthoritative()
    {
        return false;
    }
}
