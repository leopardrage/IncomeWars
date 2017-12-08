# IncomeWars

*Read this in other languages: [English](README.md), [Italiano](README.it.md)*

Income Wars is a simple local multiplayer strategy game for two players. This project has been developed with Unity3D 2017.2.0f3.

## Rules

Both players must defend their base while destroying the enemy's.
To achieve this goal, each player needs to send waves of fighters that will spawn near his base and fly automatically towards the opponent's base.
To send fighters, the left (green) player can use **Q**, **W**, **E**, **R**, **T** keys. The right (red) player can use **Y**, **U**, **I**, **O**, **P**.
Every fighter will attack nearby enemy fighters as well as the enemy base, if within range.

However, sending fighters has a cost which will be subtracted by the player's money upon purchasing.
Every 5 seconds, both players' money will be increased by the **income** value (here's where the game's title come from). This income will be increased every time a fighter is purchased.
The HUD shows every fighters' stats (cost, income increment and key to purchase) as well as the players' stats (money, income, base's Health Points).

## Technical notes:
1. The progressive red crack on the bases that increases over damage has been made with a simple **surface shader**, which shows additively part of a "crack" texture based on damage.
2. The HUD icons have been made with **rendertextures**, each rendered by a dedicated camera. The idea can be optimized, but it is a practical way to have the icons update automatically if the corresponding fighter prefab change.
