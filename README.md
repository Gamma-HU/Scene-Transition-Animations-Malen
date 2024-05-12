シーン遷移アニメーションを簡単に追加するためのパッケージです。<br>
使用の際はこれとは別に DOTween (HOTween v2) パッケージが必要です。<br>
また、Full HD (1920 x 1080) の画面比率を想定しているのでそれ以外の比率では正常に機能しない場合があります。

https://github.com/Gamma-HU/Scene-Transition-Animations-Malen/assets/87284890/e5a8a011-e65f-4668-b858-632d6ba72492

<h3>[使い方]</h3>
<ol>
  <li>
    遷移前のシーンに Inのプレハブ、遷移後のシーンに Outのプレハブを置く。座標は変更しないこと。
  </li>
  <li>
    Inオブジェクトの SceneTransition.StartSceneTransition(string sceneName)を呼び出すことでシーン遷移を開始。引数には遷移先のシーン名を指定する。
  </li>
</ol>
