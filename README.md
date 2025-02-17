# CSharp on VSCode Memo

- C#開発を VSCode で行う上でのメモ

## 拡張機能

- 必須
  - C# Dev Kit (Microsoft)
    - C#開発の基本ツール
  - C# (Microsoft)
    - C# の基本言語サポート(C# Dev Kit に付随してくる)
  - .NET Install Tool (Microsoft)
    - SDK と Runtime をインストール/管理する(C# Dev Kit に付随してくる)
  - IntelliCode for C# Dev Kit (Microsoft)
    - C#コード補完ツール
- 任意
  - C# Extensions (JosKreativ)
    - VisualStudio のようにクラスなどを追加できるようになる

## .NET バージョン確認

- `dotnet --version`
  - インストールされているバージョン確認

## テンプレート作成

- `dotnet new list`
  - インストールされているテンプレート確認
- `dotnet new gitignore`
  - .gitignore 作成
- `dotnet new console -o ./ConsoleApp`
  - 指定の場所にコンソールアプリ作成

## ソリューション追加

- `dotnet new sln`
  - ソリューションファイル作成
- `dotnet sln add ./ConsoleApp`
  - プロジェクト追加

## ビルド

- `dotnet build`
  - csproj のある階層で実行すると bin と obj ができる
- `dotnet run`
  - csproj のある階層で実行するとターミナルで実行結果が返る

## デバッグ

- `Ctrl + Shift + P`→`.Net: Generate Assets for Build and Debug`
  - .vscode/launch.json, tasks.json が作られる
- tasks.json
  - `"label":"build"`→`"label":"build_ConsoleApp"`に変える
- launch.json
  - `"name": ".NET Core Launch (console)"`→`"name": ".NET Core Launch (console)_ConsoleApp"`に変える
  - `"preLaunchTask": "build"`→`"preLaunchTask": "build_ConsoleApp",`に変える

## 参考

- [[C#]VSCode で複数プロジェクトを持つソリューションを作るときの備忘録](https://qiita.com/unyorita/items/8a92cb19b618e8e4a4a5)
