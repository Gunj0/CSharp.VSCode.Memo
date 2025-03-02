# CSharp on VSCode Memo

- C#開発を VSCode で行う上でのメモ
- +ドメイン駆動設計

## VSCode 拡張機能

- 必須
  - C# Dev Kit (Microsoft)
    - C#開発の基本ツール, デバッグ等
  - C# (Microsoft)
    - C# の基本言語サポート(C# Dev Kit に付随してくる)
  - .NET Install Tool (Microsoft)
    - SDK と Runtime をインストール/管理する(C# Dev Kit に付随してくる)
  - IntelliCode for C# Dev Kit (Microsoft)
    - C#コード補完ツール
- 任意
  - C# Extensions (JosKreativ)
    - 右クリックでクラスファイル等を追加できる
  - NuGet Gallery (pcislo)
    - 統合ターミナルで NuGet が GUI 操作できる

## .NET バージョン確認

- [.NET の最新バージョン](https://dotnet.microsoft.com/ja-jp/download)
- `dotnet --version`
  - 使用されている.NET SDK バージョン
- `dotnet --list-sdks`
  - インストールされている.NET SDK バージョン一覧
- `dotnet --list-runtimes`
  - インストールされている.NET ランタイム一覧
- `dotnet --info`
  - 環境情報などの詳しい情報

## プロジェクトテンプレート作成

- [テンプレート一覧](https://learn.microsoft.com/ja-jp/dotnet/core/tools/dotnet-new)
- `dotnet new list`
  - インストールされているテンプレート確認
- `dotnet new {テンプレート名} -o {Path}`
  - テンプレート作成
- 主要テンプレート名
  - sln: ソリューション
  - gitignore: .gitignore
  - console: コンソールアプリ
  - classlib: クラスライブラリ
  - mvc: ASP.NET Core Web MVC
  - webapi: ASP.NET Core Web API
  - mstest: MSTest
  - webconfig: Web 構成

## ソリューションへ追加

- `dotnet sln add {Path}`
  - ソリューションにプロジェクト追加
- `dotnet sln remove {Path}`
  - ソリューションにプロジェクト削除
- `dotnet sln list`
  - ソリューション内のプロジェクト表示

## プロジェクト参照追加

- `dotnet add {参照する側Path} reference {参照される側Path}`
  - プロジェクト参照を追加する
- `dotnet remove {参照する側Path} reference {参照される側Path}`
  - プロジェクト参照を削除する

## ビルド

- `dotnet build`
  - bin と obj が作られる
- `dotnet run`
  - ターミナルで実行結果が返る
  - もしくは F5

## デバッグ

- 1 つ目のプロジェクト
  - `Ctrl + Shift + P`→`.Net: Generate Assets for Build and Debug`
    - .vscode/launch.json, tasks.json が作られる
  - tasks.json
    - `"label":"build"`→`"label":"build_ConsoleApp"`に変える
  - launch.json
    - `"name": ".NET Core Launch (console)"`→`"name": ".NET Core Launch (console)_ConsoleApp"`に変える
    - `"preLaunchTask": "build"`→`"preLaunchTask": "build_ConsoleApp",`に変える
- 2 つ目のプロジェクト
  - `Ctrl + Shift + P`→`.Net: Generate Assets for Build and Debug`
    - .vscode/launch.json, tasks.json が作られる(置き換えますか？の警告は OK)
- これで、VSCode のデバッグタブからデバッグ対象を切り替えられるようになる

## テスト

- `dotnet test`
  - テスト実行される
  - もしくは VSCode のテストタブから実行できる

## NuGet

- C# Dev Kit の場合
  - `Control + Shift + P`→`NuGet: NuGet パッケージを追加`
- NuGet Gallery の場合
  - `Control + J`の NUGET タブで GUI 操作する

## テスト駆動開発

- 先に存在しないプロパティやメソッドに対するテストを書く
- 存在しないプロパティやメソッドの上で`Control + .`を押すと自動生成される

## 参考

- [dotnet コマンド](https://learn.microsoft.com/ja-jp/dotnet/core/tools/dotnet)
- [[C#]VSCode で複数プロジェクトを持つソリューションを作るときの備忘録](https://qiita.com/unyorita/items/8a92cb19b618e8e4a4a5)
- [VSCode と dotnet-cli で C#のソースコードをテスト出来るようにするまで](https://qiita.com/jnuank/items/e9aeb2d8c99d1e6f1081)
- [C#でドメイン駆動開発パート１【C#でドメイン駆動開発とテスト駆動開発を使って保守性の高いプログラミングをする方法】](https://yayoi-kkjp.udemy.com/course/domain-1/)
