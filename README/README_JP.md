# Chattokouken Ganbarunoda!!

![platform](https://img.shields.io/badge/platform-Windows-0078D6)
![framework](https://img.shields.io/badge/framework-.NET-512BD4)
![license](https://img.shields.io/badge/license-MIT-2EA043)
![release](https://img.shields.io/badge/version-v0.1.1-orange)

[English](../README.md) | [한국어](README_KR.md) | [日本語](README_JP.md)

### チャット貢献頑張るのだ！！

> > リアルタイムチャット翻訳とメッセージ送信をしてくれる自動翻訳補助ツールなのだ！ 特に開発者向けの用途というわけではないのだ。

---

<br>

## 目次なのだ！

- [注意事項と制限なのだ！](#warning)
- [プレビューなのだ！](#preview)
- [どんなプログラムなのだ？](#about)
- [インストールと使い方なのだ！](#install)
- [設定方法なのだ！](#setting)
- [更新内容と今後の予定なのだ！](#changelog)
- [開発者を支援できるのだ！](#support)
- [よくある質問なのだ！](#faq)
- [退屈で衒学的な技術説明](#description)

<br>
<a id="warning"></a>

## ⚠️ 注意事項と制限なのだ！

> このプログラムはキーボードフック、フォーカス移動、マクロのような入力処理を使用しているのだ。だから厳しいアンチチートやマクロ防止機能があるゲームでは使用をおすすめしないのだ！このプログラムの使用によるアカウント停止やBANについて、開発者は責任を取れないのだ！

> 現在のプログラム構造では、入力として扱えるのは英語アルファベットと韓国語だけなのだ... 将来的には別の方法で全言語へ対応できるようにする予定なので、気長に待ってほしいのだ！翻訳対象の言語自体には制限はないのだ！

<br>
<a id="preview"></a>

## 🎬 プレビューなのだ！

> 会話相手は友達なのだ。別に失礼ではないのだ。

![DiscordPreview](Resources/starcraft_demonstration.gif)

![StarCraftPreview](Resources/discord_demonstration.gif)

<br>
<a id="about"></a>

## ✨ どんなプログラムなのだ？

> ゲームやメッセンジャーで翻訳しながらチャットしたい時、>>文章を入力してコピーしてWeb翻訳を開いて翻訳して、またコピーして戻って貼り付けて送信する<<という、とんでもなく面倒な流れがあるのだ... <br>このプログラムは、その不便さをなくすために、チャット入力の流れに合わせて自動で翻訳をリクエストし、翻訳結果を受け取ったら自動で入力してくれる補助ツールなのだ！つまり、自動！チャット！翻訳！補助！ツール！なのだ！

<br>

このプログラムには、こんな機能があるのだ：

- 入力された文字を頑張って組み立てて保存してくれるコンポーザー
- 頼めば黙々と翻訳してくれるDeepL連携
- 翻訳結果をクリップボードへ入れてくれる親切機能
- 代わりにクリップボード内容を入力してくれるマクロ
- 現在状態を表示してくれる頼もしいオーバーレイ
- 状態を知らせてくれる綺麗な通知サウンド
- 軽量なシステムトレイアプリなのだ！

<br>

このプログラムはゲームやメッセンジャーのチャット内容を読み取ったり盗み見たりするものではないのだ。それは色々危ないのだ。あくまでキー入力を受け取って文章を再構築しているだけなのだ。

<br>
<a id="install"></a>

## 📦 インストールと使い方なのだ！

> Windows 11 64bit環境のみ対応なのだ！Windows 10ではまだテストしていないのだ。

<br>

[Releases](https://github.com/Railiya/ChattokoukenGanbarunoda/releases) から最新の圧縮ファイルをダウンロードして、CKG.exe を実行するのだ。管理者権限が必要なのだ！

<br>

プログラムのライフサイクルはこんな感じなのだ：

1. **[DISABLED]** : キー入力取得が無効状態なのだ。「Enable Capturing」キーでON/OFFできるのだ！
2. **[IDLE]** : 待機状態なのだ。
3. **[CAPTURING]** : 入力を受け取っている状態なのだ。「Capturing Toggle」キーで切り替えるのだ！
4. **[BUFFERED]** : 入力完了後、文章が保存された状態なのだ。
5. **>> TRANSLATING** : 翻訳リクエストを送って待機中なのだ！「Translate」キーでリクエストするのだ！
6. **[READY]** : 翻訳完了してクリップボードへコピーされた状態なのだ！「Send Clipboard」キーで入力マクロを実行できるのだ！
7. **[FAILED]** : 翻訳リクエスト失敗なのだ... 原因はいろいろあるのでログファイルを見るのだ。

<br>

実際のチャット手順はこんな感じなのだ：（デフォルトキー基準なのだ）

1. **チャット入力開始 (Enter)** *[Idle -> Capturing]*
2. テキスト入力
3. **チャット入力終了 (Enter)** *[Capturing -> Buffered]*
4. **翻訳リクエスト送信と待機 (Ctrl + Enter)** *[Buffered -> Translating]*
5. 翻訳完了 *[Translating -> Ready]*
6. **入力マクロ実行 (Backslash)**

<br>

**（かなり重要な話なのだ！）**

このプログラムでは、韓国語/英語入力状態をWindows IMEとは別に管理しているのだ。プログラム構造上、現在どの入力言語なのかを完全には把握できないのだ。だから**プログラム内の韓国語/英語入力モードは手動で切り替える必要があるのだ。韓英キーを普通に押すとWindows IMEと一緒にプログラム側の入力モードも切り替わるのだが、Ctrl、Alt、Shiftのどれかを押したまま韓英キーを押すと、プログラム側の入力モードは切り替わらないのだ。** この挙動を利用して、チャット入力言語とプログラム入力言語を合わせて使うのだ！

<br>

4番と6番の処理は設定で自動化することもできるのだ！両方ONにすると、追加キーを押さずチャットするだけで良くなるのだ！慣れが必要なので、「Advanced - Debug Echo Mode」をONにしてメモ帳で練習するのをおすすめするのだ！

<br>

Xボタンを押してもプログラムは完全終了せず、システムトレイへ移動するのだ。つまり裏で動き続けているのだ。完全終了するには、上部メニューの「CKG -> Exit」を押すか、トレイアイコンを右クリックして「Exit」を押すのだ。

<br>
<a id="setting"></a>

## ⚙️ 設定方法なのだ！

![MainForm](Resources/main_form.jpg)

### 一般設定 (General)

> 自動オプションを全部ONにするとUXはかなり良くなるのだが、翻訳が長引いたりタイムアウトすると、その間は何もできなくなるので注意なのだ！

| Setting | Description |
|---|---|
| Start Translate on Buffered | 入力完了後、Buffer状態になると自動で翻訳リクエストを送るのだ |
| Auto Send Message on Translated | 翻訳完了時、自動で入力マクロを実行するのだ |
| Output Method | 入力マクロの動作方式なのだ |
| Default Input Mode | プログラム起動時の韓英入力状態なのだ |

- Output Method - Clipboard Paste : クリップボード内容を貼り付ける方式なのだ
- Output Method - Input Simulating : クリップボード内容を1文字ずつ入力する方式なのだ（貼り付け禁止ゲーム向けなのだ）

<br>

### 翻訳 (Translation)

> 翻訳を使うにはDeepL APIキーが必要なのだ！まだ他の翻訳モデルには対応していないのだ。Glossaryは固有名詞などが変な翻訳にならないようにするためのユーザー辞書なのだ！Glossary IDは必須ではないのだ。

| Setting | Description |
|---|---|
| Model | 使用する翻訳モデルなのだ |
| API Key | 翻訳API認証キーなのだ |
| Glossary Id | Glossary IDなのだ |
| Source Language | 入力言語なのだ |
| Destination Language | 翻訳先言語なのだ |
| Translation Format | 翻訳文をクリップボードへコピーする形式なのだ |
| Request Timeout | 翻訳リクエストのタイムアウト時間なのだ |

<br>

### オーバーレイ (Overlay)

> プログラム状態を表示するのだ。状態によって文字色も変わるのだ！右側には現在の入力モードが表示されるのだ！アルファベット入力なら「A」、韓国語入力なら「가」と表示されるのだ！

| Setting | Description |
|---|---|
| Enabled | オーバーレイをON/OFFするのだ |
| Anchor | オーバーレイ表示基準位置なのだ |
| Offset X,Y | 基準位置からのオフセットなのだ |
| Font Size | フォントサイズなのだ |
| Opacity | 透明度なのだ |

<br>

### 通知 (Notification)

> サウンドファイルはSoundsフォルダに入っているのだ。同じ名前なら好きな音へ差し替え可能なのだ！

| Setting | Description |
|---|---|
| Enabled | サウンド通知をON/OFFするのだ |
| On Capturing Start | 入力開始時に通知するのだ |
| On Translation Completed | 翻訳完了時に通知するのだ |
| On Translation Failed | 翻訳失敗時に通知するのだ |
| Volume | 通知音量なのだ |

<br>

### ホットキー (Hotkeys)

> キーを変更するにはボタンを押して表示を「...」にしたあと、好きなキーを押すのだ。ESCで割り当て解除できるのだ。制御キー込みで区別されるので重複しても問題ないのだ。ただしゲームで使う場合はゲーム側キーと被らないよう注意なのだ。

| Setting | Description |
|---|---|
| Enable Capturing | キー入力取得をON/OFFするのだ |
| Capturing Toggle | 入力開始/終了キーなのだ（ゲームではチャットキーに合わせるのだ） |
| Translate | 翻訳リクエストを送るのだ |
| Send Clipboard | クリップボード入力マクロを実行するのだ |

<br>

### 高度設定 (Advanced)

> 主にデバッグ用なのだ。ログはLogsフォルダへ保存されるのだ。

| Setting | Description |
|---|---|
| Debug Echo Mode | 翻訳せず原文をクリップボードへコピーするのだ |
| Write Log File | 状態変更時にログを書き込むのだ |

<br>
<a id="changelog"></a>

## 📄 更新内容と今後の予定なのだ！

更新履歴は [CHANGELOG.md](../CHANGELOG.md) を見るのだ！残念ながら日本語版はまだ無いのだ...

<br>

### 将来的に追加されるかもしれないものなのだ！

> このプロジェクトは個人が空き時間で更新しているのだ。特に時間については何も保証できないのだ。

<br>

**オーバーレイ入力方式**

現在の方式では、日本語や中国語の漢字のような複雑な文字入力を正常に扱えないのだ。これを解決するため、将来的にはオーバーレイ入力欄を追加する可能性があるのだ。入力開始時に強制的にオーバーレイへフォーカスを移し、Windows IMEを通して文字入力を行い、入力完了後に元のプロセスへフォーカスを戻してから元文章入力、翻訳リクエスト、マクロ実行を続ける方式なのだ。ただし、この方法にも制限が多いので、難しい入力言語専用の補助機能になる可能性が高いのだ。

<br>

**OCR翻訳**

これは元々のプロジェクト目的とは別に計画している機能なのだ。通常入力が上手く動かない時の代替手段にもなれるのだ。他人のチャット内容も翻訳できるという利点もあるのだ。

<br>

**入力マクロ設定**

現在の入力マクロはゲーム中心で作られているので、「Enter -> 入力 -> Enter」の流れを前提としているのだ。メッセンジャーでは入力欄が常に開いていることが多いので、最初のEnterが不要な場合もあるのだ。将来的には、より柔軟に設定できるようになるかもしれないのだ。

<br>

**プロフィールリスト**

ゲームやメッセンジャーごとに別設定を保存できるよう、サイドメニュー形式のプロフィールリストを追加するかもしれないのだ。

<br>

**さらに多くの翻訳API**

Google Translate API や Papago API も検討しているのだ。ただ、Papagoは有料モデルしか無いので、正直かなり厳しそうなのだ。

<br>

**WinForms から Avalonia への移行**

WinForms はWindowsでしか動かないのだ... しかも正直あまり綺麗じゃないのだ... だから、将来的にはAvaloniaへ移行して、macOSやLinux対応もできるようにしたい気持ちはあるのだ。もちろんその前に、キーボードフックなどが他プラットフォームで正常動作するか確認しないといけないのだ。

<br>
<a id="support"></a>

## ☕ 開発者を支援できるのだ！

> このプロジェクトが気に入ったなら、開発者を支援できるのだ！もちろん強制ではないのだ！

<br>

[Ko-fi](https://ko-fi.com/glingy) または [Sponsors](https://github.com/sponsors/Railiya) から支援できるのだ！かなり励みになるのだ！

<br>
<a id="faq"></a>

## ❓ よくある質問なのだ！

**Q. なぜこんな話し方をしてるの？**

> **A. そりゃあ…面白いから。**

<br>

**Q. キー入力を受け付ける時、マウスや矢印キー関連の入力は受け付けられないの？**

> **A. このプログラムはキー入力だけを受け付けるから、マウス関連のイベントが発生しても処理できないんだ。ただ、矢印キー関連のものはあえて作らなかった。 チャットの時にあまり使われないからだね。バックスペースは問題ないから、経験上大きな問題はない。だけど、要望する人が多ければ矢印キーのイベントは実装してみるよ。**

<br>

**Q. なんでアイコンがこんな見た目なんだ？**

> **A. アイコン描いてください…**

<br>
<a id="description"></a>

## 🛠️ 退屈で衒学的な技術説明

<br>

### 動作原理

Windows全域で使われるキー入力にフック（Hook）をかけ、ローレベル（低レベル）段階でキー入力を追跡するが、あいにくこの入力は文字ではなくキーとして受け取る。したがって、「a」キーを押したなら、それが「a」かもしれないし、「A」かもしれないし、「ㅁ」かもしれない。 そのため、現在の入力モードに応じてアルファベットやハングルを組み合わせるコンポーザー（Composer）を実装し、入力された文章を再組み立てする方法を使っている。 このため、日本語で使う漢字は入力（受け付け）できない。漢字を入力する際に使用される漢字リストがプラットフォームごとに異なり、ユーザーがよく使う漢字によっても違うため、これを追跡する方法がないんだ…

マウスイベントを受け取れないのも問題の一つで、純粋にキー入力だけを受け取るため、マウスでカーソルを動かしたり、漢字をマウスで選択したりすると追跡する方法がない。

<br>

### 安全性

上部の注意事項にも書いておいたが、このプログラムの動作方式はマクロと同じなので、アンチチートがあるゲームで使用すると危険な場合がある。プログラムの使用に対する責任は常にユーザーにあることを伝えておきたい。念のため、このプログラムで使用されているWin32関数を書き残しておく：

```cs
extern void keybd_event(byte bVk, byte bScan, uint dwFlags, nuint dwExtraInfo);
extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);
extern bool BlockInput(bool fBlockIt);

extern nint SetWindowsHookEx(int idHook, HookProc lpfn, nint hMod, uint dwThreadId);
extern bool UnhookWindowsHookEx(nint hhk);
extern nint CallNextHookEx(nint hhk, int nCode, nint wParam, nint lParam);
extern nint GetModuleHandle(string lpModuleName);

extern short GetKeyState(int nVirtKey);
extern short GetAsyncKeyState(int vKey);
extern bool GetKeyboardState(byte[] lpKeyState);
extern nint GetKeyboardLayout(uint idThread);
```
