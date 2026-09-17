Unity로 제작한  DOTween 활용 2D 탑뷰 NPC 상호작용 및 대화 시스템 데모입니다.



플레이어가 맵을 이동하며 NPC에게 접근하면 상호작용 안내 UI가 표시되고, E 키를 눌러 NPC와 대화를 시작할 수 있습니다.



NPC별 대화 데이터는 Unity Inspector에서 관리하며, 대화 진행과 UI 제어는 DialogueManager가 담당하도록 구성했습니다.



또한 DOTween을 활용하여 대화창 등장/종료, NPC 반응에 간단한 연출을 적용했습니다.



## **주요 기능**

\-플레이어 이동-

WASD 기반 2D 탑뷰 이동

대각선 이동 속도 보정

Collider2D 기반 맵 충돌

대화 중 플레이어 이동 제한



\-NPC 상호작용-

NPC 근처 접근 여부 감지

상호작용 가능 시 \[E] 대화하기 UI 표시

IInteractable 인터페이스 기반 상호작용 구조

플레이어가 현재 상호작용 가능한 오브젝트를 관리



\-대화 시스템-

NPC별 DialogueLine\[] 기반 대화 데이터 구성

마지막 대사 이후 대화 자동 종료

대화 시작 시 플레이어 이동 제한

대화 종료 후 플레이어 조작 복구



\-DOTween 연출-

DOScale을 이용한 대화창 등장 및 종료 연출

DOFade를 이용한 대화창 Fade 효과

Sequence와 Join을 이용한 복합 UI 애니메이션

DOPunchScale을 이용한 NPC 상호작용 피드백

OnComplete를 이용한 애니메이션 종료 후 UI 상태 처리

DOKill을 이용한 중복 Tween 방지



**조작방법**

WASD / 이동

E / 상호작용

다음 버튼 / 다음 대사 진행



## **주요 스크립트**

#### **-PlayerController-**

플레이어 이동을 담당합니다.



WASD 입력 처리

Rigidbody2D 기반 이동

대각선 이동 속도 보정

대화 중 이동 활성화/비활성화



#### **-PlayerInteraction-**

플레이어의 상호작용 입력을 담당합니다.



현재 상호작용 가능한 IInteractable 객체를 저장하고 E 키 입력 시 해당 객체의 Interact()를 호출합니다.



#### **-IInteractable-**

이후 NPC 뿐만 아니라 상자, 문 등 상호작용 가능한 오브젝트가 추가됐을 때 다형성을 보장할 수 있도록 Interact() 함수의 선언만 되어있고, 실제 함수는 NPC.cs에 구현되어 있습니다.



#### **-NPC-**

NPC별 대화 데이터와 상호작용을 담당합니다.



각 NPC는 Inspector에서 서로 다른 DialogueLine\[] 데이터를 설정할 수 있으며, 상호작용 시 DialogueManager에 자신의 대화 데이터를 전달합니다.



#### **-DialogueLine-**

한 줄의 대화 데이터를 표현하는 클래스입니다. 



System.Serializable을 이용하여 Unity Inspector에서 NPC별 대사를 직접 설정할 수 있도록 구성했습니다.



#### **-DialogueManager-**

전체 대화 흐름을 관리합니다.



대화 시작

현재 대사 출력

다음 대사 진행

대화 종료

플레이어 이동 제한

대화 UI 활성화 및 비활성화

DOTween 기반 대화창 연출



## **DOTween 활용**

**Dialogue UI**



대화 시작 시 DOScale과 DOFade를 동시에 실행합니다.

이를 통해 대화창이 확대되면서 자연스럽게 나타나도록 구성했습니다.

또한 대화창이 사라지는 애니메이션이 끝난 뒤 실제 UI를 비활성화하고 플레이어 이동을 다시 허용합니다.


---VIDEO---
<img width="1460" height="716" alt="Image" src="https://github.com/user-attachments/assets/08f25eaf-a4ac-4706-be2a-284824e8fdbc" />