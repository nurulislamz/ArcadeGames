import MarkersEnum from "./MarkersEnum";
import { error } from "console";

class Squares 
{
  mark : MarkersEnum

  constructor(){
    this.mark = MarkersEnum.Empty;
  }  

  private getMark(){
    return this.mark;
  }

  private setMark(_mark : MarkersEnum){
    this.mark = _mark;
  }

  public SelectSquare(_mark : MarkersEnum) : MarkersEnum{
    if (this.mark == MarkersEnum.O || this.mark == MarkersEnum.X){
      throw error("This square is already selected. Try a different one.")
    }
    return this.mark;
  }
}

export default Squares;