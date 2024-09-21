import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import LandingPage from "./components/LandingPage";
import SignInPage from "./components/SignIn"; // Assume this is the sign-in page

const App = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<LandingPage />} />
        <Route path="/signin" element={<SignInPage />} />
        <Route path="/guest" element={<SignInPage />} />
      </Routes>
    </Router>
  );
};

export default App;
