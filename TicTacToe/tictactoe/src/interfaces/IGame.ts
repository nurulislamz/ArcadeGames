import IPlayer from "./IPlayer";
import IGrid from "./IGrid";

interface IGame {
  player1: IPlayer;
  player2: IPlayer;
  currentPlayer: IPlayer;
  grid: IGrid;
  makeMove(row: number, col: number): boolean;
  switchPlayer(): void;
  resetGame(): void;
}

export default IGame;
