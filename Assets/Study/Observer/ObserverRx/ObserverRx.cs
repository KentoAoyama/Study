using UnityEngine;
using UniRx;

public class ObserverRx : MonoBehaviour
{
    [SerializeField]
    private GameObject _subjectPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //オブジェクトを生成し、そのSubjectコンポーネントを取得
            var subjectObject = Instantiate(_subjectPrefab);
            var subject = subjectObject.GetComponent<SubjectRx>();

            //新しい監視対象を購読し、値が変化したときの処理を登録する
            subject.SubjectUniRx
                .Subscribe(i => Finished(i))
                .AddTo(gameObject);

            //Operator使用例
            subject.SubjectUniRx
                .Where(n => n > 5)
                .Subscribe(Finished)
                .AddTo(gameObject);

            //監視対象を3秒後に削除
            Destroy(subjectObject, 3.0f);
        }
    }

    private void Finished(int value)
    {
        Debug.Log($"Subjectからスコアが発行されました。Scoreは｛{value}｝です");
    }
}
