import React from 'react'

export default function Home() {

  const playCryLegacy = () => {
    // if (!pokemon.cries?.latest) return;

    const audio = new Audio("https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/legacy/1.ogg");
    audio.play();
  };

  const playCryLatest = () => {
    // if (!pokemon.cries?.latest) return;

    const audio = new Audio("https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/1.ogg");
    audio.play();
  };

  return (
    <>
    <div>Home</div>
    <button onClick={playCryLegacy}>
    🔊 Legacy
    </button>
    <button onClick={playCryLatest}>
    🔊 Latest
    </button>
    </>
  )
}
