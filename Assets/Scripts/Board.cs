using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Board : MonoBehaviour
    {
        public GameObject piecePrefab;
        public int pieceX;
        public int pieceY;
        private Piece[,] _pieces;

        public void Start()
        {
            Debug.Log("Board");
            var dx = Screen.height * 1.0 / 20;
            var dy = Screen.height * 1.0 / 20;
            float bg_x = (float) (Screen.width - Screen.height) / 2;
            _pieces = new Piece[pieceX, pieceY];
            for (int i = 0; i < pieceX; i++)
            {
                for (int j = 0; j < pieceY; j++)
                {
                    var pi = Instantiate(piecePrefab, transform);
                    var piece = pi.GetComponent<Piece>();
                    piece.x = i;
                    piece.y = j;
                    pi.GetComponent<RectTransform>().sizeDelta = new Vector2((float) (dx), (float) (dx));
                    pi.GetComponent<RectTransform>().position =
                        new Vector3((float) ((float) (dx * (i)) + bg_x + dx / 2), (float) (dy * (j) + dx / 2), 0);
                    _pieces[i, j] = piece;
                }
            }
        }

        public void ChangeBelong(int x, int y)
        {
            _pieces[x, y].ChangeBelong();
        }

        void Update()
        {
        }
    }
}