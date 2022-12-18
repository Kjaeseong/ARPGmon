# VPS1팀 개발부 Git 관리전략

## 작성자
- 김재성

## 최종 수정일자
- 2022.12.18 일요일

## 개요
- 본 프로젝트 진행 간 Git Repository 관리에 있어 통일성을 유지하고, 업무간의 효율성을 높이기 위함

## 규칙

### Branch
- **Master(main)**
  - 정식 버전 빌드용 브랜치
- **Develop**
  - 기능 개발/구현용 브랜치
  - 이 브랜치에서 작업 브랜치를 생성 후, 개별 작업 완료시 이 브랜치로 Merge한다.
    - Merge시 Pull requests를 활용. 충돌 대비
- **개인 작업 Branch**
  - 생성 브랜치 명 : `Type/작업내용`
    - Type
      - `Feat` : 새로운 기능 추가
      - `Fix` : 기존 기능 및 버그 수정
      - `Test` : 기능 테스트 전용
      - `Set` : 프로젝트 설정 등 유니티 자체의 설정
    - ex> `Feat/CharacterWalkAnimation`
    - ex> `Fix/FlowerObjectBugFix`
    - ex> `Test/ObjectOnPlane`
    - ex> `Set/BuildSetting`
  - 작업 내용이 짧더라도 브랜치 명으로 각자의 작업 진행도 표기를 위해 가급적 정확히 기재한다.

### Commit
- **Commit 주기**
  - 충돌 및 버그 발생시 Reset을 용이하게 하기 위해 작은 단위로 나눠 커밋한다.
    - ex> 이미지 리소스 추가, 스크립트 생성, 한 단위의 기능 구현 시
  - 커밋 메세지는 아래의 규칙을 따르며, 부가설명이 필요한 경우 Description(설명)란에 기재한다.
- **Commit 메세지**
  - `[Type]: 내용`
    - ex> `[Fix]: Flower 오브젝트 배치시 위치 어긋나는 버그 수정`
  - Type
    - `[Feat]:`새로운 기능 추가
    - `[fix]:`버그 및 기능의 수정
    - `[Set]:`프로젝트 설정 등 유니티 자체의 설정 변경
    - `[Refactor]:`기능에 영향을 주지 않는 범위의 코드 수정(코드 리팩토링 등)
    - `[Test]:`테스트에 관련된 모든 작업
    - `[Docs]:`문서파일 수정(데이터시트 / CSV 등)
    - `[Create]:`프로젝트 및 씬/스크립트/오브젝트/프리팹 등의 생성
    - `[Add]:`리소스 및 에셋 등, 스크립트/오브젝트(프리팹) 외적인 파일 추가
  - 타입 종류에 기재되지 않은 단순 작업들은 타입을 기재하지 않는다.
    - ex> `불필요 파일 정리`

### 작업규칙
- 규칙에 맞춰 브랜치 생성
- 작업시 `이름 이니셜_Test_작업명`의 씬을 추가해 해당 씬 안에서만 작업한다.
  - ex> `KJS_Test_CharacterWalkAnimation`
- 작업시 생성하는 `스크립트`/`프리팹` 파일은 추후 수정 및 코드, 기능 추가의 여지가 있을 경우 파일명 앞에 `이니셜_`을 붙인다.
  - ex> `KJS_CharacterMovement`
  - ex> `KJS_FlowerPrefab`