using Scellecs.Morpeh;
using UnityEngine.UI;
using Unity.IL2CPP.CompilerServices;

[System.Serializable]
[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
public struct MessageComponent : IComponent {
    public Text messageText;
    public string[] messages;
}