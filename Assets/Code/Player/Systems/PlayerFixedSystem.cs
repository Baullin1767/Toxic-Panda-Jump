using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;
using Zenject.Asteroids;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Zenject;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(PlayerFixedSystem))]
public sealed class PlayerFixedSystem : FixedUpdateSystem {
    Filter entities;
    public override void OnAwake() {
        entities = World.Filter.With<PlayerComponent>().Build();
    }

    public override void OnUpdate(float deltaTime) {
        ref var player = ref entities.First().GetComponent<PlayerComponent>();
        var input = entities.First().GetComponent<InputComponent>();
        var rb = entities.First().GetComponent<RigidbodyComponent>();

        if (player.canMove)
        {
            player.onGround = Physics2D.OverlapCircle(player.onGroundCentre.position, player.rangeOnGround, player.layerMaskOnGround);

            if (player.onGround)
            {
                player.sprite.sprite = player.idleSprite;
                if (player.curJumpDelay > 0)
                {
                    player.curJumpDelay -= Time.fixedDeltaTime;
                }
                else
                {
                    rb.rb2D.velocity = Vector2.up * player.forceJump + rb.rb2D.velocity.x * Vector2.right;
                    player.curJumpDelay = player.jumpDelay;
                }
            }
            else
            {
                player.sprite.sprite = player.jumpSprite;
            }

            if (input.Horizontal != 0)
            {
                rb.rb2D.velocity = Vector2.right * input.Horizontal * player.speed * Time.deltaTime 
                        + Vector2.up * rb.rb2D.velocity.y;
            }
            else
            {
                rb.rb2D.velocity = Vector2.up * rb.rb2D.velocity.y;
            } 
        }
     }
}