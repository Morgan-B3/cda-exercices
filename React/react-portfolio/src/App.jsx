import React from 'react'
import { NavLink, Route, Routes } from "react-router-dom";
import Home from './pages/Home.jsx';
import NotFound from './pages/NotFound.jsx';
import Quiz from './components/quiz/Quiz.jsx';
import Bank from '../../react-exo4/src/components/bank.jsx';
import Gallery from './components/gallery/Gallery.jsx';
import Citation from './components/citation/Citation.jsx';

export default function App() {
  return (
    <div>
      <nav>
        <NavLink to="/">Home </NavLink>
        <NavLink to="/quiz">Quiz </NavLink>
        <NavLink to="/gallery">Gallerie </NavLink>
        <NavLink to="/citation">Citation </NavLink>
        <NavLink to="/banque">Banque </NavLink>
        <NavLink to="/perdu"> 404</NavLink>
      </nav>

      <Routes>
        <Route path='/' element={<Home />} />
        <Route path="/quiz" element={<Quiz/>} />
        <Route path="/gallery" element={<Gallery/>} />
        <Route path="/citation" element={<Citation/>} />
        <Route path="/banque" element={<Bank/>} />
        <Route path='/*' element={<NotFound />}/>
      </Routes>
    </div>
  )
}
