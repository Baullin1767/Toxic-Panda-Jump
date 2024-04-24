using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;
using UnityEngine.SocialPlatforms.Impl;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(ScoreSystem))]
public sealed class ScoreSystem : UpdateSystem
{
    Filter score;
    public override void OnAwake()
    {
        score = World.Filter.With<ScoreComponent>().Build();
    }

    public override void OnUpdate(float deltaTime)
    {
        ref var scoreC = ref score.First().GetComponent<ScoreComponent>();
        PlayerPrefs.SetInt("Score", scoreC.score);
        scoreC.scoreText.text = scoreC.score.ToString();
    }
}