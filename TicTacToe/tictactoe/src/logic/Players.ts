import IPlayer from "../interfaces/IPlayer";
import MarkersEnum from "./MarkersEnum";

class Player implements IPlayer {
  private score: number = 0;
  public readonly mark: MarkersEnum;

  constructor(mark: MarkersEnum) {
    this.mark = mark;
  }

  public incrementScore(): void {
    this.score++;
  }

  public getScore(): number {
    return this.score;
  }
}

export default Player;
