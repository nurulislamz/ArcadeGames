import React, { useState } from "react";
import LandingPage from "./components/LandingPage";

const App: React.FC = () => {
  const [showGame, setShowGame] = useState(false);

  const startGame = () => {
    setShowGame(true);
  };

  return (
    <div>
      {!showGame ? <LandingPage></LandingPage> : <div>GameComponent</div>}
    </div>
  );
};

export default App;
