using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    PlayerInput input; //InputSystem;
    IMoveable move;
    IDashable dash;
    IAttackable attack;

    void Awake()
    {
        TryGetComponent(out input);
        TryGetComponent(out move);
        TryGetComponent(out dash);
        TryGetComponent(out attack);
    }

    void OnEnable()
    {
        input.actions["Move"].performed += OnMove;
        input.actions["Move"].canceled += OnMoveStop;
        input.actions["Dash"].started += OnDash;
        input.actions["Attack"].started += OnAttack;
    }

    void OnDisable()
    {
        input.actions["Move"].performed -= OnMove;
        input.actions["Move"].canceled -= OnMoveStop;
        input.actions["Dash"].started -= OnDash;
        input.actions["Attack"].started -= OnAttack;
    }

    //移動キーを押したときの処理
    void OnMove(InputAction.CallbackContext context)
    {
        Vector3 value = context.ReadValue<Vector2>();
        move.SetDirection(value);
    }

    //移動キーを離したときの処理
    void OnMoveStop(InputAction.CallbackContext context)
    {
        move.SetDirection(Vector3.zero);
    }

    //ダッシュキーを押したときの処理
    void OnDash(InputAction.CallbackContext context)
    {
        dash.Dash(move.GetDirection());
    }

    //攻撃キーを押したときの処理
    void OnAttack(InputAction.CallbackContext context)
    {
        attack.Attack();
    }

}
