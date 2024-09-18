import IGame from "../interfaces/IGame";
import IGrid from "../interfaces/IGrid";
import IPlayer from "../interfaces/IPlayer";
import Grid from "./Grid";
import MarkersEnum from "./MarkersEnum";
import Player from "./Players";

class GameLogic implements IGame {
  public player1: IPlayer;
  public player2: IPlayer;
  public currentPlayer: IPlayer;
  public grid: IGrid;

  constructor() {
    this.player1 = new Player(MarkersEnum.X);
    this.player2 = new Player(MarkersEnum.O);
    this.currentPlayer = this.player1;
    this.grid = new Grid();
  }

  makeMove(row: number, col: number): boolean {
    try {
      this.grid.setMarkAt(row, col, this.currentPlayer.mark);
      return true;
    } catch (error) {
      console.error(error);
      return false;
    }
  }

  switchPlayer(): void {
    this.currentPlayer =
      this.currentPlayer === this.player1 ? this.player2 : this.player1;
  }

  resetGame(): void {
    this.grid = new Grid();
    this.currentPlayer = this.player1;
  }
}

export default GameLogic;
