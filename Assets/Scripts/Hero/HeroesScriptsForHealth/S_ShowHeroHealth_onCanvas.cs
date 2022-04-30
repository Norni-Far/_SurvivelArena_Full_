using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ShowHeroHealth_onCanvas : MonoBehaviour
{
    private Camera nowCamera;
    private GameObject player;
    [SerializeField] private Vector2 transformHeroFromCamera;

    public void SetPlayer(GameObject _player)
    {
        player = _player;
        //nowCamera = Camera.main.
    }

    private void LateUpdate()
    {
        if (player)
        {
            transformHeroFromCamera = Camera.main.WorldToScreenPoint(player.transform.position);
            gameObject.transform.localPosition = transformHeroFromCamera;
        }

    }


}
