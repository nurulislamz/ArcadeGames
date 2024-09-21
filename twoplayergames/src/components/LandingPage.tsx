import React, { useEffect, useState } from "react";
import SignIn from "./SignIn";
import Guest from "./Guest";

const LandingPage = () => {
  return (
    <div>
      <h1>Two Player Games</h1>
      <SignIn />
      <Guest />
    </div>
  );
};

export default LandingPage;
