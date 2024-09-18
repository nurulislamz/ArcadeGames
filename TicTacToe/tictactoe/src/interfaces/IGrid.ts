import MarkersEnum from "../logic/MarkersEnum";

interface IGrid {
  grid: MarkersEnum[][];
  isSquareEmpty(row: number, col: number): boolean;
  getMarkAt(row: number, col: number): MarkersEnum;
  setMarkAt(row: number, col: number, mark: MarkersEnum): void;
  checkWin(): MarkersEnum | null;
  isFull(): boolean;
}

export default IGrid;
