import React from 'react'
import { useState } from 'react'

export default function SearchBar({handleForm}) {
    const [disabled, setDisabled] = useState(true)
    const [search, setSearch] = useState("")

    const handleInput = (e) => {
        setSearch(e.target.value);
        console.log(e.target.value.trim());
        if(e.target.value.trim()){
            setDisabled(false)
        }
    }

  const handleSubmit = (e) => {
    e.preventDefault()
    handleForm()
    setDisabled(true)
    setSearch("")
  }

  return (
    <form onSubmit={handleSubmit} aria-label="formulaire de recherche">
      <label htmlFor="search">Recherche</label>
      <input
        id="search"
        type="text"
        placeholder="Recherche"
        value={search}
        onChange={(e) => handleInput(e)}
      />

      <button type="submit" disabled={disabled}>Rechercher</button>
    </form>
  )
}
