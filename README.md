# miniGame

### 游戏场景 
一个随机生成的n*m格子地图，地图上存在随机的[障碍](#障碍)。
### 障碍
[玩家角色](#玩家角色)无法通过的区域。
### 玩家角色
一种基本单位，占[地图](#游戏场景)1*1大小，可以上下左右[移动](#移动)或者可以进行放置[基地](#基地)、[地雷](#地雷)操作。每次需要花费1单位时间。
### 移动
一种基本操作，角色可在一个单位时间进行移动一格的操作。  
当移动的新区域无人占有时，自动进行占领，该区域为该角色所有。  
当移动的区域为其他角色占有时，判定该角色所持有的兵力与移动到的区域的兵力进行[战斗](#战斗)。  
### 基地
一种可放置单位。占地图1*1大小，不可与地雷共存一个区域，可以与玩家角色共存。基地拥有3格视野。当玩家不拥有任何基地时，判断玩家失败。  
玩家角色可以通过花费20兵力创建一个新的基地，基地低于20的兵力不能被[招募](#招募)。
### 地雷
一种可放置单位。占地图1*1大小，不可与基地共存一个区域，可以与玩家角色共存。当其他角色移动到地雷区域时，地雷将消失，并让该角色的兵力减少10。  
玩家角色可以通过花费20兵力创建一个新的地雷，地雷区域将不会[训练](#训练)出新的兵力。
### 招募
当玩家移动到自己所占领的区域时，自动获得该区域的所有兵力。该区域的现有兵力清零。
### 训练
被玩家占领的区域(不包括地雷区域),每一个单位时间将产生1的兵力。
### 战斗
当玩家移动到其他角色占有的区域时，将发生战斗，战斗将对双方兵力进行比较，从而出现3种结果。  
1、玩家兵力多于当前区域兵力=》玩家兵力减少当前区域，且当前区域被占领。  
2、玩家兵力等于当前区域兵力=》玩家移动失败，退回到移动前的区域，且当前区域改为无主之地。  
3、玩家兵力少于当前区域兵力=》玩家移动失败，退回到移动前的区域，且兵力清空。进攻区域兵力减少玩家兵力。  