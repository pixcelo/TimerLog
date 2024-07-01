# Timer Recorder

## 機能
- タイマーを起動する (指定した時間)
- 音を鳴らす
- OSの通知
- タイマーの開始・終了時間からスクリーン時間の保存
- 設定
    - 時間の設定
    - タイマーの属性の設定

## 要件
- ブラウザから使用できる
- スクリーン履歴が一覧化、グラフ表示される (何回、何分使用したかが分かる)
- 何のタイマーを何回使ったかを記録する (タイマーの属性を設定できる)


## DB設計
### トランザクションテーブル
- T_TimerLog : タイマーログ
    - Id
    - StartAt : 開始時間
    - EndAt : 終了時間
    - UserId : ユーザーID
    - TypeId : タイプID

### マスタテーブル
- M_User : ユーザーマスタ
    - Id
    - Name
- M_TimerType : タイマータイプマスタ
    - Id
    - Name

    マスタ例：ゲーム、YouTube、百ます計算

### ビュー
- V_TimerLog : タイマービュー (誰がいつ、どのタイマーをどれだけ使ったかを視る)

## 参考
### API関連
- [ASP.NET Core を使って Web API を作成する](https://learn.microsoft.com/ja-jp/aspnet/core/web-api/?view=aspnetcore-8.0)
- [ASP.NET Core APIサンプルコード](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/web-api/index/samples)