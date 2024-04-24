using Zenject;
using UnityEngine;
using Unity.VisualScripting.FullSerializer;

[CreateAssetMenu(fileName = "SOInstaller", menuName = "Create SO Installer")]
public class SOInstaller : ScriptableObjectInstaller
{
    [SerializeField] PlatformConfig platformConfig;
    public override void InstallBindings()
    {
        Container.BindInstance(platformConfig).AsSingle();
    }
}