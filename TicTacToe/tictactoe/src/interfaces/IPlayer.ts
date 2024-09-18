import MarkersEnum from "../logic/MarkersEnum";

interface IPlayer {
  readonly mark: MarkersEnum;
  incrementScore(): void;
  getScore(): number;
}

export default IPlayer;
