import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import LandingPage from "./components/LandingPage";
import SignInPage from "./components/SignInPage"; // Assume this is the sign-in page
import GuestPage from "./components/GuestPage";

const App = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<LandingPage />} />
        <Route path="/signin" element={<SignInPage />} />
        <Route path="/guest" element={<GuestPage />} />
      </Routes>
    </Router>
  );
};

export default App;
