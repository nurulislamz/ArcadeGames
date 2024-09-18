import React from "react";
import MarkersEnum from "../logic/MarkersEnum";

interface SquareProps {
  value: MarkersEnum;
  onClick: () => void;
}

const Square: React.FC<SquareProps> = ({ value, onClick }) => {
  return (
    <button className="square" onClick={onClick}>
      {value}
    </button>
  );
};

export default Square;
