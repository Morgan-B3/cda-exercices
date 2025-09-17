import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import './App.css'
import Citation from '../components/Citation.jsx'

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <Citation/>
  </StrictMode>
)
