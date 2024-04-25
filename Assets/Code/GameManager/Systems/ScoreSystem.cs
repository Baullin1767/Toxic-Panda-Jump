using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;
using UnityEngine.SocialPlatforms.Impl;
using YG;

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
        ref var scoreC = ref score.First().GetComponent<ScoreComponent>();
        scoreC.score = 0;
    }

    public override void OnUpdate(float deltaTime)
    {
        ref var scoreC = ref score.First().GetComponent<ScoreComponent>();
        if(scoreC.score > YandexGame.savesData.score)
        {
            YandexGame.NewLeaderboardScores("jumpers", scoreC.score);
            YandexGame.savesData.score = scoreC.score;
            YandexGame.SaveProgress();
            Debug.Log("Update");
        }
        scoreC.scoreText.text = scoreC.score.ToString();
    }
}