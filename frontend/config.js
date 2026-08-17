const isLocal =
  window.location.hostname === "localhost" ||
  window.location.hostname === "127.0.0.1" ||
  window.location.hostname === "";
 
const API_BASE = isLocal
  ? "http://localhost:5280"
  : "https://kvschapkaartje.onrender.com";