シーン遷移アニメーションを簡単に追加するためのパッケージです。

[使い方]
1. 遷移前のシーンに Inのプレハブ、遷移後のシーンに Outのプレハブを置く。座標は変更しないこと。
2. Inオブジェクトの SceneTransition.StartSceneTransition(string sceneName)を呼び出すことでシーン遷移を開始。引数には遷移先のシーン名を指定する。
