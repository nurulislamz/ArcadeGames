import Grid from './Grid';
import MarkersEnum from './MarkersEnum';
import Players from './Players';

class Game {
  grid: Grid;
  player1: Players;
  player2: Players;
  gameRunning: boolean; 

  // Constructor
  constructor(player1Mark: string, player2Mark: string) {
      this.grid = new Grid(); // Each instance of Game will have its own grid
      this.player1 = new Players(player1Mark);
      this.player2 = new Players(player2Mark);
      this.gameRunning = true;

      while (this.gameRunning){
        for (let player in MarkersEnum){
          if (isNaN(Number([player]))){
            let row = 1;
            let col = 1;
            this.makeMove(row, col, MarkersEnum[player as keyof typeof MarkersEnum]);            
          }

          let winner = this.grid.CheckWin()

          if (winner){
            this.gameRunning = false;
          }
        }
      }
  }

  makeMove(row: number, col : number, playerMark: MarkersEnum){
    if (this.grid.GetGrid(row, col) == MarkersEnum.Empty){
      this.grid.SetGrid(row, col, playerMark);
    }
  }
}

export default Game;