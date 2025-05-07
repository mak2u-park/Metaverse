# Metaverse


프로젝트의 구조

Assets/<br>
 ├─ Scripts/<br>
 │   ├─ MiniGameManager.cs<br>
 │   ├─ ResourceController.cs<br>
 │   ├─ BaseUI.cs<br>
 │   ├─ UIManager.cs<br>
 │   ├─ MiniGameInput.cs<br>
 │   ├─ MainMap/<br>
 │   │    ├─ MainCamera.cs<br>
 │   │    ├─ PlayerController.cs<br>
 │   │    ├─ AnimationHandler.cs<br>
 │   │    ├─ PopupUI.cs<br>
 │   │    ├─ UIHandler.cs<br>
 │   ├─ FlappyPlane/<br>
 │   │    ├─ FPPlayer.cs<br>
 │   │    ├─ FPStartUI.cs<br>
 │   │    ├─ FPInGameUI.cs<br>
 │   │    ├─ FPRestartUI.cs<br>
 │   │    ├─ Obstacle.cs<br>
 │   │    ├─ BgLooper.cs<br>
 │   │    ├─ FollowCamera.cs<br>
 │   ├─ JumpingKnight/ ( 미완성 )<br>
 │   │    ├─ JKPlayer.cs<br>
 │   │    ├─ JKStartUI.cs<br>
 │   │    ├─ JKInGameUI.cs<br>
 │   │    ├─ JKRestartUI.cs<br>
 │   ├─ Dungeon/ ( 미완성 )<br>
 │   │    ├─ DGPlayer.cs ( 미구현 )<br>
 │   │    ├─ DGStartUI.cs ( 미구현 )<br>
 │   │    ├─ DGInGameUI.cs ( 미구현 )<br>
 │   │    ├─ DGRestartUI.cs ( 미구현 )<br>
 │   │    ├─ WeaponHandler.cs<br>
 │   ├─ Common/<br>
 │   │    ├─ BaseController.cs  <br>
 │   │    ├─ StatHandler.cs<br>
 


MainMap scene에서 시작해서 MiniGameInput를 통해 미니게임 scene으로 이동하고, 그 과정에서 UI를 UIManager를 통해 관리한다.<br>
mainMap에 있는 문에 1초간 접촉하면 자동으로 해당 미니게임으로 이동하며, MinigameManager를 통해 점수나 게임 오버 등의 상태를 판별한다.<br>
MainMap에서는 BaseController를 상속받는 PlayerController를 통해 키보드나 마우스 장치를 입력받으며, MainCamera를 통해 카메라 움직임을 제어한다.<br>
StatHandler의 경우 주 목적은 Dungeon에서 스탯을 설정해주기 위한 스크립트지만 MainMap에서의 이동을 위해서 필요하기 때문에 Common에 분류해 놓았다.<br>
PopupUI는 플레이어와 NPC의 trigger 충돌을 감지해 UI를 활성화한다.<br>
UIHandler는 MainMap 문 앞에 있는 NPC들의 UI를 관리한다. UI가 NPC 옆에 나타나서 미니게임에 대한 정보와 최고 기록을 보여주기를 바랐기 때문에 이런 식으로 구현했는데<br>
다소 불편한 방식이었던 것 같다.<br>


각 미니게임에 해당하는 문에 1초동안 접촉 시 미니게임으로 이동한다.<br>
이때 어떤 미니게임 scene으로 이동할지 결정하는 것은 UIManager이다.<br>
이 스크립트에서 각 scene으로 입장시 시작 UI를 활성화해주며, enum으로 각 씬의 UI들을 관리한다.<br>
GameStart(), GameExit() 등 버튼 클릭시 호출되는 함수를 관리하는 것도 이 스크립트이다.<br>
MiniGameInput 스크립트는 플레이어와 문의 접촉을 판별한다. <br>






