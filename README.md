## 프로젝트 개요
- 프로젝트 이름: OceanStory 
- 프로젝트 팀: Gambling 7|7|7 JackPot
- main() 위치: Program.cs

## 구현 진행
#### 필수 요구사항 구현
1. 게임시작 화면
2. 상태 보기
3. 전투 시작

#### 선택 요구사항 구현
1. 캐릭터 생성
2. 직업 선택
3. 치명타
4. 회피
5. 레벨업
6. 보상
7. 퀘스트
8. 콘솔 꾸미기
9. 아이템
10. 회복
11. 스테이지
12. 저장/불러오기
13. 스킬

#### 추가 구현
1. 로그인

## 화면 구성
![화면구성](https://github.com/Gambling7l7l7JackPot/OceanStory/assets/93385183/7342e4b8-d129-4320-8a63-a02a77ba1b14)

## 추가 설명
- SceneManager: 화면 전환, 사용자 입력 (조작)
- SystemMessage: 콘솔 하단 사용자 메시지 출력
- ColorManager: 콘솔 글자 색 변경
- RewardManager: 플레이어 경험치 증가, 레벨업
- QuestManager: 퀘스트 진행도 증가, 퀘스트 완료
- Inventory: 플레이어 인벤토리
- SaveManager: 저장/불러오기
- SkillManager: 전사/마법사 스킬 관리, 스킬 사용


## 게임 저장
- 항목: 플레이어 정보, 스탯, 인벤토리, 퀘스트 진행도
- 저장 위치: 프로젝트폴더\sav\\(이름).파일
