import React from 'react'

export default function Greeting({name = "invité"}) {
  return (
    <p>Bonjour, {name} !</p>
  )
}
