import React from 'react';
import './App.css';
import UserList from './pages/UserList';
import CreateUser from './pages/CreateUser';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';

function App() {
  return (
    <Router>
      <div className="App">
        <nav className="navbar">
          <div className="nav-container">
            <Link to="/" className="nav-logo">
              TCS User Management
            </Link>
            <ul className="nav-menu">
              <li className="nav-item">
                <Link to="/" className="nav-link">
                  Users
                </Link>
              </li>
              <li className="nav-item">
                <Link to="/create" className="nav-link">
                  Add User
                </Link>
              </li>
            </ul>
          </div>
        </nav>

        <main className="main-content">
          <Routes>
            <Route path="/" element={<UserList />} />
            <Route path="/create" element={<CreateUser />} />
          </Routes>
        </main>
      </div>
    </Router>
  );
}

export default App;
