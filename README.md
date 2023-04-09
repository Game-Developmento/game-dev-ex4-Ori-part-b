<h1 align="center">Duck Shooting Game</h1>

This is a two-player game where each player controls a cube and shoots ducks at each other. The players are positioned at opposite ends of the screen, and they can move left or right within their boundaries. Each player has three lives, and they win by eliminating their opponent's lives.

## How to Play And Rules
1. [Click here to play the game!](https://orihoward.itch.io/duck-shooting-game)
2. Player 1 moves left or right using the A and D keys and shoots with the spacebar.
3. Player 2 moves left or right using the arrow keys and shoots with the / key.
4. Each player can shoot only once every 0.5 seconds.
5. If a duck hits a player, they are immune for 2.5 seconds, during which time they cannot be hit again.
6. If a player loses all their lives, the game is over and the other player wins.

## Notes
- The ducks will be destroyed if they are not in sight of the camera, which prevents objects from accumulating and slowing down the game.
- There is a delay between each duck spawn to prevent players from spamming shots.
- The players have boundaries that limit how far they can move left or right.
- The game is intended for two players, so make sure you have a friend to play with!

## Scripts

### BlockMovement
This component ensures that the player cannot move beyond the boundaries in the game. The boundaries limit how far the player can move left or right.

### ClickSpawner
This component can spawn objects in the game, mainly for the ducks that are being shot by the player. It controls the spawning of ducks, including the delay between each duck spawn to prevent players from spamming shots.

### hitPlayer
This component is responsible for all the actions that occur when a player is hit, such as decrementing their life (each player has 3), giving them immunity for 2.5 seconds after a hit, and destroying the hitting object (which is the duck in this case because the player is shooting ducks).

### PlayerLives
This component is responsible for managing the lives of each player. Each player starts with 3 lives, and when they lose all their lives, the game is over.

### gameManager
This component has one function that reloads the scene. This function is attached to a button that says "restart game".

**That's it! Have fun playing the game!**
