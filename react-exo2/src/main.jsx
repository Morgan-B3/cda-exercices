import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import './App.css'
import Gallery from './gallery/Gallery.jsx'

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <Gallery></Gallery>
  </StrictMode>,
)
