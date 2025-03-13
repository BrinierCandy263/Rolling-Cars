using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public struct SelectedCarMessage : NetworkMessage
{
    int selectedCarIndex;
}
