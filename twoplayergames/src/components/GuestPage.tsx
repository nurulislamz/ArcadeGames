import React, { useState } from "react";

const GuestPage = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  return (
    <div>
      <h1>Guest Page</h1>
      <div>Generate Guid</div>
      <div>Generate 4 letter code</div>
    </div>
  );
};

export default GuestPage;
