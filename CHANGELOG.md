# Changelog

## v0.1.3

**핫픽스**
- "Debug Echo Mode" 상태에서 번역 요청시 예외가 발생하는 문제 수정

**추가 사항**
- 상단 메뉴에서 원하는 프로파일을 불러올 수 있는 기능 추가
> "Profiles/" 폴더에서 기존 프로파일을 복사 후 이름을 "profile2", "profile3", "profile4" 식으로 수정하고 파일을 열어 ProfileName을 원하는 이름으로 변경하면 상단 메뉴에서 해당 이름으로 표시됩니다. 프로그램 실행 도중 수정한 경우 상단 메뉴 "Profiles/Refresh" 를 눌러 새로고침할 수 있습니다.

**Hotfix**
- Fix exception throw when request tralsnation with "Debug Echo Mode" enabled

**Added**
- Add specific profile load feature on top menu
> You can copy original profile in "Profiles/" directory and rename it with "profile2", "profile3", "profile4". Open the profile and edit ProfileName as you want. The name appears on top menu. If you edit during program running, you can refresh it by click the "Profiles/Refresh" on top menu.

## v0.1.2

**핫픽스**
- API Key가 없는 상태에서 번역 요청시 예외가 발생하는 문제 수정

**추가 사항**
- 상단 메뉴에 Github Page 다이렉트 링크 추가
- 프로그램 시작시 최신 버전 확인 추가

**Hotfix**
- Fix exception when request translation with empty API Key

**Added**
- Add Github Page direct link on top menu
- Add checking latest version on program start

## v0.1.1

- Initial public release