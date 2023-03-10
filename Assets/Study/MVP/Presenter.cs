using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace MVP
{
    public class Presenter : MonoBehaviour
    {
        [Header("View")]
        [SerializeField]
        private View _view;

        [Header("Scoreを発行するModel")]
        [SerializeField]
        private GameObject _scoreObject;


        void Update()
        {
            //今回はPresenter内で生成と破棄を行っているが、実際はあまりよくない
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //オブジェクトを生成し、そのコンポーネントを取得
                var scoreObject = Instantiate(_scoreObject);
                var score = scoreObject.GetComponent<ModelObject>();

                //新しい監視対象を購読し、値が変化したときの処理を登録する
                score.Score.Subscribe(_view.SetScore);

                //監視対象を3秒後に削除
                Destroy(scoreObject, 3.0f);
            }
        }
    }
}
