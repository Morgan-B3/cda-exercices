import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import './App.css'
import Bank from './components/bank.jsx'
import { store } from './store.js'
import { Provider } from "react-redux"

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <Provider store={store}>
      <Bank />
    </Provider>
  </StrictMode>,
)
